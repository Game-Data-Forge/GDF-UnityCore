using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace GDFUnity
{
    public partial class JsonUtility
    {
        private static JsonSerializerSettings _serializationSettings = new JsonSerializerSettings
        {
            Formatting = Formatting.None,
            ContractResolver = new DefaultContractResolver()
        };

        public static string Serialize(object sObject)
        {
            return JsonConvert.SerializeObject(sObject, _serializationSettings);
        }

        public static string Serialize(object sObject, Formatting formating)
        {
            return JsonConvert.SerializeObject(sObject, formating);
        }

        // Update is called once per frame
        public static T Deserialize<T>(string sJSON)
        {
            return (T)Deserialize(sJSON, typeof(T));
        }

        public static object Deserialize(string sJSON, Type sType)
        {
            try
            {
                return JsonConvert.DeserializeObject(sJSON, sType);
            }
            catch (Exception e)
            {
                Exception tException = new Exception("Error while deserializing: (" + sType.Name + ")\n" + sJSON, e);
                throw tException;
            }
        }
    }
}