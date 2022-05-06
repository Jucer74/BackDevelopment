namespace BankApp
{
    public class AccountValidation: IAccountValidation
    {

//elegir el tipo de cuenta
         public BankAccount ElegirAccountType(List<BankAccount> accountList)
        {
            BankAccount bankAccount = null;
            Console.Write("Account Type  = 1) Saving , Account Type =  2) Checking ");
            int accountType = int.Parse(Console.ReadLine());
            if (accountType == 1)
            {
                bankAccount = CreateSavingAccount(accountList, bankAccount, accountType);

            }
            else if (accountType == 2)
            {
                bankAccount = CreateChekingAccount(accountList, bankAccount, accountType);
            }
            return bankAccount;
        }

//buscar cuenta dentro de las lista 
        public BankAccount SearchAccount(string accountNumber, List<BankAccount> accountList)
        {
            BankAccount bankAccount = null;
            if (accountList != null)
            {
                for (int i = 0; i < accountList.Count; i++)
                {
                    if (accountList[i].AccountNumber.Contains(accountNumber))
                    {
                        bankAccount = accountList[i];
                    }
                }
            }
           
            return bankAccount;
        }

        
            public BankAccount CreateSavingAccount(List<BankAccount> accountList,
            BankAccount bankAccount, int accountType)
        {
            bool validateAccountNumberNotExist = false;

            Console.Write("Enter The Account Number   : ");
            var accountNumber = Console.ReadLine();
            validateAccountNumberNotExist = ValidateAccountIsNull(accountList, accountNumber,
               bankAccount);
            if (validateAccountNumberNotExist == true)
            {
                Console.Write("Place holder        : ");
                var placeHolder = Console.ReadLine();

                Console.Write("Balance amount : ");
                double balanceAmount = double.Parse(Console.ReadLine());
                
            }
            return bankAccount;
        }
 public BankAccount CreateChekingAccount(List<BankAccount> accountList,
        BankAccount bankAccount, int accountType)
        {
            Console.Write("Enter The Account Number    : ");
            var accountNumber = Console.ReadLine();
           bool validateAccountNumberNotExist = ValidateAccountIsNull(accountList, accountNumber,
                   bankAccount);
            if (validateAccountNumberNotExist == true)
            {

                Console.Write("Enter The Place holder      : ");

                var placeHolder = Console.ReadLine();
                Console.Write("Enter The Balance amount : ");

                double balanceAmount = double.Parse(Console.ReadLine());
                Console.Write("Enter The Overdraft amount : ");

                double overdraftAmountValue = double.Parse(Console.ReadLine());
                balanceAmount = overdraftAmountValue + balanceAmount;
              
            }
          return BankAccount;
        }
    }
}
    