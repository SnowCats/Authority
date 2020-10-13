using System;
using System.Reflection;
using System.Runtime.Loader;

namespace Auth.Core.Utility
{
    /// <summary>
    /// 系统框架基础方法类
    /// </summary>
    public class BaseUtility
    {
        /// <summary>
        /// Get Assembly
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        public static Assembly GetAssembly(string assemblyName)
        {
            Assembly assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(AppContext.BaseDirectory + $"{assemblyName}.dll");
            return assembly;
        }
    }
}
