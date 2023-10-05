using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;
using MoneyBankAPI;

namespace MoneyBankAPI.Models
{
    public class Account
    {
        
        
        [Key]
        public  int Id { get; set; }

        [Required(ErrorMessage = "Tipo de cuenta requerido")]
        [RegularExpression("[AC]", ErrorMessage ="Los valores permitos son A o C")]
        public char AccountType { get; set; } = 'A';

        [Required(ErrorMessage = "Fecha de apertura de cuenta requerido")]
        [StringLength(19, ErrorMessage ="La Longitud Maxima del Nombre es de 19 Caracteres")]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Numero de cuenta requerido")]
        [StringLength(10, ErrorMessage ="La Longitud Maxima del Nombre es de 10 Caracteres")]
        public string AccountNumber { get; set; } = null!;

        [Required(ErrorMessage = "Nombre del propietario de la cuenta requerido")]
        [StringLength(50, ErrorMessage ="La Longitud Maxima del Nombre es de 50 Caracteres")]
        public string OwnerName { get; set; } = null!;

        [Required(ErrorMessage = "Balance de la cuenta requerido")]
        [Range(Constans.MIN_RANGE, int.MaxValue, ErrorMessage = "El valor debe ser mayor a 0")]
        public decimal BalanceAmount { get; set; }

        [Required(ErrorMessage = "Credito disponible requerido")]
        [Range(Constans.MIN_RANGE, Constans.MAX_OVERDRAFT, ErrorMessage = "El valor debe ser mayor a 0")]
        public decimal OverdraftAmount { get; set; }

        
    }

}
