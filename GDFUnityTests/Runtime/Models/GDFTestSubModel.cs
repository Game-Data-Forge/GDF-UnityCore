using System;
using GDFFoundation;

namespace GDFUnity.Tests
{
    /// <summary>
    /// Represents the possible values of TestEnum.
    /// </summary>
    public enum TestEnum : byte
    {
        /// <summary>
        /// Represents a member of the TestEnum enumeration with a value of None.
        /// </summary>
        None = 0,

        /// <summary>
        /// Represents a value of the TestEnum enum.
        /// </summary>
        Value1 = 1,

        /// <summary>
        /// Represents the second value of the TestEnum enum.
        /// </summary>
        Value2 = 2,

        /// <summary>
        /// Represents the Value3 member of the TestEnum enumeration in the GDFStandardModels namespace.
        /// </summary>
        /// <remarks>
        /// This member has a value of 3.
        /// </remarks>
        Value3 = 3,

        /// <summary>
        /// Represents a value of the TestEnum enum.
        /// </summary>
        Value4 = 4
    }

    /// <summary>
    /// Represents a set of flags for testing purposes.
    /// </summary>
    [Flags]
    public enum TestFlag : byte
    {
        /// <summary>
        /// Represents a member of the TestFlag enum that has a value of None.
        /// </summary>
        None = 0b00000000,

        /// <summary>
        /// Represents Value1 member of the TestFlag enum.
        /// </summary>
        Value1 = 0b00000001,

        /// <summary>
        /// Represents a value for TestFlag with binary value 0b00000010.
        /// </summary>
        Value2 = 0b00000010,

        /// <summary>
        /// Represents the Value3 member of the TestFlag enum.
        /// </summary>
        Value3 = 0b00000100,

        /// <summary>
        /// Represents the fourth value of the TestFlag enumeration.
        /// </summary>
        Value4 = 0b00001000,

        /// <summary>
        /// The All member of the TestFlag enum.
        /// </summary>
        All = 0b11111111,
    }
    /// <summary>
    /// Represents a submodel for GDFTest.
    /// </summary>
    /// <remarks>
    /// This submodel contains various properties representing different data types.
    /// </remarks>
    public class GDFTestSubModel : IGDFSubModel
    {
        /// <summary>
        /// Gets or sets the TestString property.
        /// </summary>
        public string TestString { set; get; }

        /// <summary>
        /// Gets or sets the TestBool property.
        /// </summary>
        public bool TestBool { set; get; }

        /// <summary>
        /// Gets or sets the TestByte property.
        /// </summary>
        public byte TestByte { set; get; }

        /// <summary>
        /// Gets or sets the TestValue property.
        /// </summary>
        public short TestValue { set; get; }

        /// <summary>
        /// Gets or sets the TestInt property.
        /// </summary>
        public int TestInt { set; get; }

        /// <summary>
        /// Gets or sets the TestLong property.
        /// </summary>
        public long TestLong { set; get; }

        /// <summary>
        /// Gets or sets the TestFloat property.
        /// </summary>
        public float TestFloat { set; get; }

        /// <summary>
        /// Gets or sets the TestDouble property.
        /// </summary>
        public double TestDouble { set; get; }

        /// <summary>
        /// Gets or sets the TestSByte property.
        /// </summary>
        public sbyte TestSByte { set; get; }

        /// <summary>
        /// Gets or sets the TestUShort property.
        /// </summary>
        public ushort TestUShort { set; get; }

        /// <summary>
        /// Gets or sets the TestUInt property.
        /// </summary>
        public uint TestUInt { set; get; }

        /// <summary>
        /// Represents a TestEnum property.
        /// </summary>
        public TestEnum TestEnum { set; get; }

        /// <summary>
        /// Gets or sets the TestFlag property.
        /// This property represents a flag value used for testing purposes.
        /// </summary>
        public TestFlag TestFlag { set; get; }

        /// <summary>
        /// Gets or sets the TestIntArray property.
        /// </summary>
        public int[] TestIntArray { set; get; }
    }
}
