public class Program
{
    static void Main(string[] args)
    {
        try
        {
            Menu();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }

    static void Menu()
    {
        char option;

        do
        {
            Console.Clear();
            Console.WriteLine("Menu de Banco");
            Console.WriteLine("----------------------");
            Console.WriteLine("1. Crear Cuenta");
            Console.WriteLine("2. Balance de la Cuenta");
            Console.WriteLine("3. Depositar en Cuenta");
            Console.WriteLine("4. Retiro de Cuenta");
            Console.WriteLine("0. Salir");
            Console.WriteLine("Seleccione una opción:");

            option = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (option)
            {
                case '1':
                    CreateAccount();
                    break;
                case '2':
                    ShowBalance();
                    break;
                case '3':
                    DepositInAccount();
                    break;
                case '4':
                    WithdrawFromAccount();
                    break;
                case '0':
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción inválida");
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
            }

        } while (option != '0');
    }

    static void CreateAccount()
    {
        Console.WriteLine("Ingrese el tipo de cuenta (1: Ahorros, 2: Corriente):");
        char accountTypeOption = Console.ReadKey().KeyChar;
        Console.WriteLine();

        Console.WriteLine("Ingrese el número de cuenta:");
        string accountNumber = Console.ReadLine();

        // Validar el número de cuenta antes de proceder.
        if (!IsValidAccountNumber(accountNumber))
        {
            Console.WriteLine("Número de cuenta inválido. Debe contener exactamente 10 dígitos.");
            Console.ReadKey();
            return;
        }

        if (Bank.AccountExists(accountNumber))
        {
            Console.WriteLine("Esta cuenta ya existe.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Ingrese el nombre del titular de la cuenta:");
        string accountOwner = Console.ReadLine();

        // Validar el nombre del titular de la cuenta.
        if (!IsValidAccountOwner(accountOwner))
        {
            Console.WriteLine("Nombre del titular inválido. Debe tener 50 caracteres o menos.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Ingrese el saldo inicial:");
        decimal initialBalance;
        if (!decimal.TryParse(Console.ReadLine(), out initialBalance) || !IsValidBalanceAmount(initialBalance))
        {
            Console.WriteLine("Saldo inválido.");
            Console.ReadKey();
            return;
        }

        IBankAccount newAccount = null;

        switch (accountTypeOption)
        {
            case '1':
                newAccount = new SavingAccount(accountNumber, accountOwner, initialBalance);
                break;
            case '2':
                newAccount = new CheckingAccount(accountNumber, accountOwner, initialBalance);
                break;
            default:
                Console.WriteLine("Opción de tipo de cuenta inválida.");
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
                break;
        }

        if (newAccount != null)
        {
            bool wasCreated = Bank.CreateAccount(newAccount);
            if (wasCreated)
            {
                Console.WriteLine("Cuenta creada exitosamente!");
            }
            else
            {
                Console.WriteLine("Error al crear la cuenta. Por favor, intente nuevamente.");
            }
        }
        else
        {
            Console.WriteLine("No se pudo crear una instancia de la cuenta. Por favor, verifique las entradas.");
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
        return;

    }

    static void ShowBalance()
    {
        string accountNumber;
        bool isValid;

        do
        {
            Console.WriteLine("Ingrese el número de cuenta:");
            accountNumber = Console.ReadLine();
            isValid = IsValidAccountNumber(accountNumber);

            if (!isValid)
            {
                Console.WriteLine("Número de cuenta inválido. Debe contener exactamente 10 dígitos.");
                Console.WriteLine("Inténtelo nuevamente.");
            }

        } while (!isValid);

        var account = Bank.FindAccount(accountNumber);
        if (account != null)
        {
            DisplayBalance(account);
        }
        else
        {
            Console.WriteLine("La cuenta no existe.");
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
        return;
    }

    static void DepositInAccount()
    {
        string accountNumber;
        bool isValid;

        do
        {
            Console.WriteLine("Ingrese el número de cuenta:");
            accountNumber = Console.ReadLine();
            isValid = IsValidAccountNumber(accountNumber);

            if (!isValid)
            {
                Console.WriteLine("Número de cuenta inválido. Debe contener exactamente 10 dígitos.");
                Console.WriteLine("Inténtelo nuevamente.");
            }
        } while (!isValid);

        decimal amount;
        do
        {
            Console.WriteLine("Ingrese la cantidad a depositar:");
            isValid = decimal.TryParse(Console.ReadLine(), out amount) && IsValidBalanceAmount(amount);

            if (!isValid)
            {
                Console.WriteLine("Cantidad inválida. Inténtelo nuevamente.");
            }
        } while (!isValid);

        bool depositSuccessful = Bank.Deposit(accountNumber, amount);

        if (depositSuccessful)
        {
            Console.WriteLine("\nDepósito realizado con éxito.\n");
            var account = Bank.FindAccount(accountNumber);
            DisplayBalance(account);
        }
        else
        {
            Console.WriteLine("No se pudo realizar el depósito. Por favor, verifique el número de cuenta y la cantidad.");
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
        return;
    }

    static void WithdrawFromAccount()
    {
        string accountNumber;
        decimal amount;
        bool validEntry;

        do
        {
            Console.WriteLine("Ingrese el número de cuenta:");
            accountNumber = Console.ReadLine();

            validEntry = IsValidAccountNumber(accountNumber);
            if (!validEntry)
            {
                Console.WriteLine("Número de cuenta inválido. Debe contener exactamente 10 dígitos.");
            }
        } while (!validEntry);

        var account = Bank.FindAccount(accountNumber);
        if (account == null)
        {
            Console.WriteLine("La cuenta no existe.");
            return;
        }

        do
        {
            Console.WriteLine("Ingrese la cantidad a retirar:");
            validEntry = decimal.TryParse(Console.ReadLine(), out amount) && IsValidWithdrawAmount(amount);
            if (!validEntry)
            {
                Console.WriteLine("Cantidad inválida.");
            }
        } while (!validEntry);

        bool withdrawalSuccessful = Bank.Withdraw(accountNumber, amount);
        if (withdrawalSuccessful)
        {
            DisplayBalance(account);
        }
        else
        {
            Console.WriteLine("No se pudo completar el retiro. Verifique su saldo y la cantidad que desea retirar.");
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    static void DisplayBalance(IBankAccount account)
    {
        Console.WriteLine("\nBalance de la Cuenta");
        Console.WriteLine("-----------");
        Console.WriteLine($"Numero de cuenta: {account.AccountNumber}");
        Console.WriteLine($"Tipo de Cuenta: {account.AccountType}");
        Console.WriteLine($"Propietario: {account.AccountOwner}");
        Console.WriteLine($"Saldo: ${account.BalanceAmount}");

        if (account is CheckingAccount checkingAccount)
        {
            Console.WriteLine($"Sobregiro utilizado: ${checkingAccount.OverdraftUsed}");
            Console.WriteLine($"Sobregiro disponible: ${checkingAccount.Overdraft}");
        }
    }

    private static bool IsValidWithdrawAmount(decimal amount)
    {
        return amount > 0;
    }

    private static bool IsValidAccountNumber(string accountNumber)
    {
        return accountNumber.Length == 10 && accountNumber.All(char.IsDigit);
    }
    private static bool IsValidAccountOwner(string accountOwner)
    {
        return !string.IsNullOrEmpty(accountOwner) && accountOwner.Length <= 50;
    }
    private static bool IsValidBalanceAmount(decimal balanceAmount)
    {
        return balanceAmount > 0;
    }
}
