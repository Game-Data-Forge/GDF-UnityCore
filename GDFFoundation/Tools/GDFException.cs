using System;

namespace GDFFoundation
{
    /// <summary>
    /// Initializes a new instance of the GDFException class with the given error category, error ID, and message.
    /// </summary>
    public class GDFException : Exception, IEquatable<GDFException>
    {
        /// <summary>
        /// Represents a custom exception that can be thrown in the GDFFoundation namespace.
        /// </summary>
        const string _FORMAT = "{0}-{1}";
        const string _NUMBER_FORMAT = "######";
        /// <summary>
        /// Represents an error code associated with an exception.
        /// </summary>
        public string ErrorCode;
        public string Help;
        public string ErrorCategory;
        public int ErrorNumber;
        public GDFException(): base($"This is a {nameof(GDFException)}")
        {
            ErrorCategory = "ERR";
            ErrorNumber = 500;
            Help = "help";
            ErrorCode = string.Format(_FORMAT, ErrorCategory, ErrorNumber.ToString(_NUMBER_FORMAT));
        }
        /// <summary>
        /// Represents a custom exception that occurs in the GDFFoundation namespace.
        /// Inherits from the Exception class.
        /// </summary>
        public GDFException(string errorCategory, int errorNumber, string message, string help = "") : base(message)
        {
            ErrorCategory = errorCategory;
            ErrorNumber = errorNumber;
            Help = help;
            ErrorCode = string.Format(_FORMAT, errorCategory, errorNumber.ToString(_NUMBER_FORMAT));
        }

        /// Represents a custom exception class that inherits from the Exception class.
        /// /
        public GDFException(string errorCode, string message, string help = "") : base(message)
        {
            ErrorCode = errorCode;
            Help = help;
        }

        /// GDFException.cs
        /// /
        public GDFException(string errorCategory, int errorNumber, string message, Exception innerException, string help = "") : base(message, innerException)
        {
            ErrorCategory = errorCategory;
            ErrorNumber = errorNumber;
            ErrorCode = string.Format(_FORMAT, errorCategory, errorNumber.ToString(_NUMBER_FORMAT));
            Help = help;
        }

        /// <summary>
        /// The GDFException class represents a custom exception that can be thrown in the GDFFoundation.
        /// </summary>
        public GDFException(string errorCode, string message, Exception innerException, string help = "") : base(message, innerException)
        {
            ErrorCode = errorCode;
            Help = help;
            if (innerException == null)
            {
                return;
            } 
            GDFLogger.Error(innerException);
        }

        public override int GetHashCode()
        {
            return ErrorCode.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (obj is string)
            {
                return ErrorCode.Equals(obj);
            }

            if (obj is GDFException other)
            {
                return Equals(other);
            }

            return false;
        }

        public bool Equals(GDFException other)
        {
            if (other is null)
            {
                return false;
            }

            return ErrorCode == other.ErrorCode;
        }

        static public bool operator ==(GDFException e1, GDFException e2)
        {
            if (e1 is null && e2 is null)
            {
                return true;
            }

            return e1?.Equals(e2) ?? false;
        }

        static public bool operator !=(GDFException e1, GDFException e2)
        {
            return !(e1 == e2);
        }
    }
}
