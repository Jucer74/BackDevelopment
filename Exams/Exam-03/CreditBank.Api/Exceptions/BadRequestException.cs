using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace CreditBank.Api.Exceptions
{
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class BadRequestException : BusinessException
    {
        public BadRequestException()
        {
        }

        public BadRequestException(string message) : base(message)
        {
        }

        public BadRequestException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected BadRequestException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> a0e0e556083d1804f7af31e82f39414ad4263ed2
