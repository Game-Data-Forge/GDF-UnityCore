#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFConfigurationServerModel.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion

// using System;
//
// namespace GDFFoundation
// {
//     /// <summary>
//     /// Represents the configuration settings for the server model.
//     /// </summary>
//     [Serializable]
//     public class GDFConfigurationServerModel
//     {
//         /// <summary>
//         /// Gets or sets the name of the server.
//         /// </summary>
//         public string Name { set; get; } = "GDF_SERVER_NAME";
//
//         /// <summary>
//         /// The IP property represents the IP address of the server.
//         /// </summary>
//         /// <remarks>
//         /// This property is defined in the GDFConfigurationServerModel class.
//         /// </remarks>
//         /// <value>
//         /// The IP address of the server.
//         /// </value>
//         public string Ip { set; get; } = "GDF_SERVER_IP";
//
//         // public string CommitHash { set; get; } = "CI_COMMIT_SHA";
//         //
//         // public string Job { set; get; } = "CI_JOB_ID";
//         //
//         // public string PipelineDate { set; get; } = "CI_PIPELINE_DATE";
//
//         /// <summary>
//         /// Gets or sets the duration (in seconds) that a rescue token is valid for.
//         /// </summary>
//         /// <value>The duration in seconds.</value>
//         public int RescueTokenDuration { set; get; } = 14400; //one day
//
//         /// <summary>
//         /// Gets or sets the overflow limit for the server.
//         /// </summary>
//         /// <remarks>
//         /// The overflow limit determines the maximum threshold at which the server is considered to be overloaded.
//         /// If the server's load exceeds this limit, appropriate actions should be taken to prevent service disruptions.
//         /// The value is expressed as a float between 0 and 1, where 0 represents no overflow and 1 represents full overload.
//         /// For example, a value of 0.8 signifies that the server is considered overloaded if its load exceeds 80% of its capacity.
//         /// The default value is 0.8F.
//         /// </remarks>
//         public float OverflowLimit { set; get; } = 0.8F;
//
//         /// <summary>
//         /// Represents the configuration settings for the server.
//         /// </summary>
//         public GDFConfigurationServerModel()
//         {
//         }
//     }
// }
//
