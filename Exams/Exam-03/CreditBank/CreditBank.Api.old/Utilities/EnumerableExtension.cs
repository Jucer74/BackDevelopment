using System.Collections.Generic;
using System.Linq;

namespace CreditBank.Api.Utilities
{
   public static class EnumerableExtension
   {
      public static bool IsNullOrEmpty<T>(this IEnumerable<T> list)
      {
         return (list is null || !list.Any() );
      }
   }
}
