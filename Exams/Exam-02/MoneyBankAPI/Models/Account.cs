using System.ComponentModel.DataAnnotations;

namespace MoneyBankAPI.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [RegularExpression("[AC]", ErrorMessage = "Tipo de Cuenta solo permite (A o C)")]
        public char AccountType { get; set; } = 'A';

        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [MaxLength(10, ErrorMessage = "El Numero de La Cuenta tiene una longitud maxima de 10 caracteres")]
        [RegularExpression(@"\d{10}", ErrorMessage = "El Numero de la Cuenta Solo Acepta Numeros")]
        public string AccountNumber { get; set; } = null!;

        [Required(ErrorMessage = "Nombre del Propietario es Requerido")]
        public string OwnerName { get; set; } = null!;

        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = " Balance debe ser en formato Moneda (0.00)")]
        public decimal BalanceAmount { get; set; }


        public decimal OverdraftAmount { get; set; }
    }
}
