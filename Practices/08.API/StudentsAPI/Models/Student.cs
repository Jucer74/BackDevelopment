using System.ComponentModel.DataAnnotations;

namespace StudentsAPI.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="El Nombre es requerido")]
        [StringLength(50, ErrorMessage ="La Longitud Maxima del Nombre es de 50 Caracteres")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "El Apellido es requerido")]
        [StringLength(50, ErrorMessage = "La Longitud Maxima del Apellido es de 50 Caracteres")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "El Email es requerido")]
        [EmailAddress(ErrorMessage ="El valor introducido no es un email valido")]
        public string Email { get; set; } = null!;
        public DateTime DateOfBirth { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "El Apellido es requerido")]
        [RegularExpression("[MF]", ErrorMessage ="Los valores permitos son M o F")]
        public char Sex { get; set; } = 'M';
    }
}