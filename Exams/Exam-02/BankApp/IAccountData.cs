namespace Bank
{
  using System.Collections.Generic;

  public interface IAccountData
  {
        public AccountDto GetAccount(long accountNumber);
        public void CreateAccount(AccountDto createAccount);
        public void DepositAccount(long accountNumber, decimal amount);
        public void GetBalance(AccountDto accountDto);


  }
}