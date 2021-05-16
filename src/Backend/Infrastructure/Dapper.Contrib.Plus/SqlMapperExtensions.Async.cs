using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Dapper.Contrib.Plus
{
    /// <summary>
    /// The Dapper.Contrib.Plus extensions for Dapper.Contrib
    /// </summary>
    public static partial class SqlMapperExtensions
    {
        /// <summary>
        /// Returns a single entity by a single id from table "Ts" asynchronously using Task. T must be of interface type. 
        /// Id must be marked with [Key] attribute.
        /// Created entity is tracked/intercepted for changes and used by the Update() extension. 
        /// </summary>
        /// <typeparam name="T">Interface type to create and populate</typeparam>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="id">Id of the entity to get, must be marked with [Key] attribute</param>
        /// <param name="transaction">The transaction to run under, null (the default) if none</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <returns>Entity of T</returns>
        public static async Task<T> GetAsync<T>(this IDbConnection connection, dynamic id, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            var type = typeof(T);
            if (!GetQueries.TryGetValue(type.TypeHandle, out string sql))
            {
                var key = GetSingleKey<T>(nameof(GetAsync));
                var name = GetTableName(type);

                sql = $"SELECT * FROM {name} WHERE {key.Name} = @id";
                GetQueries[type.TypeHandle] = sql;
            }

            var dynParams = new DynamicParameters();
            dynParams.Add("@id", id);

            if (!type.IsInterface)
                return (await connection.QueryAsync<T>(sql, dynParams, transaction, commandTimeout).ConfigureAwait(false)).FirstOrDefault();

            if (!((await connection.QueryAsync<dynamic>(sql, dynParams).ConfigureAwait(false)).FirstOrDefault() is IDictionary<string, object> res))
            {
                return null;
            }

            var obj = ProxyGenerator.GetInterfaceProxy<T>();

            foreach (var property in TypePropertiesCache(type))
            {
                var val = res[property.Name];
                if (val == null) continue;
                if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    var genericType = Nullable.GetUnderlyingType(property.PropertyType);
                    if (genericType != null) property.SetValue(obj, Convert.ChangeType(val, genericType), null);
                }
                else
                {
                    property.SetValue(obj, Convert.ChangeType(val, property.PropertyType), null);
                }
            }

            ((IProxy)obj).IsDirty = false;   //reset change tracking and return

            return obj;
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="keyValuePairs"></param>
        /// <param name="expression"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> GetListAsync<T>(this IDbConnection connection,
            IList<Condition> conditions = null,
            Expression<Func<T, dynamic>> columnExp = null,
            IDbTransaction transaction = null, int? commandTimeout = null) where T : class, new()
        {
            var name = GetTableName(typeof(T));
            var adapter = GetFormatter(connection);
            var columns = new StringBuilder();
            var query = new StringBuilder();
            IDictionary<string, object> parameters = new ExpandoObject();

            // 查询返回的列名
            if (columnExp != null)
            {
                for (int i = 0; i < ((NewExpression)columnExp.Body).Members.Count; i++)
                {
                    adapter.AppendColumnName(columns, ((NewExpression)columnExp.Body).Members[i].Name);
                    if (i < ((NewExpression)columnExp.Body).Members.Count - 1)
                        columns.Append(", ");
                }
            }
            else
            {
                columns.Append("*");
            }

            // 查询条件
            foreach(var item in conditions)
            {
                adapter.AppendColumnNameEqualsValue(query, item.Name, item.Type);
                parameters.Add(item.Name, item.Value);
            }

            string sql = $"select {columns} from {name} where 1=1 {query}";

            return await connection.QueryAsync<T>(sql, param: parameters, transaction: transaction, commandTimeout: commandTimeout);
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="connection"></param>
        /// <param name="model"></param>
        /// <param name="fields"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<TEntity>> GetListAsync<TEntity, TModel>(
            this IDbConnection connection,
            TModel model = null,
            Expression<Func<TEntity, dynamic>> columnExp = null,
            IDbTransaction transaction = null,
            int? commandTimeout = null)
            where TEntity : class, new()
            where TModel : class, new()
        {
            var name = GetTableName(typeof(TEntity));
            var columns = new StringBuilder();
            var allProperties = TypePropertiesCache(typeof(TModel)).Where(p => p.GetCustomAttributes(true).Any(a => a is ConditionalAttribute)).ToList();
            var query = new StringBuilder();
            var adapter = GetFormatter(connection);
            IDictionary<string, object> parameters = new ExpandoObject();

            // 查询返回的列名
            if (columnExp != null)
            {
                for (int i = 0; i < ((NewExpression)columnExp.Body).Members.Count; i++)
                {
                    adapter.AppendColumnName(columns, ((NewExpression)columnExp.Body).Members[i].Name);
                    if (i < ((NewExpression)columnExp.Body).Members.Count - 1)
                        columns.Append(", ");
                }
            }
            else
            {
                columns.Append("*");
            }

            // 查询条件
            for (int i = 0; i < allProperties.Count(); i++)
            {
                string propertyName;
                ConditionalType conditionalType;
                if (allProperties[i].GetCustomAttribute<FieldNameAttribute>() == null)
                {
                    propertyName = allProperties[i].Name;
                }
                else
                {
                    propertyName = allProperties[i].GetCustomAttribute<FieldNameAttribute>().Name;
                }

                if (allProperties[i].GetCustomAttribute<ConditionalAttribute>() == null)
                {
                    // If object is list or array. Set default conditionalType
                    if (allProperties[i].PropertyType.IsArray || allProperties[i].PropertyType.IsGenericType)
                    {
                        conditionalType = ConditionalType.In;
                    }
                    else
                    {
                        conditionalType = ConditionalType.Equal;
                    }
                }
                else
                {
                    conditionalType = allProperties[i].GetCustomAttribute<ConditionalAttribute>().ConditionalType;
                }

                if (allProperties[i].GetValue(model, null) != null && !string.IsNullOrWhiteSpace(allProperties[i].GetValue(model, null).ToString()))
                {
                    adapter.AppendColumnNameEqualsValue(query, propertyName, conditionalType);

                    parameters.Add(propertyName, allProperties[i].GetValue(model, null));
                }
            }

            string sql = $"select {columns} from {name} where 1=1 {query}";

            return await connection.QueryAsync<TEntity>(sql, parameters, transaction, commandTimeout: commandTimeout);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="TEntity">实体类</typeparam>
        /// <typeparam name="TModel">查询类</typeparam>
        /// <param name="connection">数据库对象</param>
        /// <param name="page">页数</param>
        /// <param name="itemsPerPage">每页条数</param>
        /// <param name="keyValuePairs">查询条件</param>
        /// <param name="expression">查询字段</param>
        /// <param name="defaultField"></param>
        /// <param name="orderBy"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<TEntity>> GetPagedListAsync<TEntity, TModel>(
            this IDbConnection connection,
            int page,
            int itemsPerPage,
            TModel model,
            Expression<Func<TEntity, dynamic>> columnExp = null,
            string defaultField = "timestamp",
            string orderBy = "timestamp desc",
            IDbTransaction transaction = null,
            int? commandTimeout = null)
            where TEntity : class, new()
            where TModel : class, new()
        {
            var name = GetTableName(typeof(TEntity));
            var columns = new StringBuilder();
            var allProperties = TypePropertiesCache(typeof(TModel)).Where(p => p.GetCustomAttributes(true).Any(a => a is ConditionalAttribute)).ToList();
            var query = new StringBuilder();
            var adapter = GetFormatter(connection);
            IDictionary<string, object> parameters = new ExpandoObject();

            // 查询返回的列名
            if (columnExp != null)
            {
                // 参数
                for (int i = 0; i < ((NewExpression)columnExp.Body).Members.Count; i++)
                {
                    adapter.AppendColumnName(columns, ((NewExpression)columnExp.Body).Members[i].Name);
                    if (i < ((NewExpression)columnExp.Body).Members.Count - 1)
                        columns.Append(", ");
                }
            }
            else
            {
                columns.Append("*");
            }

            // 查询条件
            for (int i = 0; i < allProperties.Count(); i++)
            {
                string propertyName;
                ConditionalType conditionalType;
                if (allProperties[i].GetCustomAttribute<FieldNameAttribute>() == null)
                {
                    propertyName = allProperties[i].Name;
                }
                else
                {
                    propertyName = allProperties[i].GetCustomAttribute<FieldNameAttribute>().Name;
                }

                if (allProperties[i].GetCustomAttribute<ConditionalAttribute>() == null)
                {
                    // If object is list or array. Set default conditionalType
                    if (allProperties[i].PropertyType.IsArray || allProperties[i].PropertyType.IsGenericType)
                    {
                        conditionalType = ConditionalType.In;
                    }
                    else
                    {
                        conditionalType = ConditionalType.Equal;
                    }
                }
                else
                {
                    conditionalType = allProperties[i].GetCustomAttribute<ConditionalAttribute>().ConditionalType;
                }

                if (allProperties[i].GetValue(model, null) != null && !string.IsNullOrWhiteSpace(allProperties[i].GetValue(model, null).ToString()))
                {
                    adapter.AppendColumnNameEqualsValue(query, propertyName, conditionalType);

                    parameters.Add(propertyName, allProperties[i].GetValue(model, null));
                }
            }

            // mysql数据库, 需要改为适配所有数据库
            long timestamp = (long)await connection.ExecuteScalarAsync($"select ifnull(min({defaultField}), unix_timestamp()) from {name} where 1=1 {query} order by {orderBy} limit {(page - 1) * itemsPerPage}, 1",
                parameters, transaction, commandTimeout);
            var list = await connection.QueryAsync<TEntity>($"select {columns} from {name} where 1=1 {query} and {defaultField} >= {timestamp} order by {orderBy} limit {(page - 1) * itemsPerPage}, {itemsPerPage}",
                parameters, transaction, commandTimeout: commandTimeout);

            return list;
        }

        /// <summary>
        /// 查询记录总数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="keyValuePairs"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public static async Task<long> CountAsync<TEntity, TModel>(
            this IDbConnection connection,
            TModel model,
            IDbTransaction transaction = null,
            int? commandTimeout = null)
            where TEntity : class, new()
            where TModel : class, new()
        {
            var name = GetTableName(typeof(TEntity));
            var allProperties = TypePropertiesCache(typeof(TModel)).Where(p => p.GetCustomAttributes(true).Any(a => a is ConditionalAttribute)).ToList();
            var query = new StringBuilder();
            var adapter = GetFormatter(connection);
            IDictionary<string, object> parameters = new ExpandoObject();

            // 查询条件
            for (int i = 0; i < allProperties.Count(); i++)
            {
                string propertyName;
                ConditionalType conditionalType;
                if (allProperties[i].GetCustomAttribute<FieldNameAttribute>() == null)
                {
                    propertyName = allProperties[i].Name;
                }
                else
                {
                    propertyName = allProperties[i].GetCustomAttribute<FieldNameAttribute>().Name;
                }

                if (allProperties[i].GetCustomAttribute<ConditionalAttribute>() == null)
                {
                    // If object is list or array. Set default conditionalType
                    if (allProperties[i].PropertyType.IsArray || allProperties[i].PropertyType.IsGenericType)
                    {
                        conditionalType = ConditionalType.In;
                    }
                    else
                    {
                        conditionalType = ConditionalType.Equal;
                    }
                }
                else
                {
                    conditionalType = allProperties[i].GetCustomAttribute<ConditionalAttribute>().ConditionalType;
                }

                if (allProperties[i].GetValue(model, null) != null && !string.IsNullOrWhiteSpace(allProperties[i].GetValue(model, null).ToString()))
                {
                    adapter.AppendColumnNameEqualsValue(query, propertyName, conditionalType);

                    parameters.Add(propertyName, allProperties[i].GetValue(model, null));
                }
            }

            long count = (long)await connection.ExecuteScalarAsync($"select count(*) from {name} where 1=1 {query}", parameters, transaction, commandTimeout);

            return count;
        }

        #region （Obsolete）弃用分页方法
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="connection">数据库对象</param>
        /// <param name="page">页数</param>
        /// <param name="itemsPerPage">每页条数</param>
        /// <param name="keyValuePairs">查询条件</param>
        /// <param name="expression">查询字段</param>
        /// <param name="defaultField"></param>
        /// <param name="orderBy"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> GetPagedListAsync<T>(
            this IDbConnection connection,
            int page,
            int itemsPerPage,
            IList<KeyValuePair<KeyValuePair<string, dynamic>, ConditionalType>> keyValuePairs,
            Expression<Func<T, dynamic>> columnExp = null,
            string defaultField = "timestamp",
            string orderBy = "timestamp desc",
            IDbTransaction transaction = null,
            int? commandTimeout = null)
            where T : class, new()
        {
            var name = GetTableName(typeof(T));
            var adapter = GetFormatter(connection);
            var columns = new StringBuilder();
            var query = new StringBuilder();
            IDictionary<string, object> parameters = new ExpandoObject();

            // 查询返回的列名
            if (columnExp != null)
            {
                // 参数
                for (int i = 0; i < ((NewExpression)columnExp.Body).Members.Count; i++)
                {
                    adapter.AppendColumnName(columns, ((NewExpression)columnExp.Body).Members[i].Name);
                    if (i < ((NewExpression)columnExp.Body).Members.Count - 1)
                        columns.Append(", ");
                }
            }
            else
            {
                columns.Append("*");
            }

            // 参数
            if (keyValuePairs != null)
            {
                // 参数
                for (int i = 0; i < keyValuePairs.Count(); i++)
                {
                    adapter.AppendColumnNameEqualsValue(query, keyValuePairs[i].Key.Key, keyValuePairs[i].Value);
                    parameters.Add(keyValuePairs[i].Key.Key, keyValuePairs[i].Key.Value);
                }
            }

            // mysql数据库, 需要改为适配所有数据库
            long timestamp = (long)await connection.ExecuteScalarAsync($"select ifnull(min({defaultField}), unix_timestamp()) from {name} where 1=1 {query} order by {orderBy} limit {(page - 1) * itemsPerPage}, 1",
                parameters, transaction, commandTimeout);
            var list = await connection.QueryAsync<T>($"select {columns} from {name} where 1=1 {query} and {defaultField} >= {timestamp} order by {orderBy} limit {(page - 1) * itemsPerPage}, {itemsPerPage}",
                parameters, transaction, commandTimeout: commandTimeout);

            return list;
        }

        /// <summary>
        /// 查询记录总数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="keyValuePairs"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public static async Task<long> CountAsync<T>(
            this IDbConnection connection,
            IList<KeyValuePair<KeyValuePair<string, dynamic>, ConditionalType>> keyValuePairs,
            IDbTransaction transaction = null,
            int? commandTimeout = null)
            where T : class, new()
        {
            var name = GetTableName(typeof(T));
            var adapter = GetFormatter(connection);
            var query = new StringBuilder();
            IDictionary<string, object> parameters = new ExpandoObject();

            // 参数
            if (keyValuePairs != null)
            {
                // 参数
                for (int i = 0; i < keyValuePairs.Count(); i++)
                {
                    adapter.AppendColumnNameEqualsValue(query, keyValuePairs[i].Key.Key, keyValuePairs[i].Value);
                    parameters.Add(keyValuePairs[i].Key.Key, keyValuePairs[i].Key.Value);
                }
            }

            long count = (long)await connection.ExecuteScalarAsync($"select count(*) from {name} where 1=1 {query}", parameters, transaction, commandTimeout);

            return count;
        }

        #endregion

        /// <summary>
        /// Update any field
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<bool> UpdateAnyAsync<T>(
            IDbConnection connection,
            Expression<Func<T, dynamic>> columnExp,
            Expression<Func<T, dynamic>> queryExp,
            object parameters,
            IDbTransaction transaction = null, int? commandTimeout = null)
        {
            var name = GetTableName(typeof(T));
            var columns = new StringBuilder();
            var query = new StringBuilder();
            var adapter = GetFormatter(connection);

            if (columnExp != null)
            {
                for (int i = 0; i < ((NewExpression)columnExp.Body).Members.Count; i++)
                {
                    adapter.AppendColumnNameEqualsValue(columns, ((NewExpression)columnExp.Body).Members[i].Name);
                    if (i < ((NewExpression)columnExp.Body).Members.Count - 1)
                        columns.Append(", ");
                }
            }
            else
            {
                throw new Exception("parameter 'expression' can not be null");
            }

            if (queryExp != null)
            {
                for (int i = 0; i < ((NewExpression)queryExp.Body).Members.Count; i++)
                {
                    adapter.AppendColumnNameEqualsValue(query, ((NewExpression)queryExp.Body).Members[i].Name);
                    if (i < ((NewExpression)queryExp.Body).Members.Count - 1)
                        query.Append(" and ");
                }
            }

            string sql = $"update {name} set {columns} where 1=1 {query}";

            var result = await connection.ExecuteAsync(sql, parameters, transaction, commandTimeout);

            return result > 0;
        }


        /// <summary>
        /// Delete by any conditions
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="conditions"></param>
        /// <param name="parameters"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        public static async Task<bool> DeleteAnyAsync<T>(
            IDbConnection connection,
            Expression<Func<T, dynamic>> queryExp,
            object parameters,
            IDbTransaction transaction,
            int? commandTimeout = null)
        {
            var name = GetTableName(typeof(T));
            var query = new StringBuilder();
            var adapter = GetFormatter(connection);
            if (queryExp != null)
            {
                for (int i = 0; i < ((NewExpression)queryExp.Body).Members.Count; i++)
                {
                    adapter.AppendColumnNameEqualsValue(query, ((NewExpression)queryExp.Body).Members[i].Name);
                    if (i < ((NewExpression)queryExp.Body).Members.Count - 1)
                        query.Append(" and ");
                }
            }

            string sql = $"delete from {name} where 1=1 {query}";
            var result = await connection.ExecuteAsync(sql, parameters, transaction, commandTimeout);

            return result > 0;
        }

        /// <summary>
        /// Returns a list of entities from table "Ts".  
        /// Id of T must be marked with [Key] attribute.
        /// Entities created from interfaces are tracked/intercepted for changes and used by the Update() extension
        /// for optimal performance. 
        /// </summary>
        /// <typeparam name="T">Interface or type to create and populate</typeparam>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="transaction">The transaction to run under, null (the default) if none</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <returns>Entity of T</returns>
        public static Task<IEnumerable<T>> GetAllAsync<T>(this IDbConnection connection, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            var type = typeof(T);
            var cacheType = typeof(List<T>);

            if (!GetQueries.TryGetValue(cacheType.TypeHandle, out string sql))
            {
                GetSingleKey<T>(nameof(GetAll));
                var name = GetTableName(type);

                sql = "SELECT * FROM " + name;
                GetQueries[cacheType.TypeHandle] = sql;
            }

            if (!type.IsInterface)
            {
                return connection.QueryAsync<T>(sql, null, transaction, commandTimeout);
            }
            return GetAllAsyncImpl<T>(connection, transaction, commandTimeout, sql, type);
        }

        private static async Task<IEnumerable<T>> GetAllAsyncImpl<T>(IDbConnection connection, IDbTransaction transaction, int? commandTimeout, string sql, Type type) where T : class
        {
            var result = await connection.QueryAsync(sql, transaction: transaction, commandTimeout: commandTimeout).ConfigureAwait(false);
            var list = new List<T>();
            foreach (IDictionary<string, object> res in result)
            {
                var obj = ProxyGenerator.GetInterfaceProxy<T>();
                foreach (var property in TypePropertiesCache(type))
                {
                    var val = res[property.Name];
                    if (val == null) continue;
                    if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        var genericType = Nullable.GetUnderlyingType(property.PropertyType);
                        if (genericType != null) property.SetValue(obj, Convert.ChangeType(val, genericType), null);
                    }
                    else
                    {
                        property.SetValue(obj, Convert.ChangeType(val, property.PropertyType), null);
                    }
                }
                ((IProxy)obj).IsDirty = false;   //reset change tracking and return
                list.Add(obj);
            }
            return list;
        }

        /// <summary>
        /// Inserts an entity into table "Ts" asynchronously using Task and returns identity id.
        /// </summary>
        /// <typeparam name="T">The type being inserted.</typeparam>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="entityToInsert">Entity to insert</param>
        /// <param name="transaction">The transaction to run under, null (the default) if none</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <param name="sqlAdapter">The specific ISqlAdapter to use, auto-detected based on connection if null</param>
        /// <returns>Identity of inserted entity</returns>
        public static Task<int> InsertAsync<T>(this IDbConnection connection, T entityToInsert, IDbTransaction transaction = null,
            int? commandTimeout = null, ISqlAdapter sqlAdapter = null) where T : class
        {
            var type = typeof(T);
            sqlAdapter ??= GetFormatter(connection);

            var isList = false;
            if (type.IsArray)
            {
                isList = true;
                type = type.GetElementType();
            }
            else if (type.IsGenericType)
            {
                var typeInfo = type.GetTypeInfo();
                bool implementsGenericIEnumerableOrIsGenericIEnumerable =
                    typeInfo.ImplementedInterfaces.Any(ti => ti.IsGenericType && ti.GetGenericTypeDefinition() == typeof(IEnumerable<>)) ||
                    typeInfo.GetGenericTypeDefinition() == typeof(IEnumerable<>);

                if (implementsGenericIEnumerableOrIsGenericIEnumerable)
                {
                    isList = true;
                    type = type.GetGenericArguments()[0];
                }
            }

            var name = GetTableName(type);
            var sbColumnList = new StringBuilder(null);
            var allProperties = TypePropertiesCache(type);
            var keyProperties = KeyPropertiesCache(type).ToList();
            var computedProperties = ComputedPropertiesCache(type);
            var allPropertiesExceptKeyAndComputed = allProperties.Except(keyProperties.Union(computedProperties)).ToList();

            for (var i = 0; i < allPropertiesExceptKeyAndComputed.Count; i++)
            {
                var property = allPropertiesExceptKeyAndComputed[i];
                sqlAdapter.AppendColumnName(sbColumnList, property.Name);
                if (i < allPropertiesExceptKeyAndComputed.Count - 1)
                    sbColumnList.Append(", ");
            }

            var sbParameterList = new StringBuilder(null);
            for (var i = 0; i < allPropertiesExceptKeyAndComputed.Count; i++)
            {
                var property = allPropertiesExceptKeyAndComputed[i];
                sbParameterList.AppendFormat("@{0}", property.Name);
                if (i < allPropertiesExceptKeyAndComputed.Count - 1)
                    sbParameterList.Append(", ");
            }

            if (!isList)    //single entity
            {
                return sqlAdapter.InsertAsync(connection, transaction, commandTimeout, name, sbColumnList.ToString(),
                    sbParameterList.ToString(), keyProperties, entityToInsert);
            }

            //insert list of entities
            var cmd = $"INSERT INTO {name} ({sbColumnList}) values ({sbParameterList})";
            return connection.ExecuteAsync(cmd, entityToInsert, transaction, commandTimeout);
        }

        /// <summary>
        /// Updates entity in table "Ts" asynchronously using Task, checks if the entity is modified if the entity is tracked by the Get() extension.
        /// </summary>
        /// <typeparam name="T">Type to be updated</typeparam>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="entityToUpdate">Entity to be updated</param>
        /// <param name="transaction">The transaction to run under, null (the default) if none</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <returns>true if updated, false if not found or not modified (tracked entities)</returns>
        public static async Task<bool> UpdateAsync<T>(this IDbConnection connection, T entityToUpdate, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            if ((entityToUpdate is IProxy proxy) && !proxy.IsDirty)
            {
                return false;
            }

            var type = typeof(T);

            if (type.IsArray)
            {
                type = type.GetElementType();
            }
            else if (type.IsGenericType)
            {
                var typeInfo = type.GetTypeInfo();
                bool implementsGenericIEnumerableOrIsGenericIEnumerable =
                    typeInfo.ImplementedInterfaces.Any(ti => ti.IsGenericType && ti.GetGenericTypeDefinition() == typeof(IEnumerable<>)) ||
                    typeInfo.GetGenericTypeDefinition() == typeof(IEnumerable<>);

                if (implementsGenericIEnumerableOrIsGenericIEnumerable)
                {
                    type = type.GetGenericArguments()[0];
                }
            }

            var keyProperties = KeyPropertiesCache(type).ToList();
            var explicitKeyProperties = ExplicitKeyPropertiesCache(type);
            if (keyProperties.Count == 0 && explicitKeyProperties.Count == 0)
                throw new ArgumentException("Entity must have at least one [Key] or [ExplicitKey] property");

            var name = GetTableName(type);

            var sb = new StringBuilder();
            sb.AppendFormat("update {0} set ", name);

            var allProperties = TypePropertiesCache(type);
            keyProperties.AddRange(explicitKeyProperties);
            var computedProperties = ComputedPropertiesCache(type);
            var ignoreUpdateProperties = IgnoreUpdatePropertiesCache(type);
            var nonIdProps = allProperties.Except(keyProperties.Union(computedProperties).Union(ignoreUpdateProperties)).ToList();

            var adapter = GetFormatter(connection);

            for (var i = 0; i < nonIdProps.Count; i++)
            {
                var property = nonIdProps[i];
                adapter.AppendColumnNameEqualsValue(sb, property.Name);
                if (i < nonIdProps.Count - 1)
                    sb.Append(", ");
            }
            sb.Append(" where ");
            for (var i = 0; i < keyProperties.Count; i++)
            {
                var property = keyProperties[i];
                adapter.AppendColumnNameEqualsValue(sb, property.Name);
                if (i < keyProperties.Count - 1)
                    sb.Append(" and ");
            }
            var updated = await connection.ExecuteAsync(sb.ToString(), entityToUpdate, commandTimeout: commandTimeout, transaction: transaction).ConfigureAwait(false);
            return updated > 0;
        }

        /// <summary>
        /// Delete entity in table "Ts" asynchronously using Task.
        /// </summary>
        /// <typeparam name="T">Type of entity</typeparam>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="entityToDelete">Entity to delete</param>
        /// <param name="transaction">The transaction to run under, null (the default) if none</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <returns>true if deleted, false if not found</returns>
        public static async Task<bool> DeleteAsync<T>(this IDbConnection connection, T entityToDelete, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            if (entityToDelete == null)
                throw new ArgumentException("Cannot Delete null Object", nameof(entityToDelete));

            var type = typeof(T);

            if (type.IsArray)
            {
                type = type.GetElementType();
            }
            else if (type.IsGenericType)
            {
                var typeInfo = type.GetTypeInfo();
                bool implementsGenericIEnumerableOrIsGenericIEnumerable =
                    typeInfo.ImplementedInterfaces.Any(ti => ti.IsGenericType && ti.GetGenericTypeDefinition() == typeof(IEnumerable<>)) ||
                    typeInfo.GetGenericTypeDefinition() == typeof(IEnumerable<>);

                if (implementsGenericIEnumerableOrIsGenericIEnumerable)
                {
                    type = type.GetGenericArguments()[0];
                }
            }

            var keyProperties = KeyPropertiesCache(type);
            var explicitKeyProperties = ExplicitKeyPropertiesCache(type);
            if (keyProperties.Count == 0 && explicitKeyProperties.Count == 0)
                throw new ArgumentException("Entity must have at least one [Key] or [ExplicitKey] property");

            var name = GetTableName(type);
            var allKeyProperties = keyProperties.Concat(explicitKeyProperties).ToList();

            var sb = new StringBuilder();
            sb.AppendFormat("DELETE FROM {0} WHERE ", name);

            var adapter = GetFormatter(connection);

            for (var i = 0; i < allKeyProperties.Count; i++)
            {
                var property = allKeyProperties[i];
                adapter.AppendColumnNameEqualsValue(sb, property.Name);
                if (i < allKeyProperties.Count - 1)
                    sb.Append(" AND ");
            }
            var deleted = await connection.ExecuteAsync(sb.ToString(), entityToDelete, transaction, commandTimeout).ConfigureAwait(false);
            return deleted > 0;
        }

        /// <summary>
        /// Delete all entities in the table related to the type T asynchronously using Task.
        /// </summary>
        /// <typeparam name="T">Type of entity</typeparam>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="transaction">The transaction to run under, null (the default) if none</param>
        /// <param name="commandTimeout">Number of seconds before command execution timeout</param>
        /// <returns>true if deleted, false if none found</returns>
        public static async Task<bool> DeleteAllAsync<T>(this IDbConnection connection, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            var type = typeof(T);
            var statement = "DELETE FROM " + GetTableName(type);
            var deleted = await connection.ExecuteAsync(statement, null, transaction, commandTimeout).ConfigureAwait(false);
            return deleted > 0;
        }
    }
}

public partial interface ISqlAdapter
{
    /// <summary>
    /// Inserts <paramref name="entityToInsert"/> into the database, returning the Id of the row created.
    /// </summary>
    /// <param name="connection">The connection to use.</param>
    /// <param name="transaction">The transaction to use.</param>
    /// <param name="commandTimeout">The command timeout to use.</param>
    /// <param name="tableName">The table to insert into.</param>
    /// <param name="columnList">The columns to set with this insert.</param>
    /// <param name="parameterList">The parameters to set for this insert.</param>
    /// <param name="keyProperties">The key columns in this table.</param>
    /// <param name="entityToInsert">The entity to insert.</param>
    /// <returns>The Id of the row created.</returns>
    Task<int> InsertAsync(IDbConnection connection, IDbTransaction transaction, int? commandTimeout, string tableName, string columnList, string parameterList, IEnumerable<PropertyInfo> keyProperties, object entityToInsert);
}

public partial class SqlServerAdapter
{
    /// <summary>
    /// Inserts <paramref name="entityToInsert"/> into the database, returning the Id of the row created.
    /// </summary>
    /// <param name="connection">The connection to use.</param>
    /// <param name="transaction">The transaction to use.</param>
    /// <param name="commandTimeout">The command timeout to use.</param>
    /// <param name="tableName">The table to insert into.</param>
    /// <param name="columnList">The columns to set with this insert.</param>
    /// <param name="parameterList">The parameters to set for this insert.</param>
    /// <param name="keyProperties">The key columns in this table.</param>
    /// <param name="entityToInsert">The entity to insert.</param>
    /// <returns>The Id of the row created.</returns>
    public async Task<int> InsertAsync(IDbConnection connection, IDbTransaction transaction, int? commandTimeout, string tableName, string columnList, string parameterList, IEnumerable<PropertyInfo> keyProperties, object entityToInsert)
    {
        var cmd = $"INSERT INTO {tableName} ({columnList}) values ({parameterList}); SELECT SCOPE_IDENTITY() id";
        var multi = await connection.QueryMultipleAsync(cmd, entityToInsert, transaction, commandTimeout).ConfigureAwait(false);

        var first = await multi.ReadFirstOrDefaultAsync().ConfigureAwait(false);
        if (first == null || first.id == null) return 0;

        var id = (int)first.id;
        var pi = keyProperties as PropertyInfo[] ?? keyProperties.ToArray();
        if (pi.Length == 0) return id;

        var idp = pi[0];
        idp.SetValue(entityToInsert, Convert.ChangeType(id, idp.PropertyType), null);

        return id;
    }
}

public partial class SqlCeServerAdapter
{
    /// <summary>
    /// Inserts <paramref name="entityToInsert"/> into the database, returning the Id of the row created.
    /// </summary>
    /// <param name="connection">The connection to use.</param>
    /// <param name="transaction">The transaction to use.</param>
    /// <param name="commandTimeout">The command timeout to use.</param>
    /// <param name="tableName">The table to insert into.</param>
    /// <param name="columnList">The columns to set with this insert.</param>
    /// <param name="parameterList">The parameters to set for this insert.</param>
    /// <param name="keyProperties">The key columns in this table.</param>
    /// <param name="entityToInsert">The entity to insert.</param>
    /// <returns>The Id of the row created.</returns>
    public async Task<int> InsertAsync(IDbConnection connection, IDbTransaction transaction, int? commandTimeout, string tableName, string columnList, string parameterList, IEnumerable<PropertyInfo> keyProperties, object entityToInsert)
    {
        var cmd = $"INSERT INTO {tableName} ({columnList}) VALUES ({parameterList})";
        await connection.ExecuteAsync(cmd, entityToInsert, transaction, commandTimeout).ConfigureAwait(false);
        var r = (await connection.QueryAsync<dynamic>("SELECT @@IDENTITY id", transaction: transaction, commandTimeout: commandTimeout).ConfigureAwait(false)).ToList();

        if (r[0] == null || r[0].id == null) return 0;
        var id = (int)r[0].id;

        var pi = keyProperties as PropertyInfo[] ?? keyProperties.ToArray();
        if (pi.Length == 0) return id;

        var idp = pi[0];
        idp.SetValue(entityToInsert, Convert.ChangeType(id, idp.PropertyType), null);

        return id;
    }
}

public partial class MySqlAdapter
{
    /// <summary>
    /// Inserts <paramref name="entityToInsert"/> into the database, returning the Id of the row created.
    /// </summary>
    /// <param name="connection">The connection to use.</param>
    /// <param name="transaction">The transaction to use.</param>
    /// <param name="commandTimeout">The command timeout to use.</param>
    /// <param name="tableName">The table to insert into.</param>
    /// <param name="columnList">The columns to set with this insert.</param>
    /// <param name="parameterList">The parameters to set for this insert.</param>
    /// <param name="keyProperties">The key columns in this table.</param>
    /// <param name="entityToInsert">The entity to insert.</param>
    /// <returns>The Id of the row created.</returns>
    public async Task<int> InsertAsync(IDbConnection connection, IDbTransaction transaction, int? commandTimeout, string tableName,
        string columnList, string parameterList, IEnumerable<PropertyInfo> keyProperties, object entityToInsert)
    {
        var cmd = $"INSERT INTO {tableName} ({columnList}) VALUES ({parameterList})";
        await connection.ExecuteAsync(cmd, entityToInsert, transaction, commandTimeout).ConfigureAwait(false);
        var r = await connection.QueryAsync<dynamic>("SELECT LAST_INSERT_ID() id", transaction: transaction, commandTimeout: commandTimeout).ConfigureAwait(false);

        var id = r.First().id;
        if (id == null) return 0;
        var pi = keyProperties as PropertyInfo[] ?? keyProperties.ToArray();
        if (pi.Length == 0) return Convert.ToInt32(id);

        var idp = pi[0];
        idp.SetValue(entityToInsert, Convert.ChangeType(id, idp.PropertyType), null);

        return Convert.ToInt32(id);
    }
}

public partial class PostgresAdapter
{
    /// <summary>
    /// Inserts <paramref name="entityToInsert"/> into the database, returning the Id of the row created.
    /// </summary>
    /// <param name="connection">The connection to use.</param>
    /// <param name="transaction">The transaction to use.</param>
    /// <param name="commandTimeout">The command timeout to use.</param>
    /// <param name="tableName">The table to insert into.</param>
    /// <param name="columnList">The columns to set with this insert.</param>
    /// <param name="parameterList">The parameters to set for this insert.</param>
    /// <param name="keyProperties">The key columns in this table.</param>
    /// <param name="entityToInsert">The entity to insert.</param>
    /// <returns>The Id of the row created.</returns>
    public async Task<int> InsertAsync(IDbConnection connection, IDbTransaction transaction, int? commandTimeout, string tableName, string columnList, string parameterList, IEnumerable<PropertyInfo> keyProperties, object entityToInsert)
    {
        var sb = new StringBuilder();
        sb.AppendFormat("INSERT INTO {0} ({1}) VALUES ({2})", tableName, columnList, parameterList);

        // If no primary key then safe to assume a join table with not too much data to return
        var propertyInfos = keyProperties as PropertyInfo[] ?? keyProperties.ToArray();
        if (propertyInfos.Length == 0)
        {
            sb.Append(" RETURNING *");
        }
        else
        {
            sb.Append(" RETURNING ");
            bool first = true;
            foreach (var property in propertyInfos)
            {
                if (!first)
                    sb.Append(", ");
                first = false;
                sb.Append(property.Name);
            }
        }

        var results = await connection.QueryAsync(sb.ToString(), entityToInsert, transaction, commandTimeout).ConfigureAwait(false);

        // Return the key by assigning the corresponding property in the object - by product is that it supports compound primary keys
        var id = 0;
        foreach (var p in propertyInfos)
        {
            var value = ((IDictionary<string, object>)results.First())[p.Name.ToLower()];
            p.SetValue(entityToInsert, value, null);
            if (id == 0)
                id = Convert.ToInt32(value);
        }
        return id;
    }
}

public partial class SQLiteAdapter
{
    /// <summary>
    /// Inserts <paramref name="entityToInsert"/> into the database, returning the Id of the row created.
    /// </summary>
    /// <param name="connection">The connection to use.</param>
    /// <param name="transaction">The transaction to use.</param>
    /// <param name="commandTimeout">The command timeout to use.</param>
    /// <param name="tableName">The table to insert into.</param>
    /// <param name="columnList">The columns to set with this insert.</param>
    /// <param name="parameterList">The parameters to set for this insert.</param>
    /// <param name="keyProperties">The key columns in this table.</param>
    /// <param name="entityToInsert">The entity to insert.</param>
    /// <returns>The Id of the row created.</returns>
    public async Task<int> InsertAsync(IDbConnection connection, IDbTransaction transaction, int? commandTimeout, string tableName, string columnList, string parameterList, IEnumerable<PropertyInfo> keyProperties, object entityToInsert)
    {
        var cmd = $"INSERT INTO {tableName} ({columnList}) VALUES ({parameterList}); SELECT last_insert_rowid() id";
        var multi = await connection.QueryMultipleAsync(cmd, entityToInsert, transaction, commandTimeout).ConfigureAwait(false);

        var id = (int)(await multi.ReadFirstAsync().ConfigureAwait(false)).id;
        var pi = keyProperties as PropertyInfo[] ?? keyProperties.ToArray();
        if (pi.Length == 0) return id;

        var idp = pi[0];
        idp.SetValue(entityToInsert, Convert.ChangeType(id, idp.PropertyType), null);

        return id;
    }
}

public partial class FbAdapter
{
    /// <summary>
    /// Inserts <paramref name="entityToInsert"/> into the database, returning the Id of the row created.
    /// </summary>
    /// <param name="connection">The connection to use.</param>
    /// <param name="transaction">The transaction to use.</param>
    /// <param name="commandTimeout">The command timeout to use.</param>
    /// <param name="tableName">The table to insert into.</param>
    /// <param name="columnList">The columns to set with this insert.</param>
    /// <param name="parameterList">The parameters to set for this insert.</param>
    /// <param name="keyProperties">The key columns in this table.</param>
    /// <param name="entityToInsert">The entity to insert.</param>
    /// <returns>The Id of the row created.</returns>
    public async Task<int> InsertAsync(IDbConnection connection, IDbTransaction transaction, int? commandTimeout, string tableName, string columnList, string parameterList, IEnumerable<PropertyInfo> keyProperties, object entityToInsert)
    {
        var cmd = $"insert into {tableName} ({columnList}) values ({parameterList})";
        await connection.ExecuteAsync(cmd, entityToInsert, transaction, commandTimeout).ConfigureAwait(false);

        var propertyInfos = keyProperties as PropertyInfo[] ?? keyProperties.ToArray();
        var keyName = propertyInfos[0].Name;
        var r = await connection.QueryAsync($"SELECT FIRST 1 {keyName} ID FROM {tableName} ORDER BY {keyName} DESC", transaction: transaction, commandTimeout: commandTimeout).ConfigureAwait(false);

        var id = r.First().ID;
        if (id == null) return 0;
        if (propertyInfos.Length == 0) return Convert.ToInt32(id);

        var idp = propertyInfos[0];
        idp.SetValue(entityToInsert, Convert.ChangeType(id, idp.PropertyType), null);

        return Convert.ToInt32(id);
    }
}