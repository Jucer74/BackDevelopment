using System.ComponentModel.DataAnnotations;

namespace MoneyBankAPI.Models
{
    public class Transaction
    {

        [Key]
        [Required(ErrorMessage = "proporcione un ID")]
        public int Identifier { get; set; }

        [Required(ErrorMessage = "Número de cuenta requerido")]
        [MaxLength(10, ErrorMessage = "El  campo de número de cuenta tiene una longitud máxima de 10 caracteres")]
        [RegularExpression(@"\d{10}", ErrorMessage = "El campo de numero de cuenta solo admite números")]
        public string AccountNo { get; set; } = null!;

        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "El valor debe estar en formato de moneda (0.00)")]
        public decimal Amount { get; set; }
    }
}
