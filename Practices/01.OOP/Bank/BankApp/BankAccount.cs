
namespace BankApp
{
   public abstract class BankAccount
   {
      #region Properties
      public string AcountNumber { get; set; }
      public string PlaceHolder { get; set; }
      public decimal BalanceAmount { get; set; }
      public int AccountType { get; set; }

      #endregion Properties

      #region Methods
      public virtual void Deposit(decimal amount)
      {
         this.BalanceAmount += amount;
      }

      public virtual void Withdrawal (decimal amount)
      {
         this.BalanceAmount -= amount;
      }

      #endregion Methods
   }
}
