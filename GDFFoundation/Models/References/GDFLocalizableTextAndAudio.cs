#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFLocalizableTextAndAudio.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;
using System.Collections.Generic;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents a localizable text and audio data type.
    /// </summary>
    [Serializable]
    [Obsolete("Use GDFStringLocalization and GDFAudioLocalization instead!")]
    public class GDFLocalizableTextAndAudio : GDFDataType
    {
        #region Instance fields and properties

        /// <summary>
        ///     Represents a dictionary of localized audio clips.
        /// </summary>
        /// <remarks>
        ///     This class is used to store and manage localized audio clips for a specific data type.
        ///     Each entry in the dictionary represents a language code and the corresponding audio clip path.
        /// </remarks>
        public Dictionary<string, string> Audios { set; get; } = new Dictionary<string, string>();

        /// <summary>
        ///     Represents a deprecated class for storing localizable text and audio.
        /// </summary>
        public string Base { set; get; } = string.Empty;

        /// <summary>
        ///     Represents a localizable text and audio value.
        /// </summary>
        /// <remarks>
        ///     This class is obsolete. Use GDFStringLocalization and GDFAudioLocalization instead.
        /// </remarks>
        public Dictionary<string, string> Values { set; get; } = new Dictionary<string, string>();

        #endregion
    }
}