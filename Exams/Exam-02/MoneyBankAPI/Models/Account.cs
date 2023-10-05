using System.ComponentModel.DataAnnotations;

namespace MoneyBankAPI.Models
{
    public class Account
    {
        [Key]

        public int Id { get; set; }

        //[Required(ErrorMessage = "El campo Nombre del Propietario es Requerido")]
        //[StringLength(100, ErrorMessage = "El nombre  no puede ser mas grande que 50 caracteres")]

        [Required(ErrorMessage="La opcion es incorrecta")]
        [RegularExpression("[AC]", ErrorMessage = "El campo Tipo de Cuenta solo permite (A o C)")]
        public char AccountType { get; set; } = 'A';

        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [RegularExpression("^[0-9]+$", ErrorMessage = "El campo Número de Cuenta solo puede contener números")]
        [StringLength(10, ErrorMessage = "El número de cuenta solo puede tener 10 caracteres")]
        public string AccountNumber { get; set; } = null!;

        [Required(ErrorMessage = "El campo Nombre del Propietario es Requerido")]
        public string OwnerName { get; set; } = null!;

        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "El campo Balance debe tener el formato Moneda (0.00)")]
        public decimal BalanceAmount { get; set; }


        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "El campo Overdraft debe tener el formato Moneda (0.00)")]
        public decimal OverdraftAmount { get; set; }
    }
}
