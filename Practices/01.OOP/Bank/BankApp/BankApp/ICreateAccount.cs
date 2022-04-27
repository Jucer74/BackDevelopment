namespace BankApp
{
    public interface ICreateAccount
    {
        CheckingAccount FillChekingAccountData(string accountNumber, string placeHolder, double balanceAmount,
                   int accountType, double overdraftAmount);

        SavingAccount FillSavingAccountData(string accountNumber,string placeHolder,double balanceAmount,
            int accountType);
    }
}
