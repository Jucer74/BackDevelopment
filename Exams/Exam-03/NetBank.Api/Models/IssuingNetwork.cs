using System.ComponentModel.DataAnnotations;

namespace NetBank.Api.Models;

public class IssuingNetwork
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string IssuingNetworkName { get; set; } = null!;

    public string? StartsWithNumbers { get; set; } = null!;

    public string? InRange { get; set; } = null!;

    [Required]
    public string AllowedLengths { get; set; } = null!;
}