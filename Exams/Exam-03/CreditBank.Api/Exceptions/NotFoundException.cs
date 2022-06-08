using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace CreditBank.Api.Exceptions
{
   [ExcludeFromCodeCoverage]
   [Serializable]
   public class NotFoundException : BusinessException
   {
      public NotFoundException()
      {
      }

      public NotFoundException(string message) : base(message)
      {
      }

      public NotFoundException(string message, Exception innerException)
          : base(message, innerException)
      {
      }

      protected NotFoundException(SerializationInfo info, StreamingContext context)
          : base(info, context)
      {
      }
   }
}
