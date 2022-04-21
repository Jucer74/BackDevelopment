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

            Console.WriteLine("\nGive me your account number");

            accountNumber = Console.ReadLine();

            Console.WriteLine("\nGive me your placeholder");

            placeHolder = Console.ReadLine();

            Console.WriteLine("\nGive me your balance");
            
            balance = Console.ReadLine();

            BankAccount.Add(accountNumber);
            BankAccount.Add(placeHolder);
            BankAccount.Add(balance);
        }
    }
}