﻿

using System;

namespace GDFFoundation
{
    /// <summary>
    /// Base class for all GDF exchange classes.
    /// </summary>
    [Serializable]
    public abstract class GDFBasicExchange
    {
        /// <summary>
        /// Represents a basic exchange object.
        /// </summary>
        public string Dll { set; get; } = GDFFoundation.GDFVersionDll.VersionDll.Version;

        /// <summary>
        /// Represents the IdName property of the GDFBasicExchange class.
        /// </summary>
        public string IdName { set; get; } = GDFRandom.RandomString(8);

        /// <summary>
        /// Gets or sets the project ID associated with the exchange.
        /// </summary>
        public long ProjectReference { set; get; }

        /// <summary>
        /// The version of the project.
        /// </summary>
        public long ProjectVersion { set; get; }

        /// <summary>
        /// Represents the environment in which the software is running.
        /// </summary>
        public GDFEnvironmentKind Environment { set; get; }

        /// <summary>
        /// Represents a stamp used in various exchanges.
        /// </summary>
        public string Stamp { set; get; } = string.Empty;

        /// <summary>
        /// Represents a basic exchange object for network communication.
        /// </summary>
        public string Hash { set; get; } = string.Empty;

        /// <summary>
        /// Represents the payload of a network exchange.
        /// </summary>
        public string Payload { set; get; } = string.Empty;

        /// <summary>
        /// Represents the timestamp of a GDFBasicExchange object.
        /// </summary>
        public long Timestamp { set; get; }

    }
}



