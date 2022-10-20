using System;

namespace NetBank.Api.Models
{

   public class CreditCardResult
   {
      public string IssuingNetwork { get; set; }
      public bool Valid { get; set; }

      public CreditCardResult(string issuingNetwork, bool valid)
      {
         IssuingNetwork = issuingNetwork;
         Valid = valid;
      }
   }
}