using System;
namespace BankApp
{
    public class SavingAccount : BankAccount
    {
        private double overDraftAmount;
        public double OverDraftAmount { get => overDraftAmount; set => overDraftAmount = value; }

        public SavingAccount()
        {
        }        public SavingAccount(double overDraftAmount)
        {
            this.OverDraftAmount = overDraftAmount;
        }

    }
}