using System.Runtime.Serialization;

namespace IntegrationAPI.ExceptionHandler.Exceptions
{
    public class BloodConsumptionConfigurationArgumentException : Exception
    {
        public BloodConsumptionConfigurationArgumentException()
        {

        }

        public BloodConsumptionConfigurationArgumentException(string message)
            : base(message)
        {

        }

        public BloodConsumptionConfigurationArgumentException(string message, Exception inner)
            : base(message, inner)
        {

        }

        public BloodConsumptionConfigurationArgumentException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }
}
