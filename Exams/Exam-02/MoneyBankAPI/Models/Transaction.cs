using System.ComponentModel.DataAnnotations;

namespace MoneyBankAPI.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El número de cuenta es requerido")]
        [RegularExpression("\\d{10}", ErrorMessage = "El campo número de cuenta solo acepta números")]
        public string AccountNumber { get; set; } = null!;
        [Required(ErrorMessage = "El monto del balance es requerido")]
        [RegularExpression("^\\d+.?\\d{0,2}$", ErrorMessage = "El campo valordel monto debe ser en formato Moneda (0.00)")]
        public Double ValueAmount { get; set; }
    }
}
