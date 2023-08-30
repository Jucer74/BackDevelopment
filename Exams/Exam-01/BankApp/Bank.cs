

static class Bank
{
    private static List<IBankAccount> accountList = new List<IBankAccount>();

    public static bool FindAccount(string accountNumber) 
    { 
        bool found = false;
        foreach (var account in accountList) 
        {
            if (account.acccountNumber.Equals(accountNumber)) 
            {
                return true;
            };
        }
        return found;
    }

    public static IBankAccount ReturnAccount(string accountNumber)
    {
        IBankAccount accountVar = null;    
        bool found = false;
        foreach (var account in accountList)
        {
            if (account.acccountNumber.Equals(accountNumber))
            {
                accountVar = account;
                return accountVar;
            };
        }
        return accountVar;
    }

    public static void CreateAccount(IBankAccount bankAccount)
    {
        if (!FindAccount(bankAccount.acccountNumber)) 
        { 
            accountList.Add(bankAccount);
            Console.WriteLine($"Account : {bankAccount.acccountNumber} Created");
        }
        else 
        {
            Console.WriteLine($"Account : {bankAccount.acccountNumber} already exists");
        }
    }

    public static void GetBalanceAccount(string accountNumber)
    {
        bool accountSearch = FindAccount(accountNumber);

        if (accountSearch) 
        { 
            IBankAccount bankAccount = ReturnAccount(accountNumber);
            Console.WriteLine(
                $"{bankAccount.acccountNumber}\n" +
                $"{bankAccount.accountOwner}\n" +
                $"{bankAccount.accountType}\n" +
                $"{bankAccount.balanceAmount}\n");
        }
        else
        {
            Console.WriteLine("Account not found");
        }
    }

    public static void DepositAmount(string accountNumber, decimal amountValue)
    {
        IBankAccount accountDeposit = null;
        bool accountSearch = FindAccount(accountNumber);
        if (!accountSearch)
        {
            Console.WriteLine($"Account : {accountNumber} doesn't exist");
        }
        else
        {
            accountDeposit = ReturnAccount(accountNumber);
        }
        if (amountValue <= 0)
        {
            Console.WriteLine($"Invalid Amount");
        }
        accountDeposit.Deposit(amountValue);
        Console.WriteLine($"Deposit Success\n-----------\nNew Available Balance= {accountDeposit.balanceAmount}");
    }

    public static void WithdrawalAmount(string accountNumber, decimal amountValue)
    {
        IBankAccount accountDeposit = null;
        bool accountSearch = FindAccount(accountNumber);
        if (!accountSearch)
        {
            Console.WriteLine($"Account : {accountNumber} doesn't exist");
        }
        else
        {
            accountDeposit = ReturnAccount(accountNumber);
        }
        if (accountDeposit.balanceAmount > amountValue)
        {
            Console.WriteLine($"Insufficient Funds");
            return;
        }

        accountDeposit.Withdrawal(amountValue);
        Console.WriteLine($"Withdrawal Success\n-----------\nNew Available Balance= {accountDeposit.balanceAmount}");
    }
}