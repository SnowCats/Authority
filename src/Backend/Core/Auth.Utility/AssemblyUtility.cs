﻿using System;
using System.Reflection;
using System.Runtime.Loader;

namespace Auth.Utility
{
    /// <summary>
    /// 程序集工具类
    /// </summary>
    public class AssemblyUtility
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
