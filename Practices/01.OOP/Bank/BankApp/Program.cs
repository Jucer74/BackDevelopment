using System;
//using BankApp.BankAccount;
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
            string option;
            int counter = 0;
            int searchAccountNumber = 0;

            bool isExit = false;
            List<BankAccount> accountList = new List<BankAccount>();

            while(isExit == false)
            {
                //Menu
                Console.WriteLine("\n BANK MENU");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Get Balance Account");
                Console.WriteLine("3. Deposit Account");
                Console.WriteLine("4. Withdrawal Account");
                Console.WriteLine("5. Exit");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        while (counter < 1)
                        {
                            Console.WriteLine("\n Select the type of bank account: ");
                            int accountType = int.Parse(Console.ReadLine());

                            if(accountType == 1)
                            {
                                SavingAccount savingAccount = new SavingAccount();

                                Console.WriteLine("   - Enter the name of the account holder: ");
                                savingAccount.PlaceHolder = Console.ReadLine();

                                Console.WriteLine("   - Enter the bank account number: ");
                                savingAccount.AccountNumber = int.Parse(Console.ReadLine());

                                accountList.Add(savingAccount);
                            }

                            if(accountType == 2)
                            {
                                CheckingAccount checkingAccount = new CheckingAccount();

                                Console.WriteLine("   - Enter the name of the account holder: ");
                                checkingAccount.PlaceHolder = Console.ReadLine();

                                Console.WriteLine("   - Enter the bank account number: ");
                                checkingAccount.AccountNumber = int.Parse(Console.ReadLine());

                                accountList.Add(checkingAccount);
                            }

                            counter++;
                        }
                    break;

                    case "2":
                        Console.WriteLine("\n Enter the number account: ");
                        searchAccountNumber = int.Parse(Console.ReadLine());

                        foreach (BankAccount account in accountList)
                        {
                            if(account.AccountNumber == searchAccountNumber)
                            {
                                Console.WriteLine("   ********** Balance Account = " + account.BalanceAmount + "**********");
                            } else
                            {
                                Console.WriteLine("Error: Account not found, please try again.");
                            }
                        }
                    break;

                    case "3":
                        Console.WriteLine("\n Enter the number account: ");
                        searchAccountNumber = int.Parse(Console.ReadLine());

                        foreach (BankAccount account in accountList)
                        {
                            if(account.AccountNumber == searchAccountNumber)
                            {
                                Console.WriteLine("   - Enter the amount: ");
                                int amount = int.Parse(Console.ReadLine());
                                account.Deposit(amount);

                                Console.WriteLine("   ********** Your new balance is: " + account.BalanceAmount);
                            } else
                            {
                                Console.WriteLine("Error: Account not found, please try again.");
                            }
                        }

                    break;

                    case "4":
                        Console.WriteLine("\n Enter the number account: ");
                        searchAccountNumber = int.Parse(Console.ReadLine());

                        foreach (BankAccount account in accountList)
                        {
                            if(account.AccountNumber == searchAccountNumber)
                            {
                                Console.WriteLine("   - Enter the amount: ");
                                int amount = int.Parse(Console.ReadLine());

                                if(amount > account.BalanceAmount)
                                {
                                    Console.WriteLine("Error: The amount exceeds the balance.");
                                } else {
                                    account.Withdrawal(amount);
                                    Console.WriteLine("   ********** Your new balance is: " + account.BalanceAmount);
                                }

                            } else
                            {
                                Console.WriteLine("Error: Account not found, please try again.");
                            }
                        }
                    break;

                    case "5":
                        isExit = true;
                    break;
                } // Switch  
            }
                     
        } // Main
    } // Class Program
}
