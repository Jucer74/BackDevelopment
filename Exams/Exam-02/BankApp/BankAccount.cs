    namespace BankApp
{
    public class BankAccount
    {    
        
        
        Integer AccountNumber;
        String placeHolder;
        double balanceAmount;
        Integer accountType;


        public Integer AccountNumber { get => accountNumber; set => accountNumber = value; }

        public string placeHolder { get => placeHolder; set => placeHolder = value; }

        public double balanceAmount { get => balanceAmount; set => balanceAmount = value; }

        public integer accountType { get => accountType; set => accountType = value; }
 public BankAccount(Integer accountNumber, string placeHolder, double balanceAmount, integer accountType)
        {
            this.AccountNumber = accountNumber;
            this.placeHolder = placeHolder;
            this.balanceAmount = balanceAmount;
            this.accountType = accountType;
        }
    }
}