using System;
namespace BankApp
{
    public class BankAccount
    {
        private string accountNumber;

        private string placeHolder;

        private double balanceAmount;

        private int accountType;

        public string AccountNumber { get => accountNumber; set => accountNumber = value; }

        public string PlaceHolder { get => placeHolder; set => placeHolder = value; }

        public double BalanceAmount { get => balanceAmount; set => balanceAmount = value; }

        public int AccountType { get => accountType; set => accountType = value; }

        public BankAccount()
        {

        }

        public BankAccount(string accountNumber, string placeHolder, double balanceAmount, int accountType)
        {
            this.accountNumber = accountNumber;
            this.placeHolder = placeHolder;
            this.balanceAmount = balanceAmount;
            this.accountType = accountType;
        }
    }
}
