namespace BankApp
{
   public class SavingAccount : BankAccount
   {

      public SavingAccount()
      {

      }

      public SavingAccount(int acountType, string acountNumber, string placeHolder, decimal balanceAmount)
      {
         this.AccountType = acountType;
         this.AccountNumber = acountNumber;
         this.PlaceHolder = placeHolder;
         this.BalanceAmount = balanceAmount;
      }
   }
}