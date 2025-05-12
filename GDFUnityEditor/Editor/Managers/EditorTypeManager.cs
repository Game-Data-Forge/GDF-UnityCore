using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GDFEditor;
using GDFFoundation;

namespace GDFUnity.Editor
{
    public class EditorTypeManager : RuntimeTypeManager, IEditorTypeManager
    {
        public Dictionary<string, TypeHierarchy> Player { get; private set; }

        public override void LoadRunner(IJobHandler handler)
        {
            Player = new Dictionary<string, TypeHierarchy>();

            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            handler.StepAmount = assemblies.Length;

            foreach (Assembly assembly in assemblies)
            {
                foreach(Type type in assembly.GetTypes().Where(x => x.IsClass && IsGDF(x)))
                {
                    AddType(type);
                }
                handler.Step();
            }
        }
        
        public override Type GetType(string className)
        {
            if (Player.TryGetValue(className, out TypeHierarchy type))
            {
                return type.type;
            }

            return null;
        }
        
        private void AddType (Type type)
        {
            string className = GetClassName(type);
            if (Player.ContainsKey(className))
            {
                return;
            }

            TypeHierarchy item = new TypeHierarchy(type);
            Player.Add(className, item);

            Type parent = GetParent(type);
            if (parent == null)
            {
                return;
            }

            className = GetClassName(parent);
            if (!Player.ContainsKey(className))
            {
                AddType(parent);
            }
            Player[className].children.Add(item);
        }

        private Type GetParent(Type type)
        {
            if (type.BaseType == null)
            {
                return null;
            }

            if (type.BaseType.IsGenericType)
            {
                return type.BaseType.GetGenericTypeDefinition();
            }

            return type.BaseType;
        }
    }
}