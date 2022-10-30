using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service.Exceptions
{
    public class BloodBankArgumentException : Exception
    {
        public BloodBankArgumentException()
        {

        }

        public BloodBankArgumentException(string message)
            : base(message)
        {

        }

        public BloodBankArgumentException(string message, Exception inner)
            : base(message, inner)
        {

        }

        public BloodBankArgumentException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }
}
