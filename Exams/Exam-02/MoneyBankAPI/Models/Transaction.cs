using System.ComponentModel.DataAnnotations;

namespace MoneyBankAPI.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Numero de cuenta requerido")]
        [StringLength(Constants.STR_LENGTH_ACCOUNT_NUMBER, ErrorMessage ="La Longitud Maxima del Nombre es de 10 Caracteres")]
        public string AccountNumber { get; set; } = null!;

        [Required(ErrorMessage = "Balance de la cuenta requerido")]
        [Range(Constants.MIN_RANGE, int.MaxValue, ErrorMessage = "El valor debe ser mayor a 0")]
        public decimal ValueAmount { get; set; }
    }

    

}
