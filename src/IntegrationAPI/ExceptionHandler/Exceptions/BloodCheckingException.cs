using System.Runtime.Serialization;

namespace IntegrationAPI.ExceptionHandler.Exceptions
{
    public class BloodCheckingException : Exception
    {
        public BloodCheckingException()
        {

        }

        public BloodCheckingException(string message)
            : base(message)
        {

        }

        public BloodCheckingException(string message, Exception inner)
            : base(message, inner)
        {

        }

        public BloodCheckingException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }
}
