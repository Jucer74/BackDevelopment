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
                              double balanceAmount,
                              int accountType):
      base(accountNumber,placeHolder,balanceAmount,accountType)
      {

      }

      public void Deposit(double despositValue)
      {
        this.BalanceAmount = this.BalanceAmount + despositValue;
      }

      public double Balance()
      {
        return this.BalanceAmount;
      }

      public void WithDrawal(double withdrawalValue)
      {
        this.BalanceAmount = this.BalanceAmount - withdrawalValue;
      }
   }
}