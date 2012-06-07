using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace TypeScanner
{
    public class TypeScanner : ITypeScanner
    {
        public List<Type> GetTypesOf<T>()
        {
            var assemblies = GetLocalAssemblies();
            var manyTypes = assemblies
                .SelectMany(x => x.GetTypes());

            return manyTypes
                .Where(x => typeof (T).IsAssignableFrom(x)
                            && x.IsClass)
                .Where(x => x != typeof (T))
                .ToList();
        }

        static IEnumerable<Assembly> GetLocalAssemblies()
        {
            Assembly callingAssembly = Assembly.GetCallingAssembly();
            string path = new Uri(Path.GetDirectoryName(callingAssembly.CodeBase)).AbsolutePath;

            return AppDomain.CurrentDomain.GetAssemblies()
                .Where(x => !x.IsDynamic && new Uri(x.CodeBase).AbsolutePath.Contains(path)).ToList();
        }        
    }
}