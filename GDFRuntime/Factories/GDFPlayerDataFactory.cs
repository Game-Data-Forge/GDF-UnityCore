using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// This class provides methods to convert player data between different representations.
    /// </summary>
    public class GDFPlayerDataFactory
    {
        /// <summary>
        /// Converts an <see cref="GDFPlayerData"/> object to an <see cref="GDFPlayerDataStorage"/> object.
        /// </summary>
        /// <param name="sO">The <see cref="GDFPlayerData"/> object to convert.</param>
        /// <returns>The converted <see cref="GDFPlayerDataStorage"/> object.</returns>
        public static GDFPlayerDataStorage ToDataPlayerStorage(GDFPlayerData sO)
        {
            GDFPlayerDataStorage tPlayerDataData = new GDFPlayerDataStorage
            {
                Creation = sO.Creation,
                Modification = sO.Modification,
                Channels = sO.Channels,
                //DataTrack = sO.DataTrack,
                ClassName = sO.GetType().FullName,
                // Project = sO.Project,
                Json = JsonConvert.SerializeObject(sO),
                Account = sO.Account,
                Reference = sO.Reference,
                Trashed = sO.Trashed
            };
            return tPlayerDataData;
        }

        /// <summary>
        /// Converts a list of GDFPlayerData objects to a list of GDFPlayerDataStorage objects.
        /// </summary>
        /// <param name="list">The list of GDFPlayerData objects to convert.</param>
        /// <param name="sAccountReference">The account reference for the GDFPlayerData objects.</param>
        /// <returns>A list of GDFPlayerDataStorage objects.</returns>
        public static List<GDFPlayerDataStorage> ToPlayerDatasStorage(List<GDFPlayerData> list, long sAccountReference) // TODO Fix syntax error => ToPlayerDataStorage
        {
            return list.Where(tBasicModel => tBasicModel != null).Select(tBasicModel => ToDataPlayerStorage(tBasicModel)).ToList();
        }

        /// <summary>
        /// Converts a <see cref="GDFPlayerDataStorage"/> object to its corresponding <see cref="GDFPlayerData"/> object.
        /// </summary>
        /// <param name="sDataData">The <see cref="GDFPlayerDataStorage"/> object to convert.</param>
        /// <returns>The corresponding <see cref="GDFPlayerData"/> object.</returns>
        public static GDFPlayerData FromPlayerDataStorage(GDFPlayerDataStorage sDataData)
        {
            return FromPlayerDataStorage(sDataData, GDFReflexion.GetTypeFromFullname(sDataData.ClassName));
        }

        /// <summary>
        /// Converts an instance of <see cref="GDFPlayerDataStorage"/> to an instance of <see cref="GDFPlayerData"/>.
        /// </summary>
        /// <param name="sDataData">The instance of <see cref="GDFPlayerDataStorage"/> to convert.</param>
        /// <param name="sType">The <see cref="Type"/> of the <see cref="GDFPlayerData"/>.</param>
        /// <returns>An instance of <see cref="GDFPlayerData"/> converted from <paramref name="sDataData"/>.</returns>
        public static GDFPlayerData FromPlayerDataStorage(GDFPlayerDataStorage sDataData, Type sType)
        {
            GDFPlayerData tObject = JsonConvert.DeserializeObject(sDataData.Json, sType) as GDFPlayerData;
            FillPlayerData(sDataData, tObject);
            return tObject;
        }

        /// <summary>
        /// Fills the player data object with the data from the player data storage object.
        /// </summary>
        /// <param name="sDataData">The player data storage object.</param>
        /// <param name="sObject">The player data object to fill.</param>
        public static void FillPlayerData(GDFPlayerDataStorage sDataData, GDFPlayerData sObject)
        {
            if (sObject != null)
            {
                sObject.ProtectedFill(sDataData);
            }
        }
    }
}