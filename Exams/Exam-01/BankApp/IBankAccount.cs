


using BankApp;

public interface IBankAccount
{
    string acccountNumber { get;set; }
    string accountOwner { get;set; }
    decimal balanceAmount { get;set; }
    AccountType accountType { get;set; }

    void Deposit(decimal amount)
    {
        balanceAmount = balanceAmount + amount;
    }
    void Withdrawal(decimal amount)
    {
        SavingAccount savingAccount = null;
        CheckingAccount checkingAccount = null;

        if (balanceAmount >= amount && AccountType.Saving == accountType)
        { 
            savingAccount.Withdrawal(amount: amount);
        }else if(balanceAmount >= amount && AccountType.Checking == accountType)
        {
            checkingAccount.Withdrawal(amount: amount);
        }else{
            Console.WriteLine("No puede sacar mas de lo que tiene");
        }
    }
}





