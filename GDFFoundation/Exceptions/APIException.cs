using System;
using System.Net;

namespace GDFFoundation
{
    public class APIException : GDFException
    {
        public HttpStatusCode StatusCode { get; private set; }

        public APIException()
            : base("API", 500, $"This is a {nameof(GDFException)}")
        {
            StatusCode = HttpStatusCode.InternalServerError;
        }


        public APIException(in ApiErrorMessage data)
            : this((HttpStatusCode)data.StatusCode, data.InnerCode, data.Message, data.Help)
        {
        }

        public APIException(HttpStatusCode statusCode, string errorCode, Exception exception, string help = "")
            : base(errorCode, $"{exception.Message}", help)
        {
            StatusCode = statusCode;
        }

        public APIException(HttpStatusCode statusCode, string errorCode, string message, string help = "")
            : base(errorCode, $"{message}", help)
        {
            StatusCode = statusCode;
        }

        public APIException(HttpStatusCode statusCode, string errorCategory, int errorNumber, string message, string help = "")
            : base(errorCategory, errorNumber, $"{message}", help)
        {
            StatusCode = statusCode;
        }

        public APIException(Exception exception, string help)
            : base(exception.GetType().Name, (int)HttpStatusCode.InternalServerError, exception.Message, help)
        {
            StatusCode = HttpStatusCode.InternalServerError;
        }

        public ApiErrorMessage ToHttpResult()
        {
            return new ApiErrorMessage
            {
                StatusCode = (int)StatusCode,
                InnerCode = ErrorCode,
                Message = Message,
                Help = Help,
            };
        }
    }
}