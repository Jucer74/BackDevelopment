using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class BankAccount
    {
        private string accountNumber;
        private string placeHolder;
        protected double balance = 0.0;
        protected double overDraftAmount = 500.000;
        protected string accountType;

        public class Item
        {
            public string AccountNumber { get; set; }
            public string Placeholder { get; set; }
            public double Balance { get; set; }
            public string AccountType { get; set; }

        }

        List<Item> Bankaccount = new List<Item>();

        public void CreateAccount()
        {
            CheckingAccount checkingAccount = new CheckingAccount();

            Console.WriteLine("\nGive me your account number");
            accountNumber = Console.ReadLine();

            Console.WriteLine("\nGive me your placeholder");
            placeHolder = Console.ReadLine();

            Console.WriteLine("\nGive me your account type: 1 to Saving account or 2 to Checking account");
            accountType = Console.ReadLine();

            checkingAccount.OverDraftAmount(accountType);

            Console.WriteLine("\nGive me your balance");
            balance = Convert.ToDouble(Console.ReadLine());

            Bankaccount.Add(new Item { AccountNumber = accountNumber, Placeholder = placeHolder, Balance = balance, AccountType = accountType });
        }

        public void ShowInfoGetBalanceAccount()
        {
            string accountNumber = "0";
            string showInfoBalanceAccount = "";
            Console.WriteLine("\nPlease, give me your account number");
            accountNumber = Console.ReadLine();


            for (int i = 0; i < Bankaccount.Count; i++)
            {
                if (accountNumber == Bankaccount[i].AccountNumber)
                {
                    showInfoBalanceAccount = "Your Account Type: " + Bankaccount[i].AccountType + "\nYour Balance is: " + Bankaccount[i].Balance + "\nYour Placeholder is: " + Bankaccount[i].Placeholder;
                    Console.WriteLine(showInfoBalanceAccount);
                    break;
                }
            }
        }

        public void DepositAccount()
        {
            string accountNumber = "0";
            double newAmount = 0.0;

            Console.WriteLine("\nPlease, give me your account number");
            accountNumber = Console.ReadLine();

            for (int i = 0; i < Bankaccount.Count; i++)
            {
                if (accountNumber == Bankaccount[i].AccountNumber)
                {
                    Console.WriteLine("\nHow much are you going to pay in?");
                    newAmount = Convert.ToDouble(Console.ReadLine());

                    Bankaccount[i].Balance += newAmount;

                    Console.WriteLine("Your new balance is: " + Bankaccount[i].Balance);
                    break;
                }
            }
        }

        public void Withdrawal()
        {
            string accountNumber = "0";
            double withDrawalValue = 0.0;
            const double OVERDRAFT_VALUE = 1000000.0;

            Console.WriteLine("\nPlease give me your account number");
            accountNumber = Console.ReadLine();

            for (int i = 0; i < Bankaccount.Count; i++)
            {
                if (accountNumber == Bankaccount[i].AccountNumber)
                {
                    if (Bankaccount[i].AccountType == "2")
                    {
                        Console.WriteLine("\nHow much are you will to whitdrawal?");
                        withDrawalValue = Convert.ToDouble(Console.ReadLine());

                        if (Bankaccount[i].Balance <= -1000000)
                        {
                            Console.WriteLine("You cannot whitdrawal");
                            break;
                        }
                        else
                        {
                            Bankaccount[i].Balance -= withDrawalValue;
                        }

                        Console.WriteLine("Your new balance is: " + Bankaccount[i].Balance);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nHow much are you will to whitdrawal?");
                        withDrawalValue = Convert.ToDouble(Console.ReadLine());

                        Bankaccount[i].Balance -= withDrawalValue;

                        Console.WriteLine("Your new balance is: " + Bankaccount[i].Balance);
                    }
       
                }
            }


        }

    }


}
        
