using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// The GDFUserDataFactory class is responsible for converting GDFUserData objects to and from GDFUserDataDataStorage objects.
    /// </summary>
    public class GDFUserDataFactory
    {
        /// Converts an instance of GDFUserData to an instance of GDFUserDataDataStorage.
        /// @param sO An instance of GDFUserData.
        /// @return An instance of GDFUserDataDataStorage.
        /// /
        public static GDFUserDataDataStorage ToDataUserStorage(GDFUserData sO)
        {

            GDFUserDataDataStorage tUserDataData = new GDFUserDataDataStorage
            {
                Creation = sO.Creation,
                Modification = sO.Modification,
                Channels = sO.Channels,
                ClassName = sO.GetType().FullName,
                // ProjectReference = sO.ProjectReference,
                Json = JsonConvert.SerializeObject(sO),
                Account = sO.Account,
                Reference = sO.Reference,
                Trashed = sO.Trashed
            };
            return tUserDataData;
        }

        /// <summary>
        /// Converts a list of GDFUserData objects to a list of GDFUserDataDataStorage objects.
        /// </summary>
        /// <param name="list">The list of GDFUserData objects to convert.</param>
        /// <param name="sAccountReference">The account reference ID.</param>
        /// <returns>The converted list of GDFUserDataDataStorage objects.</returns>
        public static List<GDFUserDataDataStorage> ToUserDatasStorage(List<GDFUserData> list, long sAccountReference) // TODO Fix syntax error => ToUserDataStorage
        {
            return list.Where(tBasicModel => tBasicModel != null).Select(tBasicModel => ToDataUserStorage(tBasicModel)).ToList();
        }

        /// <summary>
        /// Converts the specified <see cref="GDFUserDataDataStorage"/> object to its corresponding <see cref="GDFUserData"/> object.
        /// </summary>
        /// <param name="sDataData">The <see cref="GDFUserDataDataStorage"/> object to convert.</param>
        /// <returns>The corresponding <see cref="GDFUserData"/> object.</returns>
        public static GDFUserData FromUserDataStorage(GDFUserDataDataStorage sDataData)
        {
            return FromUserDataStorage(sDataData, GDFReflexion.GetTypeFromFullname(sDataData.ClassName));
        }

        /// <summary>
        /// Converts a <see cref="GDFUserDataDataStorage"/> object to a <see cref="GDFUserData"/> object.
        /// </summary>
        /// <param name="sDataData">The GDFUserDataDataStorage object to convert.</param>
        /// <param name="sType">The Type to convert the GDFUserDataDataStorage object to.</param>
        /// <returns>The converted GDFUserData object.</returns>
        public static GDFUserData FromUserDataStorage(GDFUserDataDataStorage sDataData, Type sType)
        {
            GDFUserData tObject = JsonConvert.DeserializeObject(sDataData.Json, sType) as GDFUserData;
            FillUserData(sDataData, tObject);

            return tObject;
        }

        /// <summary>
        /// Fills the user data properties from the given GDFUserDataDataStorage object.
        /// </summary>
        /// <param name="sDataData">The GDFUserDataDataStorage object containing the data to be filled.</param>
        /// <param name="sObject">The GDFUserData object to fill with data. Can be null.</param>
        public static void FillUserData(GDFUserDataDataStorage sDataData, GDFUserData sObject)
        {
            if (sObject != null)
            {
                sObject.Reference = sDataData.Reference;
                sObject.SyncDateTime = sDataData.SyncDateTime;
                sObject.SyncCommit = sDataData.SyncCommit;
                sObject.Modification = sDataData.Modification;
                sObject.Creation = sDataData.Creation;
            }
        }
    }
}