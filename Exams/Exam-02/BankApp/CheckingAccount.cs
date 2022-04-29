namespace BankApp
{
   public class CheckingAccount : BankAccount
   {
      private const decimal MIN_OVERDRAFT_AMOUNT = 1000000;

      #region Properties

      public decimal OverdraftAmount { get; set; }

      #endregion Properties

      public CheckingAccount()
      {

      }

      public CheckingAccount(int acountType, string acountNumber, string placeHolder, decimal balanceAmount)
      {
         this.AccountType = acountType;
         this.AccountNumber = acountNumber;
         this.PlaceHolder = placeHolder;
         this.BalanceAmount = balanceAmount + MIN_OVERDRAFT_AMOUNT;
      }

      #region Methods

      public override void Deposit(decimal amount)
      {
         base.Deposit(amount);

         if (BalanceAmount >=  MIN_OVERDRAFT_AMOUNT)
         {
            OverdraftAmount = 0;
         }
      }

      public override void Withdrawal(decimal amount)
      {
         base.Withdrawal(amount);

         if (BalanceAmount < MIN_OVERDRAFT_AMOUNT)
         {
            OverdraftAmount = MIN_OVERDRAFT_AMOUNT - BalanceAmount;
         }
         
      }

      #endregion Methods
   }
}