using System.ComponentModel.DataAnnotations;

namespace ProductsApi.Models
{
   public class Product
   {
      [Key]
      public int Id { get; set; }

      [Required(ErrorMessage = "El nombre es requerido")]
      public string? Name { get; set; }

      public string? Description { get; set; }

      [Required(ErrorMessage ="El Precio es requerido")]
      public decimal? Price { get; set; }

      public string? ImageName { get; set; }
   }
}