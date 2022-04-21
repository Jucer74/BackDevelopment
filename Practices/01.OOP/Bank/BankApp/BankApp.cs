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
        private string balance;
        private string accountType;

        public string AccountNumber
        {
            get; set;
        }

        public string Placeholder
        {
            get; set;
        }

        public string Balance
        {
            get; set;
        }

        //public BankAccount()
        //{
        //    AccountNumber = accountNumber;
        //    Placeholder = placeHolder;
        //    Balance = balance;
        //}

        public void CreateAccount()
        {
            List<string> BankAccount = new List<string>();

            Console.WriteLine("\nAccount number:");

            accountNumber = Console.ReadLine();

            Console.WriteLine("\nAccount Owner:");

            placeHolder = Console.ReadLine();

            Console.WriteLine("\nWhats your balance:");

            balance = Console.ReadLine();

            Console.WriteLine("\nAccount Type:");

            accountType = Console.ReadLine();

            BankAccount.Add(accountNumber);
            BankAccount.Add(placeHolder);
            BankAccount.Add(balance);
            BankAccount.Add(accountType);

            for (int i = 0; i < BankAccount.Count; i++)
            {
                Console.WriteLine(BankAccount[i]);
                
            }
        }
    }
}