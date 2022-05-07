namespace Bank
{
  using System;
  using System.ComponentModel.DataAnnotations;

  public class AccountDto
  {
    [Required]
    public long AccountNumber { get; set; }

    [Required]
    public string? PlaceHolder { get; set; }

    [Required]
    public string? AccountType { get; set; }
 
    [Required]
    public double? OverdraftAmount { get; set; }

    [Required]
    public double? BalanceAmount { get; set; }
 
  }
}
