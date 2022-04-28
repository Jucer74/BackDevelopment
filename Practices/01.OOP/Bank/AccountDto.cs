namespace Bank.Dto
{
  using System;
  using System.ComponentModel.DataAnnotations;

  public class AccountDto
  {
    [Required]
    public int accountNumber { get; set; }

    [Required]
    public string placeHolder { get; set; }

    [Required]
    public double balanceAmount { get; set; }

    [Required]
    public double overDraftAmount { get; set; }

    [Required]
    public int accountType { get; set; }


  }
}
