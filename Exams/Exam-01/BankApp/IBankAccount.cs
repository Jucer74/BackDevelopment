public interface IBankAccount
{
    string AccountNumber { get; set; }
    string AccountOwner { get; set; }
    decimal BalanceAmount { get; set; }
    AccountType AccountType { get; set; }

    void Deposit(decimal amount);
    void Withdrawal(decimal amount);
}
