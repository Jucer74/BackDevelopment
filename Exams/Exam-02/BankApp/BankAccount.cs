using System;
namespace BankApp
{
public class BankAccount: IBankAccount
{
    private static Bank bank = new Bank();
    public int NumberAccount { get; set; }
    public string PlaceHolder { get; set; }
    public double BalanceAmount { get; set; }
    public int AccountType { get; set; }


    public BankAccount(int numberAccount, string placeHolder, double balanceAmount, int accountType)
    {
        this.NumberAccount = numberAccount;
        this.PlaceHolder = placeHolder;
        this.BalanceAmount = balanceAmount;
        this.AccountType = accountType;
    }
    public BankAccount()
    {
    }

    public void Deposit(double amountToDeposit)
    {
        BalanceAmount = BalanceAmount+amountToDeposit;
    }
    public void Withdraw(double amountToWithdraw)
    {
        BalanceAmount = BalanceAmount-amountToWithdraw;
    }
    public double CheckBalance()
    {
        return BalanceAmount;
    }

}
}