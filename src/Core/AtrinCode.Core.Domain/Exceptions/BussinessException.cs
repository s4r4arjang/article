using System.Net;

namespace AtrinCode.Core.Domain.Exceptions
{
    public class BussinessException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }


        public BussinessException() : this("خطای بیزنسی")
        {

        }

        public BussinessException(string message)
            : this(message, HttpStatusCode.InternalServerError)
        {
        }

        public BussinessException(string message, HttpStatusCode httpStatusCode)
         : this(message, httpStatusCode, null)
        {
        }


        public BussinessException(string message, Exception exception)
        : this(message, HttpStatusCode.InternalServerError, exception)
        {
        }
        public BussinessException(string message, HttpStatusCode httpStatusCode, Exception exception)
         : base(message, exception)
        {

            StatusCode = httpStatusCode;

        }
    }
}
