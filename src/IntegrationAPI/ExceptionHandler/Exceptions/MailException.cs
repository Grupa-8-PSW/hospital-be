using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAPI.ExceptionHandler.Exceptions
{
    public class MailException : Exception
    {
        public MailException()
        {

        }

        public MailException(string message)
            : base(message)
        {

        }

        public MailException(string message, Exception inner)
            : base(message, inner)
        {

        }

        public MailException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }
}
