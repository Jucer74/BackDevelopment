using System.ComponentModel.DataAnnotations;

namespace MoneyBankAPI.Models
{
    public class Transaction
    {
        [Key]
        [Required(ErrorMessage = "Por favor ingrese ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Numero de Cuenta obligatorio")]
        [MaxLength(10, ErrorMessage = "El Numero de La Cuenta tiene una longitud maxima de 10 caracteres")]
        [RegularExpression(@"\d{10}", ErrorMessage = "El Numero de la Cuenta Solo Acepta Numeros")]
        public string AccountNumber { get; set; } = null!;

        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = " valor debe ser en formato Moneda (0.00)")]
        public decimal ValueAmount { get; set; }
    }
}
