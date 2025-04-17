using System;
using System.Collections.Generic;

namespace GDFEditor
{
    public class TypeHierarchy
    {
        public Type type;
        public List<TypeHierarchy> children;

        public TypeHierarchy(Type type)
        {
            this.type = type;
            children = new List<TypeHierarchy>();
        }
    }
}
