using System.ComponentModel.DataAnnotations;

namespace MoneyBankAPI.Models
{
    public class Account
    {
        [Required(ErrorMessage = "Id requerido")]
        public  int Id { get; set; }
        [Required(ErrorMessage = "Tipo de cuenta requerido")]
        public char AccountType { get; set; } = 'A';
        [Required(ErrorMessage = "Fecha de apertura de cuenta requerido")]
        public DateTime CreationDate { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Numero de cuenta requerido")]
        public string AccountNumber { get; set; } = null!;
        [Required(ErrorMessage = "Nombre del propietario de la cuenta requerido")]
        public string OwnerName { get; set; } = null!;
        [Required(ErrorMessage = "Balance de la cuenta requerido")]
        public decimal BalanceAmount { get; set; }
        [Required(ErrorMessage = "Credito disponible requerido")]
        public decimal OverdraftAmount { get; set; }
    }

}
