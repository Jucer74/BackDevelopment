
public interface IBankAccount
{
    string acccountNumber { get;set; }
    string accountOwner { get;set; }
    decimal balanceAmount { get;set; }
    AccountType accountType { get;set; }

    void Deposit(decimal amount)
    {
        balanceAmount += amount;
    }
    void Withdrawal(decimal amount)
    {
        if (balanceAmount >= amount)
        {
            balanceAmount -= amount;
        }else
        {
            Console.WriteLine("No puede sacar mas de lo que tiene");
        }
    }
}


