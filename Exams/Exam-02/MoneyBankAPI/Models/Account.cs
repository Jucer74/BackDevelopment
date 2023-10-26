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
        public char AccountType { get; set; } = Constants.ACCOUNT_TYPE_SAVINGS;

        [Required(ErrorMessage = "Fecha de apertura de cuenta requerido")]
        //Esta Anotacion es incorrecta
        //[StringLength(Constants.DATETIME_LENGTH, ErrorMessage ="La Longitud Maxima del Nombre es de 19 Caracteres")]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Numero de cuenta requerido")]
        [StringLength(Constants.STR_LENGTH_ACCOUNT_NUMBER, ErrorMessage ="La Longitud Maxima del Nombre es de 10 Caracteres")]
        public string AccountNumber { get; set; } = null!;

        [Required(ErrorMessage = "Nombre del propietario de la cuenta requerido")]
        [StringLength(Constants.OWNERNAME_LENGTH, ErrorMessage ="La Longitud Maxima del Nombre es de 50 Caracteres")]
        public string OwnerName { get; set; } = null!;

        [Required(ErrorMessage = "Balance de la cuenta requerido")]
        // El Valor es un Decimal, No se uede usar in IN.MAXVALUE por que es un valor Entero
        //[Range(Constants.MIN_RANGE, int.MaxValue, ErrorMessage = "El valor debe ser mayor a 0")]
        public decimal BalanceAmount { get; set; }

        [Required(ErrorMessage = "Credito disponible requerido")]
        // Igual que el Valor Anterior
        //[Range(Constants.MIN_RANGE, Constants.MAX_OVERDRAFT, ErrorMessage = "El valor debe ser mayor a 0")]
        public decimal OverdraftAmount { get; set; }

        
    }

}
