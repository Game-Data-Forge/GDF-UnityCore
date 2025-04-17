using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using GDFFoundation;

namespace GDFRuntime
{
    /// <summary>
    /// The GDFStudioDataFactory class provides utility methods for converting studio data objects to storage objects and vice versa.
    /// </summary>
    public class GDFStudioDataFactory
    {
        /// <summary>
        /// Converts an instance of GDFStudioData to GDFStudioDataDataStorage.
        /// </summary>
        /// <param name="sO">The instance of GDFStudioData to convert.</param>
        /// <returns>An instance of GDFStudioDataDataStorage.</returns>
        public static GDFStudioDataStorage ToStudioDataStorage(GDFStudioData sO)
        {
            GDFStudioDataStorage studioData = new GDFStudioDataStorage
            {
                Channels = sO.Channel,
                DataTrack = sO.DataTrack,
                ClassName = sO.GetType().FullName,
                Json = JsonConvert.SerializeObject(sO),
                Reference = sO.Reference
            };
            return studioData;
        }

        /// <summary>
        /// Converts a list of GDFStudioData objects to a list of GDFStudioDataDataStorage objects.
        /// </summary>
        /// <param name="list">The list of GDFStudioData objects.</param>
        /// <returns>A list of GDFStudioDataDataStorage objects.</returns>
        public static List<GDFStudioDataStorage> ToStudioDatasStorage(List<GDFStudioData> list) // TODO Fix syntax error => ToStudioDataStorage
        {
            return list.Select(tBasicModel => ToStudioDataStorage(tBasicModel)).ToList();
        }

        /// <summary>
        /// Converts an instance of <see cref="GDFStudioDataStorage"/> to an instance of <see cref="GDFStudioData"/> using the provided type.
        /// </summary>
        /// <param name="data">The data to be converted.</param>
        /// <returns>An instance of <see cref="GDFStudioData"/> representing the converted data.</returns>
        public static GDFStudioData FromStudioDataStorage(GDFStudioDataStorage data)
        {
            return FromStudioDataStorage(data, GDFReflexion.GetTypeFromFullname(data.ClassName));
        }

        /// <summary>
        /// Converts a <see cref="GDFStudioDataStorage"/> object to a <see cref="GDFStudioData"/> object.
        /// </summary>
        /// <param name="data">The <see cref="GDFStudioDataStorage"/> object to convert.</param>
        /// <param name="sType">The type of the resulting <see cref="GDFStudioData"/> object.</param>
        /// <returns>The converted <see cref="GDFStudioData"/> object.</returns>
        public static GDFStudioData FromStudioDataStorage(GDFStudioDataStorage data, Type sType)
        {
            try
            {
                GDFStudioData tObject = JsonConvert.DeserializeObject(data.Json, sType) as GDFStudioData;
                FillStudioData(data, tObject);
                return tObject;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Fills the studio data object with the given storage data.
        /// </summary>
        /// <param name="data">The storage data object containing the data to fill the studio data with.</param>
        /// <param name="sObject">The studio data object to fill with the storage data.</param>
        public static void FillStudioData(GDFStudioDataStorage data, GDFStudioData sObject)
        {
            if (sObject != null)
            {
                sObject.Reference = data.Reference;
                sObject.SyncDatetime = data.SyncDateTime;
                sObject.SyncCommit = data.SyncCommit;
                sObject.Modification = data.Modification;
                sObject.Creation = data.Creation;
            }
        }
    }
}