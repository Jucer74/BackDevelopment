using System.ComponentModel.DataAnnotations;

namespace SOLID.Principles.Dto;

public class EmployeeDto
{
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; } = null!;

    [Required]
    public string LastName { get; set; } = null!;

    [Required]
    public DateTime HireDate { get; set; }

    [Required] public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;
}