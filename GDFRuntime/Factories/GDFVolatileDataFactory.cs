// using System;
// using System.Collections.Generic;
// using System.Linq;
// using Newtonsoft.Json;
// using GDFFoundation;
//
// namespace GDFRuntime
// {
//     /// <summary>
//     /// The GDFVolatileDataFactory class provides static methods for converting between GDFVolatileData and GDFVolatileDataStorage.
//     /// </summary>
//     public class GDFVolatileDataFactory
//     {
//         /// <summary>
//         /// Converts an GDFVolatileData object to its corresponding GDFVolatileDataStorage object.
//         /// </summary>
//         /// <param name="sO">The GDFVolatileData object to convert.</param>
//         /// <returns>The corresponding GDFVolatileDataStorage object.</returns>
//         public static GDFVolatileDataStorage ToDataVolatileStorage(GDFVolatileData sO)
//         {
//
//             GDFVolatileDataStorage volatileData = new GDFVolatileDataStorage
//             {
//                 Creation = sO.Creation,
//                 Modification = sO.Modification,
//                 Channel = sO.Channel,
//                 DataTrack = sO.DataTrack,
//                 ClassName = sO.GetType().FullName,
//                 ProjectReference = sO.ProjectReference,
//                 Json = JsonConvert.SerializeObject(sO),
//                 Account = sO.Account,
//                 Reference = sO.Reference,
//                 Trashed = sO.Trashed
//             };
//             return volatileData;
//         }
//
//         /// <summary>
//         /// Converts a list of GDFVolatileData objects to a list of GDFVolatileDataStorage objects for volatile data storage.
//         /// </summary>
//         /// <param name="sList">The list of GDFVolatileData objects to be converted</param>
//         /// <param name="sAccountReference">The reference of the account</param>
//         /// <returns>A list of GDFVolatileDataStorage objects</returns>
//         public static List<GDFVolatileDataStorage> ToVolatileDatasStorage(List<GDFVolatileData> sList, long sAccountReference)  // TODO Fix syntax error => ToVolatileDataStorage
//         {
//             return sList.Where(tBasicModel => tBasicModel != null).Select(tBasicModel => ToDataVolatileStorage(tBasicModel)).ToList();
//         }
//
//         /// <summary>
//         /// Converts a <see cref="GDFVolatileDataStorage"/> object back to a <see cref="GDFVolatileData"/> object.
//         /// </summary>
//         /// <param name="data">The <see cref="GDFVolatileDataStorage"/> object to convert.</param>
//         /// <returns>The converted <see cref="GDFVolatileData"/> object.</returns>
//         public static GDFVolatileData FromVolatileDataStorage(GDFVolatileDataStorage data)
//         {
//             return FromVolatileDataStorage(data, GDFReflexion.GetTypeFromFullname(data.ClassName));
//         }
//
//         /// <summary>
//         /// Converts a GDFVolatileDataStorage object to a GDFVolatileData object of the specified type.
//         /// </summary>
//         /// <param name="data">The GDFVolatileDataStorage object to convert.</param>
//         /// <param name="sType">The specified type of the GDFVolatileData object.</param>
//         /// <returns>A GDFVolatileData object of the specified type.</returns>
//         public static GDFVolatileData FromVolatileDataStorage(GDFVolatileDataStorage data, Type sType)
//         {
//             GDFVolatileData tObject = JsonConvert.DeserializeObject(data.Json, sType) as GDFVolatileData;
//             if (tObject != null)
//             {
//                 tObject.SyncDatetime = data.SyncDatetime;
//                 tObject.Commit = data.SyncCommit;
//                 tObject.Modification = data.Modification;
//             }
//
//             return tObject;
//         }
//     }
// }