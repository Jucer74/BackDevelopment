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
                              double balanceAmount,
                              int accountType) :
      base(accountNumber, placeHolder, balanceAmount, accountType)
      {
         this.OverdrafAmount = false;
      }

      public override void Deposit(double despositValue)
      {
         this.BalanceAmount = this.BalanceAmount + despositValue;
         if (isOverdrafAmount())
         {
            OverdrafAmount = true;
         }
      }

      public override double Balance()
      {
         return this.BalanceAmount;
      }

      public override void WithDrawal(double withdrawalValue)
      {
         this.BalanceAmount = this.BalanceAmount - withdrawalValue;
         if (isOverdrafAmount())
         {
            OverdrafAmount = true;
            this.BalanceAmount = this.BalanceAmount - 1000.00;
         }
      }

      // Funciones son PascalCase
      // Que tiene de diferete al uso de la Propiedad??
      public bool isOverdrafAmount()
      {
         return this.BalanceAmount <= 0;
      }
   }
}