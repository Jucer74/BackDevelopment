using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace CreditBank.Api.Exceptions
{
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class InternalServerErrorException : BusinessException
    {
        public InternalServerErrorException()
        {
        }

        public InternalServerErrorException(string message) : base(message)
        {
        }

        public InternalServerErrorException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
        protected InternalServerErrorException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> a0e0e556083d1804f7af31e82f39414ad4263ed2
