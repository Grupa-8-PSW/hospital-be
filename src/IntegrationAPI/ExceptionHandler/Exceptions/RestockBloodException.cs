using System.Runtime.Serialization;

namespace IntegrationAPI.ExceptionHandler.Exceptions
{
    public class RestockBloodException : Exception
    {
        public RestockBloodException()
        {

        }

        public RestockBloodException(string message)
            : base(message)
        {

        }

        public RestockBloodException(string message, Exception inner)
            : base(message, inner)
        {

        }

        public RestockBloodException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }
}

