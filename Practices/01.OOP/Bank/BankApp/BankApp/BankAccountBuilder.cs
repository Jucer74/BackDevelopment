namespace BankApp
{
    public class BankAccountBuilder
    {
        private CheckingAccount checkingAccount;
        private SavingAccount savingAccount;

        public BankAccountBuilder()
        {
        }

        public CheckingAccount BuildCheckingAccount(string accountNumber, string placeHolder,
            double balanceAmount, int accountType, double overdraftAmount)
        {
            checkingAccount = new CheckingAccount
            {
                AccountNumber = accountNumber,
                PlaceHolder = placeHolder,
                BalanceAmount = balanceAmount,
                AccountType = accountType,
                OverDraftAmount = overdraftAmount
            };

            return checkingAccount;
        }

        public SavingAccount BuildSavingAccount(string accountNumber, string placeHolder,
            double balanceAmount, int accountType)
        {
            savingAccount = new SavingAccount
            {
                AccountNumber = accountNumber,
                PlaceHolder = placeHolder,
                BalanceAmount = balanceAmount,
                AccountType = accountType
            };

            return savingAccount;
        }
    }
}
