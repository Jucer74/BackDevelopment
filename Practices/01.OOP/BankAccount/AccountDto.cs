namespace BankAccount
{
  using System;
  using System.ComponentModel.DataAnnotations;

  [Serializable]
  public class AccountDto
  {
    [Required] public int AccountNumber { get; set; }

    [Required] public string PlaceHolder { get; set; }

    [Required] public string AccountType { get; set; }

    [Required] public int BalanceAmount { get; set; }

    [Required] public int OverdraftAmount { get; set; }

  }
}