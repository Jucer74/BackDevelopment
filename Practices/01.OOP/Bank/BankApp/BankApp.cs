using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class BankAccount
    {
        private string accountNumber;
        private string placeHolder;
        private double balance = 0.0;
        private string accountType;

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
            Console.WriteLine("\nEnter your account number");
            accountNumber = Console.ReadLine();

            Console.WriteLine("\nEnter the placeholder");
            placeHolder = Console.ReadLine();

            Console.WriteLine("\nEnter your account type: 1 for Savings Account or 2 for Checking Account");
            accountType = Console.ReadLine();

            if(accountType == "2")
            {
                Console.WriteLine("Your OverdraftAmount is 1'000.000");
            }

            Console.WriteLine("\nEnter your balance");
            balance = Convert.ToDouble(Console.ReadLine());

            Bankaccount.Add(new Item { AccountNumber = accountNumber, Placeholder = placeHolder, Balance = balance, AccountType = accountType });
        }

        public void GetBalanceAccount()
        {
            string accountNumber = "0";
            string showInfoBalanceAccount = "";
            Console.WriteLine("\nPlease enter your account number");
            accountNumber = Console.ReadLine();

            
            for (int i = 0; i < Bankaccount.Count; i++)
            {
                if (accountNumber == Bankaccount[i].AccountNumber)
                {
                    showInfoBalanceAccount = "\nYour Balance is: " + Bankaccount[i].Balance;
                    Console.WriteLine(showInfoBalanceAccount);
                    break;
                }           
            }
        }

        public void DepositAccount()
        {
            string accountNumber = "0";
            double newAmount = 0.0;

            Console.WriteLine("\nPlease enter your account number");
            accountNumber = Console.ReadLine();

            for (int i = 0; i < Bankaccount.Count; i++)
            {
                if (accountNumber == Bankaccount[i].AccountNumber)
                {
                    Console.WriteLine("\nHow much money you wish to deposit?");
                    newAmount = Convert.ToDouble(Console.ReadLine());

                    Bankaccount[i].Balance += newAmount;

                    Console.WriteLine("Your new balance is: " + Bankaccount[i].Balance);
                    break;
                }
            }
        }
    }
}