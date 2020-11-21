using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using static Dapper.Contrib.Extensions.SqlMapperExtensions;

namespace Auth.Repository.DapperExtension
{
    /// <summary>
    /// Dapper Contrib Extension Async
    /// </summary>
    public static partial class SqlMapperExtensions
    {
        /// <summary>
        /// 分页列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="tables"></param>
        /// <param name="pagination"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> GetPagedListAsync<T>(this IDbConnection connection, List<Table> tables, Pagination pagination, IDbTransaction transaction = null) where T : class, new()
        {
            string sql = "";

            if (tables != null && tables.Any())
            {
                int count = 0;

                foreach (Table item in tables)
                {
                    // 别名为null，默认添加别名
                    item.Alias = string.IsNullOrEmpty(item.Alias) ? $"var{count++}" : item.Alias;

                    // 主表
                    if (!item.JoinType.HasValue)
                    {
                        sql += $" (SELECT {string.Join(",", item.Fields)} FROM {item.Name} WHERE {string.Join(" AND ", item.Wheres)}) AS {item.Alias}";
                    }
                    // 关联表
                    else
                    {
                        sql += $" {Enum.GetName(typeof(JoinType), (int)item.JoinType)} JOIN (SELECT " +
                            $"{string.Join(",", item.Fields)} FROM {item.Name} WHERE {string.Join(" AND ", item.Wheres)}) AS {item.Alias} " +
                            $" ON {tables[count - 1].Alias}.{tables[count - 1].JoinField} = {item.Alias}.{item.JoinField}";
                    }
                }
            }
            else
            {
                throw new Exception("没有要查询的表！");
            }

            // 数据连接对象名称
            var name = GetDatabaseType?.Invoke(connection).ToLower()
                       ?? connection.GetType().Name.ToLower();

            // 返回结果
            IEnumerable<T> list = new List<T>();

            // mysql数据库
            if (name.Equals("mysqlconnection"))
            {
                long timestamp = (long)await connection.ExecuteScalarAsync($"SELECT IFNULL(MIN(Timestamp), UNIX_TIMESTAMP()) FROM ({sql} LIMIT {(pagination.Page - 1) * pagination.PageSize}, 1) AS aluneth");
                list = await connection.QueryAsync<T>($"SELECT * FROM ({sql}) AS aluneth WHERE createdTime <= {timestamp} LIMIT {pagination.PageSize}");
            }
            // sqlserver数据库
            else if (name.Equals("sqlconnection"))
            {

            }

            return list;
        }

        /// <summary>
        /// Updates entity in table "Ts", checks if the entity is modified if the entity is tracked by the Get() extension.
        /// </summary>
        /// <typeparam name="T">Type to be updated</typeparam>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="entityToUpdate">Entity to be updated</param>
        /// <param name="transaction">The transaction to run under, null (the default) if none</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <returns>true if updated, false if not found or not modified (tracked entities)</returns>
        public static async Task<bool> UpdateAsync<T>(this IDbConnection connection, T entityToUpdate, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            if (entityToUpdate is IProxy proxy && !proxy.IsDirty)
            {
                return false;
            }

            var type = typeof(T);

            if (type.IsArray)
            {
                type = type.GetElementType();
            }
            else if (type.IsGenericType())
            {
                var typeInfo = type.GetTypeInfo();
                bool implementsGenericIEnumerableOrIsGenericIEnumerable =
                    typeInfo.ImplementedInterfaces.Any(ti => ti.IsGenericType() && ti.GetGenericTypeDefinition() == typeof(IEnumerable<>)) ||
                    typeInfo.GetGenericTypeDefinition() == typeof(IEnumerable<>);

                if (implementsGenericIEnumerableOrIsGenericIEnumerable)
                {
                    type = type.GetGenericArguments()[0];
                }
            }

            var keyProperties = KeyPropertiesCache(type).ToList();  //added ToList() due to issue #418, must work on a list copy
            var explicitKeyProperties = ExplicitKeyPropertiesCache(type);
            if (keyProperties.Count == 0 && explicitKeyProperties.Count == 0)
                throw new ArgumentException("Entity must have at least one [Key] or [ExplicitKey] property");

            var name = GetTableName(type);

            var sb = new StringBuilder();
            sb.AppendFormat("update {0} set ", name);

            var allProperties = TypePropertiesCache(type);
            keyProperties.AddRange(explicitKeyProperties);
            var computedProperties = ComputedPropertiesCache(type);
            var updateIgnoreProperties = UpdateIgnorePropertiesCache(type);
            var nonIdProps = allProperties.Except(keyProperties.Union(computedProperties).Union(updateIgnoreProperties)).ToList();

            var adapter = GetFormatter(connection);

            for (var i = 0; i < nonIdProps.Count; i++)
            {
                var property = nonIdProps[i];
                adapter.AppendColumnNameEqualsValue(sb, property.Name);  //fix for issue #336
                if (i < nonIdProps.Count - 1)
                    sb.Append(", ");
            }
            sb.Append(" where ");
            for (var i = 0; i < keyProperties.Count; i++)
            {
                var property = keyProperties[i];
                adapter.AppendColumnNameEqualsValue(sb, property.Name);  //fix for issue #336
                if (i < keyProperties.Count - 1)
                    sb.Append(" and ");
            }
            var updated = await connection.ExecuteAsync(sb.ToString(), entityToUpdate, commandTimeout: commandTimeout, transaction: transaction);
            return updated > 0;
        }

    }
}
