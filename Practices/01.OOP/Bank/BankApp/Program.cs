using System;

namespace BankApp
{
    public class Program
    {

      /*   public void CreateAccount(int accountNumber, string placeHolder, int balanceAmount, string accountType){

        } */
        static void Main(string[] args)
        { 

         Console.WriteLine("Starting...");
         Menu();
             
        }

        private static void Menu()
        {
           /*  BankAccount newAccount; */

            var option = ' ';

            while (option != '0')
            {
                 
                Console.Clear();
                Console.WriteLine("            Bank        ");
                Console.WriteLine("------------------------------");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Get Balance Account");
                Console.WriteLine("3. Deposit Account");
                Console.WriteLine("4. Withdrawal Account");
                Console.WriteLine("0. Exit");
                Console.WriteLine("\nSelect Option = ");
                option = Console.ReadKey().KeyChar; 
                Console.WriteLine();

                switch (option)
                { 
                    case '0':
                    Console.WriteLine("Exit");
                    break;

                    case '1':
                    Console.WriteLine("1");
                    break;

                    
                    case '2':
                    Console.WriteLine("2");
                    break;

                    
                    case '3':
                    Console.WriteLine("3");
                    break;

                    
                    case '4':
                    Console.WriteLine("4");
                    break;

                    default:
                    Console.WriteLine("Invalid Option");
                    break;
                }; //switch

                Console.WriteLine("\nPress any key to continue... ");
                Console.ReadKey();
            } //while

        } //menu



    }   
} 
