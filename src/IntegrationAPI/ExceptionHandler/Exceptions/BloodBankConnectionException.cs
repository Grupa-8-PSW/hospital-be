using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAPI.ExceptionHandler.Exceptions
{
    public class BloodBankConnectionException : Exception
    {
        public BloodBankConnectionException()
        {

        }

        public BloodBankConnectionException(string message)
            : base(message)
        {

        }

    }

    public class BloodBankURIException : Exception
    {
        public BloodBankURIException()
        {

        }

        public BloodBankURIException(string message)
            : base(message)
        {

        }
    }

    public class BloodBankApiKeyAuthException : Exception
    {
        public BloodBankApiKeyAuthException()
        {

        }

        public BloodBankApiKeyAuthException(string message)
            : base(message)
        {

        }
    }
}
