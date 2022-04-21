
namespace BankApp
{
   public class CeckingAccount: BankAccount
   {
      #region Properties
      public decimal AvoerdraftAmount { get; set; }   
      #endregion Properties
      

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
