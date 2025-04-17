

using System;
using System.Collections.Generic;

namespace GDFFoundation
{
    /// <summary>
    /// Represents a localizable text and audio data type.
    /// </summary>
    [Serializable]
    [Obsolete("Use GDFStringLocalization and GDFAudioLocalization instead!")]
    public class GDFLocalizableTextAndAudio : GDFDataType
    {
        /// <summary>
        /// Represents a deprecated class for storing localizable text and audio.
        /// </summary>
        public string Base { set; get; } = string.Empty;

        /// <summary>
        /// Represents a localizable text and audio value.
        /// </summary>
        /// <remarks>
        /// This class is obsolete. Use GDFStringLocalization and GDFAudioLocalization instead.
        /// </remarks>
        public Dictionary<string, string> Values { set; get; } = new Dictionary<string, string>();

        /// <summary>
        /// Represents a dictionary of localized audio clips.
        /// </summary>
        /// <remarks>
        /// This class is used to store and manage localized audio clips for a specific data type.
        /// Each entry in the dictionary represents a language code and the corresponding audio clip path.
        /// </remarks>
        public Dictionary<string, string> Audios { set; get; } = new Dictionary<string, string>();
    }
}



