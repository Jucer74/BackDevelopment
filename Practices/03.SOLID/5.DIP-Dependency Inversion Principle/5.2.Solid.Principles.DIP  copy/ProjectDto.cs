namespace Solid.Principles.Dto
{
  using System;
  using System.ComponentModel.DataAnnotations;

  public class ProjectDto
  {
    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public char Type { get; set; }

    [Required]
    public string DepartmentName{ get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public decimal Budget { get; set; }

    [Required]
    public string ContractorName { get; set; }
  }
}
