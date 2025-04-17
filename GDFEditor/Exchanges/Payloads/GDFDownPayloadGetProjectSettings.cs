

using GDFFoundation;

namespace GDFEditor
{
    /// <summary>
    /// GDFDownPayloadGetProjectSettings is a class representing the payload used to request project settings.
    /// </summary>
    public class GDFDownPayloadGetProjectSettings : GDFDownPayloadEditor
    {
        /// <summary>
        /// Represents the project description.
        /// </summary>
        public GDFProjectDescription ProjectDescription { set; get; }
    }

}

