namespace BankApp
{
    public class CreateAccount: ICreateAccount
    {
        private BankAccountBuilder bankAccountBuilder = new BankAccountBuilder();
        public CreateAccount()
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
