using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    class Program
    {
        private static Bank bank = new Bank();
        static void Main(string[] args)
        {

            List<BankAccount> listBankAccounts = new List<BankAccount>();
            BankAccount bAccount = new BankAccount();

            try
            {
                Menu();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
        private static void showBalanceAccount(string numberInput)
        {
            for (int currentAccount = 0; currentAccount < bank.listBankAccounts.Count; currentAccount++)
            {
                if (bank.listBankAccounts[currentAccount].NumberAccount == numberInput)
                {
                    Console.WriteLine("Numero de cuenta "+ bank.listBankAccounts[currentAccount].NumberAccount
                                    + "El balance de cuenta es: "+ bank.listBankAccounts[currentAccount].BalanceAmount);
                }
            }
        }
        private static void createBankAccount()
        {
            bool validType = false;
            double balanceAmount = 0;

            Console.WriteLine("\n Escriba el numero de la cuenta a crear ");
            string numberAccount = Console.ReadLine();
            Console.WriteLine("\n Escriba el nombre del propietario ");
            string placeHolder = Console.ReadLine();
            while (!validType)
            {
                Console.WriteLine("\n Digite que tipo de cuenta creara: \n1. SavingAccount\n2. CheckingAccount");
                int accountType = int.Parse(Console.ReadLine());

                if (accountType == 1 || accountType == 2)
                {
                    balanceAmount = 0;
                    bank.CreateAccount(numberAccount, placeHolder, balanceAmount, accountType);
                    validType = true;
                }
                else
                {
                    Console.WriteLine("Tipo de cuenta invalido");
                }
            }
        }
        private static void Menu()
        {
            var option = ' ';
            while (option != '0')
            {
                Console.Clear();
                Console.WriteLine("Banco");
                Console.WriteLine("1. Crear cuenta");
                Console.WriteLine("2. Mirar balance de cuenta");
                Console.WriteLine("3. Depositar en cuenta");
                Console.WriteLine("4. Retiro");
                Console.WriteLine("5. Ver cuentas");
                Console.WriteLine("8. Salir");
                option = Console.ReadKey().KeyChar;

                switch (option)
                {
                    
                    case '1':
                        createBankAccount();
                        break;
                    case '2':
                        Console.WriteLine("Numero de cuenta a revisar balance");
                        string consult = Console.ReadLine();
                        showBalanceAccount(consult);
                        break;
                    case '3':
                        Console.WriteLine("\nDeposito");
                        break;
                    case '4':
                        Console.WriteLine("\nRetiro de cuenta");
                        break;
                    case '5':
                        for (int currentAccount = 0; currentAccount < bank.listBankAccounts.Count; currentAccount++)
                        {
                            Console.WriteLine("\ntitular de cuenta de numero "
                                            + bank.listBankAccounts[currentAccount].NumberAccount
                                            + ": " + bank.listBankAccounts[currentAccount].PlaceHolder);
                        }
                        break;
                    default:
                        Console.WriteLine("\nOpcion invalida");
                        break;
                }
                ;

                Console.WriteLine("\nDigite algo para continuar ");
                Console.ReadKey();
            }
        }
    }
}
