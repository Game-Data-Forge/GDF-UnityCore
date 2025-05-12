#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFDataContinent.cs create at 2025/05/09 13:05:55
// ©2024-2025 idéMobi SARL FRANCE

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents a set of continents within the <see cref="GDFDataContinent" /> enumeration.
    ///     Each enumeration member corresponds to a specific region in the <see cref="GDFDataArea" /> classification.
    ///     It is used for grouping geographical areas by their continental division.
    /// </summary>
    public enum GDFDataContinent
    {
        /// <summary>
        ///     Represents the continent of Europe in the GDFDataContinent enumeration.
        /// </summary>
        /// <remarks>
        ///     This enumeration member corresponds to GDFDataArea.Europe and encompasses the geographic region associated with the continent of Europe.
        /// </remarks>
        Europe = GDFDataArea.Europe,

        /// <summary>
        ///     Represents the continent of North America in the GDFDataContinent enumeration.
        /// </summary>
        /// <remarks>
        ///     This enumeration member maps to the GDFDataArea.NorthAmerica value.
        ///     North America includes countries such as the United States, Canada, and Mexico.
        /// </remarks>
        NorthAmerica = GDFDataArea.NorthAmerica,

        /// <summary>
        ///     Represents the continent of South America in the GDFDataContinent enumeration.
        /// </summary>
        /// <remarks>
        ///     This enumeration member maps to the corresponding value in the GDFDataArea enumeration.
        ///     South America includes countries such as Brazil, Argentina, and Chile, and features diverse landscapes from the Amazon rainforest to the Andes mountains.
        /// </remarks>
        SouthAmerica = GDFDataArea.SouthAmerica,

        /// <summary>
        ///     Represents the continent of Africa in the GDFDataContinent enumeration.
        /// </summary>
        /// <remarks>
        ///     This member corresponds to areas within the continent of Africa, including region-specific mappings such as South Africa's POPIA and Nigeria's NDPR.
        /// </remarks>
        Africa = GDFDataArea.Africa,

        /// <summary>
        ///     Represents the continent of Asia in the GDFDataContinent enumeration.
        /// </summary>
        /// <remarks>
        ///     This enumeration member corresponds to the diverse and expansive region of Asia,
        ///     which includes countries such as China, India, Japan, and others. It maps to
        ///     the GDFDataArea.Asia value.
        /// </remarks>
        Asia = GDFDataArea.Asia,

        /// <summary>
        ///     Represents the continent of Oceania in the GDFDataContinent enumeration.
        /// </summary>
        /// <remarks>
        ///     This enumeration member corresponds to the Oceania region, which includes areas such as
        ///     Australia and New Zealand, located in the Pacific Ocean. It maps to the GDFDataArea.Oceania value
        ///     in the GDFDataArea enumeration.
        /// </remarks>
        Oceania = GDFDataArea.Oceania,

        /// <summary>
        ///     Represents the continent of Antarctica in the GDFDataContinent enumeration.
        /// </summary>
        /// <remarks>
        ///     This enumeration member corresponds to the GDFDataArea.Antarctica value.
        ///     Antarctica is Earth's southernmost continent, containing the geographic South Pole.
        /// </remarks>
        Antarctica = GDFDataArea.Antarctica,
    }
}