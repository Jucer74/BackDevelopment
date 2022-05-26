using System;

namespace NetBank.Api.Models
{
   public class CreditCardResult
   {
      public string IssuingNetwork { get; set; }
      public bool Valid { get; set; }
   }
}