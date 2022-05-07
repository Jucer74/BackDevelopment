namespace BankApp
{
    public class FillAccount: IFillAccount
    {
        private BankAccountBuilder bankAccountBuilder = new BankAccountBuilder();
        public FillAccount()
        {
        }

        public SavingAccount FillSavingAccountData(string accountNumber, string placeHolder, double balanceAmount,
            int accountType)
        {
            return bankAccountBuilder.BuildSavingAccount(accountNumber, placeHolder, balanceAmount, accountType);
        }

        public CheckingAccount FillChekingAccountData(string accountNumber, string placeHolder,
            double balanceAmount, int accountType, double overdraftAmount)
        {
            return bankAccountBuilder.BuildCheckingAccount(accountNumber, placeHolder, balanceAmount,
                accountType, overdraftAmount);
        }
    }
}
