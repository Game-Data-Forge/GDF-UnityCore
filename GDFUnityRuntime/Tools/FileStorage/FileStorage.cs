using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace GDFUnity
{
    public abstract class FileStorage
    {
        static public readonly string ROOT;

        static FileStorage()
        {
            ROOT = 
#if UNITY_EDITOR
        Path.Combine(Application.dataPath, "..");
#else
        Application.persistentDataPath;
#endif
        }
    }

    public abstract class FileStorage<T> : FileStorage where T : FileStorage<T>, new()
    {
        static private T _instance = null;
        static public T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new T();
                }
                return _instance;
            }
        }

        protected abstract Formatting _Formatting { get; }

        public U Load<U>(string name = null, string container = null) where U : class
        {
            return Load(typeof(U), name, container) as U;
        }
        public object Load(Type type, string name = null, string container = null)
        {
            return Load(type, GeneratePath(type, name, container));
        }

        public U LoadOrDefault<U>(U defaultValue, string name = null, string container = null) where U : class
        {
            return LoadOrDefault(typeof(U), defaultValue, name, container) as U;
        }
        public object LoadOrDefault(Type type, object defaultValue, string name = null, string container = null)
        {
            object rResult = null;
            try
            {
                rResult = Load(type, name, container);
            }
            catch
            {
                Debug.LogWarning("An error occured while deserializing a file !\nDefault value is returned.");
            }

            if (rResult == null)
            {
                rResult = defaultValue;
            }
            return rResult;
        }

        public void Save<U>(U data, string name = null, string container = null) where U : class
        {
            Save(typeof(U), data, name, container);
        }
        public void Save(Type type, object data, string name = null, string container = null)
        {
            Save(data, GeneratePath(type, name, container));
        }
        
        public void Delete<U>(string name = null, string container = null)
        {
            Delete(typeof(U), name, container);
        }
        public void Delete(Type type, string name = null, string container = null)
        {
            Delete(GeneratePath(type, name, container));
        }

        public bool Exists<U>(string name = null, string container = null)
        {
            return Exists(typeof(U), name, container);
        }
        public bool Exists(Type type, string name = null, string container = null)
        {
            return Exists(GeneratePath(type, name, container));
        }

        protected virtual string GenerateFileName(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (type.IsGenericType)
            {
                throw new ArgumentException("Cannot create GDFUserSettings from a generic type!");
            }

            return type.Name + ".json";
        }

        protected virtual string GeneratePath (Type type, string name, string container)
        {
            if (name == null)
            {
                name = GenerateFileName(type);
            }
            else if (name.IndexOf('.') < 0)
            {
                name += ".json";
            }

            return Path.Combine(GenerateContainerName(container), name);
        }

        protected virtual string GenerateContainerName(string container)
        {
            if (container == null)
            {
                return ROOT;
            }
            return Path.Combine(ROOT, container);
        }

        protected object Load(Type type, string path)
        {
            string content = "";
            if (File.Exists(path))
            {
                content = File.ReadAllText(path);
            }

            if (string.IsNullOrEmpty(content))
            {
                return null;
            }
            return JsonUtility.Deserialize(content, type);
        }

        protected void Save(object data, string path)
        {
            string content = "";
            if (data != null)
            {
                content = JsonUtility.Serialize(data, _Formatting);
            }
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            File.WriteAllText(path, content);
        }

        protected void Delete(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        protected bool Exists(string path)
        {
            return File.Exists(path);
        }
    }
}
