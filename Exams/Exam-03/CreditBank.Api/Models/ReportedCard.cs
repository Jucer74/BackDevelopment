using System;
using System.ComponentModel.DataAnnotations;

namespace CreditBank.Api.Models
{
   public class ReportedCard
   {
      [Key]
      public int Id { get; set; }

      [Required(ErrorMessage = "IssuingNetwork is required")]
      public string IssuingNetwork { get; set; }

      [Required(ErrorMessage = "CreditCardNumber is required")]
      public string CreditCardNumber { get; set; }

      public string FirstName { get; set; }
      public string LastName { get; set; }

      [Required(ErrorMessage = "StatusCard is required")]
      public string StatusCard { get; set; }

      [Required(ErrorMessage = "ReportedDate is required")]
      public DateTime ReportedDate { get; set; }

      [Required(ErrorMessage = "LastUpdatedDate is required")]
      public DateTime LastUpdatedDate { get; set; }
   }
}
