using System;

namespace BankApp
{
   public class CheckingAccount : BankAccount
   {
      public bool OverdrafAmount { get; set; }

      public CheckingAccount()
      {
         
      }

      public CheckingAccount(int accountNumber,
                              string placeHolder,
                              decimal balanceAmount,
                              int accountType):
      base(accountNumber,placeHolder,balanceAmount,accountType)
      {
         this.OverdrafAmount = false;
      }

      public void Deposit(decimal despositValue)
      {
         this.BalanceAmount = this.BalanceAmount + despositValue;
         if(isOverdrafAmount()){
            OverdrafAmount = true;
         }
      }

      public decimal Balance()
      {
         return this.balanceAmount;
      }

      public void WithDrawal(decimal withdrawalValue)
      {
         this.BalanceAmount = this.BalanceAmount - withdrawalValue;
         if(isOverdrafAmount()){
            OverdrafAmount = true;
         }
      }

      public bool isOverdrafAmount()
      {
         return this.BalanceAmount <= 0;
      }
   }
}