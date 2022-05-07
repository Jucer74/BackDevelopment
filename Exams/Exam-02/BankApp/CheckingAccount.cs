
namespace BankApp
{
    public class CheckingAccount : BankAccount
    {
        private double overDraftAmount;

        public double OverDraftAmount { get => overDraftAmount; set => overDraftAmount = value; }

        public CheckingAccount()
        {
        }

        public CheckingAccount(double overDraftAmount)
        {
            this.OverDraftAmount = overDraftAmount;
        }

    }
}
