using System.Text.RegularExpressions;
using BankApp;

public class Pogram
{
        public static void Main(string[] args)
    {
        try
        {
            MenuSelect();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    static int Menu()
    {
        Console.Write("     Banking Operation       \n" + "--------------------------------\n");
        Console.Write("1. Create Account\n" + "2. Get Balance\n" + "3. Deposit Amount\n" + "4. Withdrawal Amount\n");
        Console.Write("0. Exit\n" + "Select Option:\n");
        string? menuSelected = Console.ReadLine();
        return Convert.ToInt32(menuSelected);
    }
    public static void MenuSelect()
    {
        int option = Menu();
        do
        {
            if ((Options)option == Options.CreateAccount)
            {

            }
            else if ((Options)option == Options.GetBalance)
            {
                Console.WriteLine("Get Balance");
            }
            else if ((Options)option == Options.DepositAmount)
            {
                Console.WriteLine("Deposit Amount");
            }
            else if ((Options)option == Options.WithdrawalAmount)
            {
                Console.WriteLine("Withdrawal Amount");
            }
        } while ((Options)option != Options.Exit);
    }
    public static bool IsValidAccountNumber(string accountNumber)
    {   
        return accountNumber.Length == 10 && Regex.IsMatch(accountNumber, "^[0-9]+$");
    }

    public static bool IsValidAmount(decimal inputAmount)
    {
        return inputAmount < 0;
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

    public static void GetBalanceAccount()
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
                IBankAccount newAccount = new CheckingAccount(accountType, accountNumber, accountOwner, initialBalanceAmount);
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
    Exit = 0
}
