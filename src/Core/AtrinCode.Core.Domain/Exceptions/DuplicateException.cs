using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtrinCode.Core.Domain.Exceptions
{
    public class DuplicateException : BussinessException
    {
        public DuplicateException()
              : this("قبلا ثبت شده است")
        {
        }
        public DuplicateException(string message)
       : this(message, HttpStatusCode.BadRequest)
        {
        }
        public DuplicateException(string message, HttpStatusCode httpStatusCode)
            : base(message, httpStatusCode)
        {
        }
    }
}
