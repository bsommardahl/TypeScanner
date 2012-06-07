using System;
using System.Collections.Generic;

namespace TypeScanner
{
    public interface ITypeScanner
    {
        List<Type> GetTypesOf<T>();
    }
}