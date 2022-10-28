using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Domain.Exceptions
{
    public class BloodBankNotFound : Exception
    {
        public BloodBankNotFound()
        {

        }

        public BloodBankNotFound(string message) : base(message)
        {

        }

        public BloodBankNotFound(string message, Exception inner) : base(message, inner)
        {

        }

        public BloodBankNotFound(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {

        }
    }
}
