using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using Auth.SeedWork.Attributes;
using Auth.SeedWork.DapperExtensions;
using Dapper;
using Dapper.Contrib.Extensions;
using static Dapper.Contrib.Extensions.SqlMapperExtensions;

namespace Auth.Repository.DapperExtension
{
    /// <summary>
    /// Dapper Contrib Extension
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
        public static IEnumerable<T> GetPagedList<T>(this IDbConnection connection,
            List<Table> tables,
            Pagination pagination,
            object parameters = null,
            IDbTransaction transaction = null) where T : class, new()
        {
            string sql = "";  

            if(tables != null && tables.Any())
            {
                int count = 0;

                foreach(Table item in tables)
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
            if(name.Equals("mysqlconnection"))
            {
                // total
                pagination.Total = (int)connection.ExecuteScalar($"SELECT COUNT(*) FROM({sql}) AS aluneth", parameters);

                // paged list
                long timestamp= (long)connection.ExecuteScalar($"SELECT IFNULL(MIN(Timestamp), UNIX_TIMESTAMP()) FROM ({sql} LIMIT {(pagination.Page - 1) * pagination.PageSize}, 1) AS aluneth", parameters);
                list = connection.Query<T>($"SELECT * FROM ({sql}) AS aluneth WHERE createdTime <= {timestamp} LIMIT {pagination.PageSize}", parameters);
            }
            // sqlserver数据库
            else if(name.Equals("sqlconnection"))
            {

            }

            return list;
        }

        /// <summary>
        /// 根据条件获取列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="where"></param>
        /// <param name="parameters"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetListByWhere<T>(this IDbConnection connection,
            List<string> fields,
            string where,
            object parameters = null,
            IDbTransaction transaction = null,
            int? commandTimeout = null,
            CommandType? commandType = null) where T : class, new()
        {
            string tableName = GetAttributeTableName<T>();
            string sql = $"SELECT {string.Join(",", fields)} FROM {tableName} {where}";

            return connection.Query<T>(sql, parameters, transaction: transaction, commandTimeout: commandTimeout, commandType: commandType);
        }

        #region 公共方法

        /// <summary>
        /// Get Table Name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static string GetAttributeTableName<T>()
        {
            TableAttribute attribute = (TableAttribute)typeof(T).GetCustomAttributes(typeof(TableAttribute), true)[0];

            if (attribute != null)
            {
                return attribute.Name;
            }
            else
            {
                return typeof(T).Name;
            }
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
        public static bool Update<T>(this IDbConnection connection, T entityToUpdate, IDbTransaction transaction = null) where T : class
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
            var updated = connection.Execute(sb.ToString(), entityToUpdate, transaction: transaction);
            return updated > 0;
        }

        /// <summary>
        /// Properties
        /// </summary>
        private static readonly ConcurrentDictionary<RuntimeTypeHandle, IEnumerable<PropertyInfo>> KeyProperties = new ConcurrentDictionary<RuntimeTypeHandle, IEnumerable<PropertyInfo>>();
        private static readonly ConcurrentDictionary<RuntimeTypeHandle, IEnumerable<PropertyInfo>> TypeProperties = new ConcurrentDictionary<RuntimeTypeHandle, IEnumerable<PropertyInfo>>();
        private static readonly ConcurrentDictionary<RuntimeTypeHandle, IEnumerable<PropertyInfo>> ComputedProperties = new ConcurrentDictionary<RuntimeTypeHandle, IEnumerable<PropertyInfo>>();
        private static readonly ConcurrentDictionary<RuntimeTypeHandle, IEnumerable<PropertyInfo>> ExplicitKeyProperties = new ConcurrentDictionary<RuntimeTypeHandle, IEnumerable<PropertyInfo>>();
        private static readonly ConcurrentDictionary<RuntimeTypeHandle, IEnumerable<PropertyInfo>> UpdateIgnoreProperties = new ConcurrentDictionary<RuntimeTypeHandle, IEnumerable<PropertyInfo>>();
        private static readonly ConcurrentDictionary<RuntimeTypeHandle, string> TypeTableName = new ConcurrentDictionary<RuntimeTypeHandle, string>();

        private static readonly ISqlAdapter DefaultAdapter = new SqlServerAdapter();
        private static readonly Dictionary<string, ISqlAdapter> AdapterDictionary
            = new Dictionary<string, ISqlAdapter>
            {
                ["sqlconnection"] = new SqlServerAdapter(),
                ["sqlceconnection"] = new SqlCeServerAdapter(),
                ["npgsqlconnection"] = new PostgresAdapter(),
                ["sqliteconnection"] = new SQLiteAdapter(),
                ["mysqlconnection"] = new MySqlAdapter(),
                ["fbconnection"] = new FbAdapter()
            };

        private static List<PropertyInfo> KeyPropertiesCache(Type type)
        {
            if (KeyProperties.TryGetValue(type.TypeHandle, out IEnumerable<PropertyInfo> pi))
            {
                return pi.ToList();
            }

            var allProperties = TypePropertiesCache(type);
            var keyProperties = allProperties.Where(p => p.GetCustomAttributes(true).Any(a => a is KeyAttribute)).ToList();

            if (keyProperties.Count == 0)
            {
                var idProp = allProperties.Find(p => string.Equals(p.Name, "id", StringComparison.CurrentCultureIgnoreCase));
                if (idProp != null && !idProp.GetCustomAttributes(true).Any(a => a is ExplicitKeyAttribute))
                {
                    keyProperties.Add(idProp);
                }
            }

            KeyProperties[type.TypeHandle] = keyProperties;
            return keyProperties;
        }

        private static List<PropertyInfo> ExplicitKeyPropertiesCache(Type type)
        {
            if (ExplicitKeyProperties.TryGetValue(type.TypeHandle, out IEnumerable<PropertyInfo> pi))
            {
                return pi.ToList();
            }

            var explicitKeyProperties = TypePropertiesCache(type).Where(p => p.GetCustomAttributes(true).Any(a => a is ExplicitKeyAttribute)).ToList();

            ExplicitKeyProperties[type.TypeHandle] = explicitKeyProperties;
            return explicitKeyProperties;
        }

        private static List<PropertyInfo> TypePropertiesCache(Type type)
        {
            if (TypeProperties.TryGetValue(type.TypeHandle, out IEnumerable<PropertyInfo> pis))
            {
                return pis.ToList();
            }

            var properties = type.GetProperties().Where(IsWriteable).ToArray();
            TypeProperties[type.TypeHandle] = properties;
            return properties.ToList();
        }

        private static bool IsWriteable(PropertyInfo pi)
        {
            var attributes = pi.GetCustomAttributes(typeof(WriteAttribute), false).AsList();
            if (attributes.Count != 1) return true;

            var writeAttribute = (WriteAttribute)attributes[0];
            return writeAttribute.Write;
        }

        private static List<PropertyInfo> ComputedPropertiesCache(Type type)
        {
            if (ComputedProperties.TryGetValue(type.TypeHandle, out IEnumerable<PropertyInfo> pi))
            {
                return pi.ToList();
            }

            var computedProperties = TypePropertiesCache(type).Where(p => p.GetCustomAttributes(true).Any(a => a is ComputedAttribute)).ToList();

            ComputedProperties[type.TypeHandle] = computedProperties;
            return computedProperties;
        }

        private static List<PropertyInfo> UpdateIgnorePropertiesCache(Type type)
        {
            if (UpdateIgnoreProperties.TryGetValue(type.TypeHandle, out IEnumerable<PropertyInfo> pi))
            {
                return pi.ToList();
            }

            var updateIgnoreProperties = TypePropertiesCache(type).Where(p => p.GetCustomAttributes(true).Any(a => a is IgnoreUpdateAttribute)).ToList();

            UpdateIgnoreProperties[type.TypeHandle] = updateIgnoreProperties;
            return updateIgnoreProperties;
        }

        private static string GetTableName(Type type)
        {
            if (TypeTableName.TryGetValue(type.TypeHandle, out string name)) return name;

            if (TableNameMapper != null)
            {
                name = TableNameMapper(type);
            }
            else
            {
#if NETSTANDARD1_3
                var info = type.GetTypeInfo();
#else
                var info = type;
#endif
                //NOTE: This as dynamic trick falls back to handle both our own Table-attribute as well as the one in EntityFramework 
                var tableAttrName =
                    info.GetCustomAttribute<TableAttribute>(false)?.Name
                    ?? (info.GetCustomAttributes(false).FirstOrDefault(attr => attr.GetType().Name == "TableAttribute") as dynamic)?.Name;

                if (tableAttrName != null)
                {
                    name = tableAttrName;
                }
                else
                {
                    name = type.Name + "s";
                    if (type.IsInterface() && name.StartsWith("I"))
                        name = name.Substring(1);
                }
            }

            TypeTableName[type.TypeHandle] = name;
            return name;
        }

        private static ISqlAdapter GetFormatter(IDbConnection connection)
        {
            var name = GetDatabaseType?.Invoke(connection).ToLower()
                       ?? connection.GetType().Name.ToLower();

            return !AdapterDictionary.ContainsKey(name)
                ? DefaultAdapter
                : AdapterDictionary[name];
        }
    }

    internal static class TypeExtensions
    {
        public static bool IsGenericType(this Type type) =>
#if NETSTANDARD1_3 || NETCOREAPP3_1
            type.GetTypeInfo().IsGenericType;
#else
            type.IsGenericType;
#endif
        public static bool IsInterface(this Type type) =>
#if NETSTANDARD1_3 || NETCOREAPP3_1
            type.GetTypeInfo().IsInterface;
#else
            type.IsInterface;
#endif
    }

    #endregion
}
