using System.ComponentModel.DataAnnotations;

namespace SOLID.Principles.Dto;

public class ProjectDto
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;

    [Required]
    public char Type { get; set; }

    [Required]
    public string DepartmentName { get; set; } = null!;

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public decimal Budget { get; set; }

    [Required]
    public string ContractorName { get; set; } = null!;
}