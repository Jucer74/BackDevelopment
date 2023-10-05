using System.ComponentModel.DataAnnotations;

namespace MoneyBankAPI.Models
{
    public class Account
    {
        [Key]
        [Required(ErrorMessage = "Por favor ingrese ID")]
        public int Id { get; set; }

        [RegularExpression("[AC]", ErrorMessage = "El Tipo de Cuenta solo permite (A o C)")]
        [Required(ErrorMessage = "Tipo de Cuenta obligatorio")]
        public char AccountType { get; set; } = 'A';

        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        
        [Required(ErrorMessage = "Numero de Cuenta obligatorio")]
        [MaxLength(10, ErrorMessage = "El Numero de La Cuenta tiene una longitud maxima de 10 caracteres")]
        [RegularExpression(@"\d{10}", ErrorMessage = "El Numero de la Cuenta Solo Acepta Numeros")]
        public string AccountNumber { get; set; } = null!;

        [Required(ErrorMessage = "Nombre del Propietario es Requerido")]
        [StringLength(50)]
        public string OwnerName { get; set; } = null!;

        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = " Balance debe ser en formato Moneda (0.00)")]
        [Required(ErrorMessage = "Deposito Inicial obligatorio")]
        public decimal BalanceAmount { get; set; }

        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = " Balance debe ser en formato Moneda (0.00)")]
        public decimal OverdraftAmount { get; set; }
    }
}
