using System;
using System.ComponentModel.DataAnnotations;

namespace CreditBankAPI.Models
{
	public class ReportedCard
	{
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "IssuingNetwork is required")]
        public string IssuingNetwork { get; set; } = null!;

        [Required(ErrorMessage = "CreditCardNumber is required")]
        public string CreditCardNumber { get; set; } = null!;

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "StatusCard is required")]
        public string StatusCard { get; set; } = null!;

        [Required(ErrorMessage = "ReportedDate is required")]
        public DateTime ReportedDate { get; set; }

        [Required(ErrorMessage = "LastUpdatedDate is required")]
        public DateTime LastUpdatedDate { get; set; }
    }
}

