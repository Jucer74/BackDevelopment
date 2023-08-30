
namespace BankApp;
public static class Bank
{

	private static List<BankAccount> accountList { get; set; } = new List<BankAccount>();


	public static void CreateAccount(BankAccount bankAccount) {

		if (!ValidateAcountExistence(bankAccount.accountNumber))
		{
            accountList.Add(bankAccount);
			Console.WriteLine("\nAccount Created\n");
        }
		else
		{
			Console.WriteLine("\nAccount :"+bankAccount.accountNumber+ " already exists\n");
		}
	}

	private static bool ValidateAcountExistence(String accountNumber)
	{
        int accountListLength = accountList.Count;

		for(int idx = 0; idx < accountListLength; idx++)
		{
			if (accountList[idx].accountNumber.Equals(accountNumber))
			{
				return true;
			}
		}

		return false;
	}

	public static void GetBalanceAccount(String accountNumber) {
		if (ValidateAcountExistence(accountNumber))
		{
			Console.WriteLine(GetBankAccountByAccountNumber(accountNumber)!.getBalance());
        }
		else
		{
            Console.WriteLine("\nAccount :" + accountNumber + " doesn't exist\n");
        }
            
    }

	private static BankAccount? GetBankAccountByAccountNumber(String accountNumber)
	{
        foreach (BankAccount bankAccount in accountList)
        {
            if (bankAccount.accountNumber.Equals(accountNumber)) { return bankAccount; }
        }

		return null;
    }


	public static void DepositAmount(String accountNumber, decimal amountValue) {
		if (ValidateAcountExistence(accountNumber))
		{
            GetBankAccountByAccountNumber(accountNumber)!.Deposit(amountValue);
        }
		else
		{
            Console.WriteLine("\nAccount :" + accountNumber + " doesn't exist\n");
        }
	}

	public static void WithdrawalAmount(String accountNumber, decimal amountValue) {
        if (ValidateAcountExistence(accountNumber))
        {
            GetBankAccountByAccountNumber(accountNumber)!.Withdrawal(amountValue);
        }
        else
        {
            Console.WriteLine("\nAccount :" + accountNumber + " doesn't exist\n");
        }
    }
}


