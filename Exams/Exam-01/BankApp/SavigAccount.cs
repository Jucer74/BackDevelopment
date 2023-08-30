namespace BankApp{
    
    public class SavingAccount : IBankAccount
    {
        public string acccountNumber {get;set;}

        public string accountOwner {get;set;}

        public decimal balanceAmount {get;set;}

        public AccountType accountType {get;set;}

        public SavingAccount(AccountType accountType, string acccountNumber, string accountOwner, decimal balanceAmount)
        {
            this.acccountNumber = acccountNumber;
            this.accountOwner = accountOwner;
            this.balanceAmount = balanceAmount;
            this.accountType = AccountType.Saving;
        }

        public void Deposit(decimal amount)
        {
            balanceAmount += balanceAmount;
        }

        public void Withdrawal(decimal amount)
        {
            if (balanceAmount >= amount)
            {
                balanceAmount -= amount;
            }
            else
            {
                Console.WriteLine("Insufficients funds");
            }
        }
    }
}