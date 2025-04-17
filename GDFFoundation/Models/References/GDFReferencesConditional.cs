using System;



namespace GDFFoundation
{
    /// <summary>
    /// Represents a set of conditional operators for the GDFReferencesConditional class.
    /// </summary>
    [Serializable]
    public enum GDFConditional : int
    {
        /// <summary>
        /// Represents the equal to conditional for the GDFReferencesConditional class.
        /// </summary>
        EqualTo = 0,

        /// <summary>
        /// Represents a conditional operator for the GDFReferencesConditional class where the reference quantity must be greater than a specified value.
        /// </summary>
        UpperThan = 1,

        /// <summary>
        /// Represents an enumeration value for the GDFConditional enum.
        /// The UpperThanOrEqual value indicates that the condition is greater than or equal to the comparison value.
        /// </summary>
        UpperThanOrEqual = 2,

        /// <summary>
        /// Represents the 'LowerThan' conditional option of the GDFConditional enum.
        /// </summary>
        /// <remarks>
        /// Use this conditional option when comparing values to check if the left value is lower than the right value.
        /// </remarks>
        LowerThan = 3,

        /// <summary>
        /// Represents the 'LowerThanOrEqual' member of the 'GDFConditional' enum.
        /// </summary>
        /// <remarks>
        /// This member is used to specify a condition where the value should be less than or equal to the reference value.
        /// </remarks>
        LowerThanOrEqual = 4,
        DifferentTo = 5,
    }

    /// <summary>
    /// Represents a class for conditional references to other database models.
    /// </summary>
    /// <typeparam name="T">The type of the referenced database model.</typeparam>
    [Serializable]
    // TODO change for structure
    public class GDFReferencesConditional<T> : GDFDataType where T : GDFDatabaseObject
    {
        /// <summary>
        /// Represents a generic conditional reference to a <typeparamref name="T"/> model in the database.
        /// </summary>
        /// <typeparam name="T">The type of the referenced model.</typeparam>
        public ulong Reference;

        /// <summary>
        /// Represents the quantity of a certain item.
        /// </summary>
        public int Quantity;

        /// <summary>
        /// Represents a conditional value for GDFReferencesConditional.
        /// </summary>
        public GDFConditional Condition;
    }
}

