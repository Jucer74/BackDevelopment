namespace Solid.Principles.Dto
{
  using System;
  using System.ComponentModel.DataAnnotations;

  public class EmployeeDto
  {
    public int Id { get; set; }

    [Required] public string FirstName { get; set; }

    [Required] public string LastName { get; set; }

    [Required]
    public DateTime HireDate { get; set; }

    [Required] public string Email { get; set; }

    public string Phone { get; set; }
  }
}
