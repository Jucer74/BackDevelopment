using System;
using System.ComponentModel.DataAnnotations;

namespace CreditBank.Api.Models
{
    public class ReportedCard
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "IssuingNetwork is required")]
        [StringLength(50, ErrorMessage = "The maximum length of IssuingNetwork is 50 characters")]
        public string IssuingNetwork { get; set; } = null!;

        [Required(ErrorMessage = "CreditCardNumber is required")]
        [StringLength(20, ErrorMessage = "The maximum length of CreditCardNumber is 20 characters")]
        public string CreditCardNumber { get; set; } = null!;

        [Required(ErrorMessage = "FirstName is required")]
        [StringLength(50, ErrorMessage = "The maximum length of FirstName is 50 characters")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "LastName is required")]
        [StringLength(50, ErrorMessage = "The maximum length of LastName is 50 characters")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "StatusCard is required")]
        [StringLength(20, ErrorMessage = "The maximum length of StatusCard is 50 characters")]
        public string StatusCard { get; set; } = "Stolen";

        [Required(ErrorMessage = "ReportedDate is required")]
        [DataType(DataType.Date)]
        public DateTime ReportedDate;
    }
}
