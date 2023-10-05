using System.ComponentModel.DataAnnotations;

namespace MoneyBankAPI.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="El tipo de cuenta es requerido")]
        [RegularExpression("[AC]",ErrorMessage ="El campo tipo de cuenta solo acepta valores (A,C)")]
        public char AccountType { get; set; } = 'A';

        [Required(ErrorMessage = "La fecha de creeación es requerida")]
        [DataType(DataType.Date,ErrorMessage ="El tipo dee dato del campo fecha de creación debe ser datetime")]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "El número de cuenta es requerido")]
        [RegularExpression("\\d{10}", ErrorMessage = "El campo número de cuenta solo acepta números de longitud 10")]
        public string AccountNumber { get; set; } = null!;

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(50, ErrorMessage = "El campo nombre debe tener una lóngitud máxima de 50 carácteres")]
        public string OwnerName { get; set; } = null!;

        [Required(ErrorMessage = "El monto del balance es requerido")]
        [RegularExpression("^\\d+.?\\d{0,2}$",ErrorMessage = "El campo Balance debe ser en formato Moneda (0.00)")]
        public Double BalanceAmount { get; set; }

        [Required(ErrorMessage = "El monto de sobregiro es requerido")]
        [RegularExpression("^\\d+.?\\d{0,2}$", ErrorMessage = "El campo Overdraft debe ser en formato Moneda (0.00)")]
        public Double OverdraftAmount { get; set; }
    }
}
