#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFDbType.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System.Data;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Enumeration defining supported DB types to define flavors.
    /// </summary>
    public enum GDFDbType
    {
        /// <inheritdoc cref="SqlDbType.BigInt" />
        BigInt = SqlDbType.BigInt,

        /// <inheritdoc cref="SqlDbType.Binary" />
        Binary = SqlDbType.Binary,

        /// <inheritdoc cref="SqlDbType.Bit" />
        Bit = SqlDbType.Bit,

        /// <inheritdoc cref="SqlDbType.Char" />
        Char = SqlDbType.Char,

        /// <inheritdoc cref="SqlDbType.DateTime" />
        DateTime = SqlDbType.DateTime,

        /// <inheritdoc cref="SqlDbType.Decimal" />
        Decimal = SqlDbType.Decimal,

        /// <inheritdoc cref="SqlDbType.Float" />
        Float = SqlDbType.Float,

        /// <inheritdoc cref="SqlDbType.Image" />
        Image = SqlDbType.Image,

        /// <inheritdoc cref="SqlDbType.Int" />
        Int = SqlDbType.Int,

        /// <inheritdoc cref="SqlDbType.Money" />
        Money = SqlDbType.Money,

        /// <inheritdoc cref="SqlDbType.NChar" />
        NChar = SqlDbType.NChar,

        /// <inheritdoc cref="SqlDbType.NText" />
        NText = SqlDbType.NText,

        /// <inheritdoc cref="SqlDbType.NVarChar" />
        NVarChar = SqlDbType.NVarChar,

        /// <inheritdoc cref="SqlDbType.Real" />
        Real = SqlDbType.Real,

        /// <inheritdoc cref="SqlDbType.UniqueIdentifier" />
        UniqueIdentifier = SqlDbType.UniqueIdentifier,

        /// <inheritdoc cref="SqlDbType.SmallDateTime" />
        SmallDateTime = SqlDbType.SmallDateTime,

        /// <inheritdoc cref="SqlDbType.SmallInt" />
        SmallInt = SqlDbType.SmallInt,

        /// <inheritdoc cref="SqlDbType.SmallMoney" />
        SmallMoney = SqlDbType.SmallMoney,

        /// <inheritdoc cref="SqlDbType.Text" />
        Text = SqlDbType.Text,

        /// <inheritdoc cref="SqlDbType.Timestamp" />
        Timestamp = SqlDbType.Timestamp,

        /// <inheritdoc cref="SqlDbType.TinyInt" />
        TinyInt = SqlDbType.TinyInt,

        /// <inheritdoc cref="SqlDbType.VarBinary" />
        VarBinary = SqlDbType.VarBinary,

        /// <inheritdoc cref="SqlDbType.VarChar" />
        VarChar = SqlDbType.VarChar,

        /// <inheritdoc cref="SqlDbType.Variant" />
        Variant = SqlDbType.Variant,

        /// <inheritdoc cref="SqlDbType.Xml" />
        Xml = SqlDbType.Xml,

        /// <inheritdoc cref="SqlDbType.Udt" />
        Udt = SqlDbType.Udt,

        /// <inheritdoc cref="SqlDbType.Structured" />
        Structured = SqlDbType.Structured,

        /// <inheritdoc cref="SqlDbType.Date" />
        Date = SqlDbType.Date,

        /// <inheritdoc cref="SqlDbType.Time" />
        Time = SqlDbType.Time,

        /// <inheritdoc cref="SqlDbType.DateTime2" />
        DateTime2 = SqlDbType.DateTime2,

        /// <inheritdoc cref="SqlDbType.DateTimeOffset" />
        DateTimeOffset = SqlDbType.DateTimeOffset
    }
}