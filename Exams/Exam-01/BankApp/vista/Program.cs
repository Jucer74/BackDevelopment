

namespace BankApp;

public class Program
{

    private static int selection = 0;
    private static readonly int ACCOUNT_NUMBER_SIZE = 10;
    private static readonly int ACCOUNT_OWNER_MIN_SIZE = 0;
    private static readonly int ACCOUNT_OWNER_MAX_SIZE = 50;
    private static readonly int ACCOUNT_AMOUNT_MIN_SIZE = 1;
    private static readonly int ACCOUNT_AMOUNT_MIN_VALUE = 0;


    private static void Menu()
    {
        do
        {
            Console.WriteLine("\nBanking Operation");
            Console.WriteLine("-----------------");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Get Balance");
            Console.WriteLine("3. Deposit Amount");
            Console.WriteLine("4. Withdrawal Amount");
            Console.WriteLine("5. Salir");
            bool isNumber;
        
            Console.WriteLine("\nSelect Option: ");
            isNumber = int.TryParse(Console.ReadLine(), out int selectionOut);
            selection = selectionOut;
            if (!isNumber || (selection<=0 || selection>5))
            {
                Console.WriteLine("\nBad Selection!");
            }
            else
            {
                switch (selection)
                {
                    case 1:
                        CreateAccount();
                        break;
                    case 2:
                        GetBalance();
                        break;
                    case 3:
                        DepositAmount();
                        break;
                    case 4:
                        WithdrawalAmount();
                        break;
                }
            }
        } while (selection!=5);
        Console.WriteLine("\nGood bye\n");
        Console.WriteLine(CustomGoodBye.JODA_ASCII_ART);
    }

    public static void CreateAccount()
    {
        Console.WriteLine("\nCreate Account");
        Console.WriteLine("------------");
        String accountType = GetValidAccountType();
        String accountNumber = GetValidAccountNumber();
        String accountOwner = GetValidAccountOwner();
        String amount = GetValidAmount();
        CreateBankAccount(accountType,accountNumber,accountOwner,amount);
    }

    public static String GetValidAccountType()
    {
        String accountType;
        bool isValid;
        do
        {
            Console.WriteLine("Account Type (1-Saving , 2-Checking): ");
            accountType = Console.ReadLine()!;
            if (!(int.Parse(accountType)==(int)AccountType.savingAccount)
                && !(int.Parse(accountType)==(int)AccountType.checkingAccount))
            {
                Console.WriteLine("\nMust have 1 or 2\n");
                isValid = false;
            }
            else { isValid = true; }
        } while (!isValid);
        return accountType;
    }

    public static String GetValidAccountNumber()
    {
        bool isValid;
        String accountNumber;
        do
        {
            Console.WriteLine("Account Number: ");
            accountNumber = Console.ReadLine()!;
            if (!IsValidAccountNumber(accountNumber))
            {
                Console.WriteLine("\nMust have 10 digits\n");
                isValid = false;
            }
            else { isValid = true; }
        } while (!isValid);
        return accountNumber;
    }

    public static String GetValidAccountOwner()
    {
        bool isValid;
        String accountOwner;
        do
        {
            Console.WriteLine("Account Owner: ");
            accountOwner = Console.ReadLine()!;
            if (!IsValidAccountOwner(accountOwner))
            {
                Console.WriteLine("\nis required and max length is 50 characters\n");
                isValid = false;
            }
            else { isValid = true; }
        } while (!isValid);
        return accountOwner;
    }

    public static String GetValidAmount()
    {
        bool isValid;
        String balanceAmount;
        do
        {
            Console.WriteLine("Amount: ");
            balanceAmount = Console.ReadLine()!;
            if (!IsValidAmount(balanceAmount))
            {
                Console.WriteLine("\nAmount is required and must be numeric and greater than zero\n");
                isValid = false;
            }
            else { isValid = true; }
        } while (!isValid);
        return balanceAmount;
    }

    public static void CreateBankAccount(String accountType, String accountNumber, String accountOwner, String amount)
    {
        BankAccount bankAccount = null!;

        switch (int.Parse(accountType))
        {
            case (int) AccountType.checkingAccount:
                bankAccount = new CheckingAccountCreator().FactoryAccount(accountNumber, accountOwner, decimal.Parse(amount), int.Parse(accountType));
                break;
            case (int)AccountType.savingAccount:
                bankAccount = new SavingAccountCreator().FactoryAccount(accountNumber, accountOwner, decimal.Parse(amount), int.Parse(accountType));
                break;
        }

        Bank.CreateAccount(bankAccount);
    }

    public static void GetBalance()
    {
        Console.WriteLine("\nGet Balance");
        Console.WriteLine("------------");
        String accountNumber = GetValidAccountNumber();
        Bank.GetBalanceAccount(accountNumber);
    }

    public static bool IsValidAccountNumber(String accountNumber)
    {
        return (accountNumber.Length == ACCOUNT_NUMBER_SIZE) && int.TryParse(accountNumber, out _);
    }

    public static bool IsValidAccountOwner(String accountOwner)
    {
        return (accountOwner.Replace(" ", "").Length > ACCOUNT_OWNER_MIN_SIZE
            && accountOwner.Replace(" ", "").Length < ACCOUNT_OWNER_MAX_SIZE);
    }

    public static bool IsValidAmount(String amount)
    {
        return (amount.Length >= ACCOUNT_AMOUNT_MIN_SIZE)
            && int.TryParse(amount, out int outAmount)
            && outAmount > ACCOUNT_AMOUNT_MIN_VALUE;
    }

    public static void DepositAmount()
    {
        String accountNumber = GetValidAccountNumber();
        String amount = GetValidAmount();
        Bank.DepositAmount(accountNumber,decimal.Parse(amount));
    }

    public static void WithdrawalAmount()
    {
        String accountNumber = GetValidAccountNumber();
        String amount = GetValidAmount();
        Bank.WithdrawalAmount(accountNumber, decimal.Parse(amount));
    }

    public static void Main(string[] args)
    {
        Menu();
    }

}