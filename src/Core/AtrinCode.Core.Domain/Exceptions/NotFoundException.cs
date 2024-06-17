using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AtrinCode.Core.Domain.Exceptions
{
    public class NotFoundException : BussinessException
    {
        public NotFoundException() 
            : this("Not Found")
        {

        }

        public NotFoundException(string message)
       : this(message, HttpStatusCode.BadRequest)
        {
        }
        public NotFoundException(string message, HttpStatusCode httpStatusCode)
            : base(message, httpStatusCode)
        {
        }
    }
}
