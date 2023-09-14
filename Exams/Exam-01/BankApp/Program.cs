using System.Text.RegularExpressions;
using BankApp;

public class Pogram
{
    private const decimal V = (decimal)0.10;

    public static void Main(string[] args)
    {
        try
        {
            Menu();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    public static void Menu()
    {
        Options option = Options.Invalid;

        while (option != Options.Exit)
        {
            Console.Clear();
            Console.WriteLine("     Bank Options    ");
            Console.WriteLine("------------------------------");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Get Balance Account");
            Console.WriteLine("3. Deposit Account");
            Console.WriteLine("4. Withdrawal Account");
            Console.WriteLine("0. Exit");
            Console.WriteLine("Select Option:");

             // Lee el carácter del usuario y lo convierte a una opción válida
            if (Enum.TryParse(Console.ReadKey().KeyChar.ToString(), out option))
            {
                Console.Clear();

                switch (option)
                {
                    case Options.Exit:
                        Console.WriteLine("Exiting Bank App...");
                        break;
                    case Options.CreateAccount:
                        CreateAccount();
                        break;
                    case Options.GetBalance:
                        GetBalance();
                        break;
                    case Options.DepositAmount:
                        DepositAmount();
                        break;
                    case Options.WithdrawalAmount:
                        WithdrawalAmount();
                        break;

                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            }
            Console.WriteLine("\nPress any key to continue... ");
            Console.ReadKey();
        }
    }
    public static bool IsValidAccountNumber(string accountNumber)
    {   
        return accountNumber.Length == 10 && Regex.IsMatch(accountNumber, "^[0-9]+$");
    }

    public static bool IsValidAmount(decimal inputAmount)
    {
        return inputAmount > 0;
    }

    public static bool IsValidAccountOwner(string accountOwner)
    {
        return !string.IsNullOrEmpty(accountOwner) && accountOwner.Length <= 50;
    }

    public static AccountType GetValidAccountType()
    {
        char accountTypeValidator = '0';
        while (!IsValidAccoutnType(accountTypeValidator))
        {
            Console.Write("Account type (1-Saving, 2-Checking): ");
            accountTypeValidator = Console.ReadKey().KeyChar;
            if(!IsValidAccoutnType(accountTypeValidator))
            {
                Console.WriteLine("Only 1 or 2 can be choosen");
            }
        };

        Console.WriteLine();
        return accountTypeValidator.Equals('1') ? AccountType.Saving : AccountType.Checking;
    }

    public static bool IsValidAccoutnType(char accountType)
    {
        return accountType.Equals('1') || accountType.Equals('2');
    }

    public static string GetValidAccountNumber()
    {
        // Fix the Format
        bool isValid;
        Console.Write("Account Number: ");
        string accountNumber = Console.ReadLine() ?? "";
        isValid = IsValidAccountNumber(accountNumber);
        if (!isValid)
        {
            Console.WriteLine("Invalid Account Number: must be 10 digits");
            GetValidAccountNumber();
        }
        return accountNumber;
    }

    public static decimal GetValidAmount(string titleAmount)
    {
        string inputAmount;
        bool isValid;
        Console.Write($"{titleAmount}: ");
        inputAmount = Console.ReadLine() ?? "";
        isValid = IsValidAmount(Decimal.Parse(inputAmount));
        if (!isValid)
        {
            Console.WriteLine("Amount is required and must be numeric and greater than zero.");
        }
        return decimal.Parse(inputAmount);
    }

    public static string GetValidAccountOwner()
    {
        string accountOwner;
        bool isValid;
        Console.Write("Account Owner: ");
        accountOwner = Console.ReadLine() ?? "";
        isValid = IsValidAccountOwner(accountOwner);
        if (!isValid)
        {
            Console.WriteLine("Account Owner is required and max length is 50 characters");
        }
        return accountOwner;
    }

    public static void WithdrawalAmount()
    {
        Console.WriteLine("Withdrawal Amount\n"+ "\"-----------------\"");
        string accountNumber = GetValidAccountNumber();
        decimal amount = GetValidAmount("Amount to withdrawal");
        Bank.WithdrawalAmount(accountNumber, amount);
    }

    public static void DepositAmount()
    {
        Console.WriteLine("Deposit  Amount\n" + "\"-----------------\"");
        string accountNumber = GetValidAccountNumber();
        decimal amount = GetValidAmount("Amount to deposit");
        Bank.DepositAmount(accountNumber, amount);
    }

    public static void GetBalance()
    {
        Console.WriteLine("Get Balance Amount\n" + "\"-----------------\"");
        string accountNumber = GetValidAccountNumber();
        Bank.GetBalanceAccount(accountNumber);
    }


    public static void CreateAccount()
    {
        Console.WriteLine("Get Balance Amount\n" + "\"-----------------\"");
        AccountType accountType = GetValidAccountType();
        string accountNumber = GetValidAccountNumber();
        string accountOwner = GetValidAccountOwner();
        decimal initialBalanceAmount = GetValidAmount("Initial Balance Amount");
        decimal overdraftAmount;


        if (Bank.FindAccount(accountNumber))
        {
            Console.WriteLine("Account already exists.");
        }
        else
        {
            if (accountType == AccountType.Saving)
            {
                IBankAccount newAccount = new SavingAccount(accountType, accountNumber, accountOwner, initialBalanceAmount);
                Bank.CreateAccount(newAccount);
            }
            else
            {
                overdraftAmount = initialBalanceAmount * V; 
                
                IBankAccount newAccount = new CheckingAccount(accountType, accountNumber, accountOwner, initialBalanceAmount, overdraftAmount);
                Bank.CreateAccount(newAccount);
            }
        }
    }
}
public enum Options
{
    CreateAccount = 1,
    GetBalance = 2,
    DepositAmount = 3,
    WithdrawalAmount = 4,
    Exit = 0,
    Invalid = -1
}
