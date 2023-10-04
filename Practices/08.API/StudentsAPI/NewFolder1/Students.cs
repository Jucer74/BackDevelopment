using System.ComponentModel.DataAnnotations;

namespace StudentsAPI.NewFolder1
{
    public class Students
    {
        [Key]

        public int Id { get; set; }

        [Required(ErrorMessage ="El nombre es  requerido")]
        [StringLength(50, ErrorMessage ="La longitud Maxima del Nombre es de 50 caracteres")]

        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "El Apellido es  requerido")]
        [StringLength(50, ErrorMessage = "La longitud Maxima del Apellido es de 50 caracteres")]


        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "El Email es  requerido")]
        [StringLength(50, ErrorMessage = "El valor  introducido no es un email valido")]

        public string Email { get; set; } = null!;

        public  DateTime DateOfBirth { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "El Apellido es  requerido")]
        [RegularExpression("[MF]", ErrorMessage = "Los valores permitidos son M o F")]


        public char Sex { get; set; }= 'M';


    }
}
