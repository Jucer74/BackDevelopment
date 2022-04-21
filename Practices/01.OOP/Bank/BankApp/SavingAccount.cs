using System;

namespace BankApp
{
   public class SavingAccount : BankAccount
   {
      public SavingAccount()
      {
          
      }

      public SavingAccount(int accountNumber,
                              string placeHolder,
                              decimal balanceAmount,
                              int accountType):
      base(accountNumber,placeHolder,balanceAmount,accountType,overdrafAmount)
      {

      }

      public void Deposit(decimal despositValue)
      {
        this.BalanceAmount = this.BalanceAmount + despositValue;
      }

      public decimal Balance()
      {
        return this.balanceAmount;
      }

      public void WithDrawal(decimal withdrawalValue)
      {
        this.BalanceAmount = this.BalanceAmount - withdrawalValue;
      }
   }
}