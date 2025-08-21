#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFBasicExchange.cs create at 2025/03/26 17:03:59
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Base class for all GDF exchange classes.
    /// </summary>
    [Serializable]
    public abstract class GDFBasicExchange
    {
        #region Instance fields and properties

        /// <summary>
        ///     Represents a basic exchange object.
        /// </summary>
        public string Dll { set; get; } = LibrariesWorkflow.GetForFoundation().Version();

        /// <summary>
        ///     Represents the environment in which the software is running.
        /// </summary>
        public ProjectEnvironment Environment { set; get; }

        /// <summary>
        ///     Represents a basic exchange object for network communication.
        /// </summary>
        public string Hash { set; get; } = string.Empty;

        /// <summary>
        ///     Represents the IdName property of the GDFBasicExchange class.
        /// </summary>
        public string IdName { set; get; } = GDFRandom.RandomString(8);

        /// <summary>
        ///     Represents the payload of a network exchange.
        /// </summary>
        public string Payload { set; get; } = string.Empty;

        /// <summary>
        ///     Gets or sets the project ID associated with the exchange.
        /// </summary>
        public long ProjectReference { set; get; }

        /// <summary>
        ///     The version of the project.
        /// </summary>
        public long ProjectVersion { set; get; }

        /// <summary>
        ///     Represents a stamp used in various exchanges.
        /// </summary>
        public string Stamp { set; get; } = string.Empty;

        /// <summary>
        ///     Represents the timestamp of a GDFBasicExchange object.
        /// </summary>
        public long Timestamp { set; get; }

        #endregion
    }
}