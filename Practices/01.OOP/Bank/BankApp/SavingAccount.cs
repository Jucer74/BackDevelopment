
namespace BankApp
{
   public class SavingAccount: BankAccount
   {
      #region Methods
      public override void Deposit(decimal amount)
      {
         base.Deposit(amount);
      }

      public override void Withdrawal (decimal amount)
      {
         base.Withdrawal(amount);
      }

      #endregion Methods
   }
}
