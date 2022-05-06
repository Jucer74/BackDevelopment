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

      public override void Deposit(double despositValue)
      {
        this.BalanceAmount = this.BalanceAmount + despositValue;
      }

      public override double Balance()
      {
        return this.BalanceAmount;
      }

      public override void WithDrawal(double withdrawalValue)
      {
        this.BalanceAmount = this.BalanceAmount - withdrawalValue;
      }
   }
}