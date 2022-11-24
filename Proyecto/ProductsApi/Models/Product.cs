using System.ComponentModel.DataAnnotations;

namespace ProductsApi.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre es requerido")]
        [StringLength(50, ErrorMessage = "La longitud maxima del Nombre es de 50 caracteres")]
        public string Name { get; set; } = null!;

        [StringLength(255, ErrorMessage = "La longitud maxima de la Descripcion es de 255 caracteres")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "El Precio es requerido")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "El Nombre de la Imagen es requerido")]
        [StringLength(50, ErrorMessage = "La longitud maxima del Nombre de la Imagen es de 50 caracteres")]
        public string? ImageName { get; set; }
    }
}   