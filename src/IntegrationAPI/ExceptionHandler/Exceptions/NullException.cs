﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAPI.ExceptionHandler.Exceptions
{
    public class NullException : Exception
    {
        public NullException()
        {

        }

        public NullException(string message) 
            : base(message)
        {

        }

        public NullException(string message, Exception inner)
            : base(message, inner)
        {

        }

        public NullException(SerializationInfo info,  StreamingContext context)
            : base(info, context)
        {

        }
    }
}
