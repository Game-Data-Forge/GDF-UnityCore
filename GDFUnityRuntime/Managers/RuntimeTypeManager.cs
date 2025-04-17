using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GDFFoundation;
using GDFFoundation.Tasks;
using GDFRuntime;

namespace GDFUnity
{
    public class RuntimeTypeManager : IRuntimeTypeManager
    {
        static private readonly Type _PLAYER_DATA_TYPE = typeof(GDFPlayerData);

        private Dictionary<string, Type> _player;

        public virtual void LoadRunner(ITaskHandler handler)
        {
            _player = new Dictionary<string, Type>();

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

        public string GetClassName(Type type)
        {
            return type.FullName;
        }

        public virtual Type GetType(string className)
        {
            if (_player.TryGetValue(className, out Type type))
            {
                return type;
            }

            return null;
        }

        public bool Is(Type type, Type target)
        {
            return target.IsAssignableFrom(type);
        }

        protected bool IsGDF(Type type)
        {
            return type.IsSubclassOf(_PLAYER_DATA_TYPE);
        }

        private void AddType (Type type)
        {
            string className = GetClassName(type);
            if (_player.ContainsKey(className))
            {
                return;
            }
            _player.Add(className, type);
        }
    }
}