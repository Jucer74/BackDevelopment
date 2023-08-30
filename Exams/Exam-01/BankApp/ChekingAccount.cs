public class CheckingAccount : IBankAccount
{
    public string AccountNumber { get; private set; }
    public string AccountOwner { get; private set; }
    private decimal balance;
    public decimal BalanceAmount => balance;
    public AccountType AccountType => AccountType.Checking;
    private decimal overdraft;
    public decimal Overdraft => overdraft;
    
    private readonly decimal originalOverdraft = 1000000;

    public decimal OverdraftUsed => originalOverdraft - overdraft;

    public CheckingAccount(string accountNumber, string accountOwner, decimal initialBalance)
    {
        if (string.IsNullOrWhiteSpace(accountNumber) || accountNumber.Length != 10)
            throw new ArgumentException("Número de cuenta inválido. Debe tener exactamente 10 dígitos.");

        if (string.IsNullOrWhiteSpace(accountOwner) || accountOwner.Length > 50)
            throw new ArgumentException("Nombre del titular inválido. No debe exceder de 50 caracteres.");

        if (initialBalance < 0)
            throw new ArgumentException("El saldo inicial no puede ser negativo.");

        AccountNumber = accountNumber;
        AccountOwner = accountOwner;
        balance = initialBalance; 
        overdraft = originalOverdraft;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("El monto a depositar debe ser positivo.");
        }
        balance += amount;
    }

    public void Withdrawal(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("El monto a retirar debe ser positivo.");
        }

        decimal totalAvailable = balance + overdraft;
        
        if (amount > totalAvailable)
        {
            Console.WriteLine("Fondos insuficientes, incluso considerando el sobregiro.");
            return;
        }

        if (amount <= balance)
        {
            balance -= amount;
        }
        else
        {
            overdraft -= (amount - balance);
            balance = 0;
        }
    }
}
