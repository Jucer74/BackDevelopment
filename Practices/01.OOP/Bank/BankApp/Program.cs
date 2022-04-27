// See https://aka.ms/new-console-template for more information
/* public class Bank : Person
{
    public string AccountNumber{ get; set; }
    public string AccountType { get; set; }

    public Bank() : base()
    {

    }
    public Bank(int id, string firstName, string lastName, DateTime dateOfBirth, char sex, string accountNumber, string accountType) : base(id, firstName, lastName, dateOfBirth, sex)
    {
        this.AccountNumber = accountNumber;
        this.AccountType = accountType;
    }

} */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Menu();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void Menu()
        {
            BankAccount bankAccount = new BankAccount();
            var option = ' ';

            while (option != '5')
            {
        
                Console.WriteLine(" \n    WELCOME TO YOUR BANK     ");
                Console.WriteLine("--------------------------------"); 
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Get Balance Account");
                Console.WriteLine("3. Deposit Account");
                Console.WriteLine("4. Withdrawal Account");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Choose one of the options");
                Console.WriteLine("--------------------------------"); 
                option = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (option)
                {

                    case '1':
                        Console.WriteLine("You have chosen Create Account");  
                        bankAccount.CreateAccount();     
                        break;
 
                    case '2':
                        Console.WriteLine("You have chosen Get Balance Account");
                        bankAccount.GetBalanceAccount();
                        break;
 
                    case '3':
                        Console.WriteLine("You have chosen Deposit Account");
                        bankAccount.DepositAccount();
                        break;

                    case '4':
                        Console.WriteLine("You have chosen Withdrawal Account");
                        break;

                    case '5':
                        Console.WriteLine("You have chosen to Exit");
                        break;

                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            }
        }
    }
}
