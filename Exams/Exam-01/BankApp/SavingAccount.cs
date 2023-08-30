public class SavingAccount : IBankAccount
{
    public string AccountNumber { get; private set; }
    public string AccountOwner { get; private set; }
    private decimal balanceAmount;
    public decimal BalanceAmount => balanceAmount;
    public AccountType AccountType => AccountType.Saving;

    public SavingAccount(string accountNumber, string accountOwner, decimal initialBalance)
    {
        if(string.IsNullOrWhiteSpace(accountNumber) || accountNumber.Length != 10)
            throw new ArgumentException("Número de cuenta inválido. Debe tener exactamente 10 dígitos.");

        if(string.IsNullOrWhiteSpace(accountOwner) || accountOwner.Length > 50)
            throw new ArgumentException("Nombre del titular inválido. No debe exceder de 50 caracteres.");

        if(initialBalance < 0)
            throw new ArgumentException("El saldo inicial no puede ser negativo.");

        AccountNumber = accountNumber;
        AccountOwner = accountOwner;
        balanceAmount = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("El monto a depositar debe ser positivo.");
        }

        balanceAmount += amount;
    }

    public void Withdrawal(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("El monto a retirar debe ser positivo.");
        }

        if (amount > balanceAmount)
        {
            Console.WriteLine("Fondos Insuficientes");
            return;
        }

        balanceAmount -= amount;
    }
}
