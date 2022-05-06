using System;
namespace BankApp
{
public class BankAccount
{
    private static Bank bank = new Bank();
    public string NumberAccount { get; set; }
    public string PlaceHolder { get; set; }
    public double BalanceAmount { get; set; }
    public int AccountType { get; set; }


    public BankAccount(string numberAccount, string placeHolder, double balanceAmount, int accountType)
    {
        this.NumberAccount = numberAccount;
        this.PlaceHolder = placeHolder;
        this.BalanceAmount = balanceAmount;
        this.AccountType = accountType;
    }
    public BankAccount()
    {
    }

    //methods

    public void deposit(double amountToDposit)
    {
        BalanceAmount = BalanceAmount+amountToDposit;
    }
    public void Withdrawal(double amountToWithDrawal)
    {
        BalanceAmount = BalanceAmount-amountToWithDrawal;
    }
    public double checkBalance()
    {
        return BalanceAmount;
    }

}
}