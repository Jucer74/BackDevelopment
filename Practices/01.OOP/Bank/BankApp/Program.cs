using System;
using System.Globalization;
using System.Collections.Generic;

namespace BankApp
{
    class Program
    {   
        
        private static void Main(string[] args)
        {
           try
           {
               Menu();
           }
           catch(Exception e)
           {
               Console.WriteLine(e);
           }

        }

        private static void Menu()
        {
            var option =' ';


            while(option !='0')
            {
                Console.Clear();
                Console.WriteLine("      BANK     ");
                Console.WriteLine("---------------");
                Console.WriteLine("1. CreateAccount");
                Console.WriteLine("2. Get Balance Account");
                Console.WriteLine("3. Deposit Account");
                Console.WriteLine("4. Withdrawal Account");
                Console.WriteLine("0. Exit");
                option = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch(option)
                {
                    case '0':
                        Console.WriteLine("Exit to bank");
                        break;
                    case '1':
                        CreateAccount();
                        break;
                    case '2':
                        GetBalanceAccount();
                        break;
                    case '3':
                        DepositAccount();
                        break;
                    case '4':
                        WithdrawalAccount();
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }

                ;

                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }

        private static AccountDto CreateAccount()
        {
            var option = ' ';
            var accountType = " ";
            Console.WriteLine("Account Number   :");
            int accountNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Place Holder     :");
            var placeHolder = Console.ReadLine();
            Console.WriteLine("Account Type");
            Console.WriteLine("1. Saving");
            Console.WriteLine("2. Checking");
            option = Console.ReadKey().KeyChar;
            switch (option)
            {
                case '1':
                    accountType = "Saving";
                    break;
                case '2':
                    accountType = "Checking";
                    break;
                default:
                    Console.WriteLine("Tipo de cuenta no encontrada");
                    Console.WriteLine("Seleccione un tipo de cuenta");
                    break;
            }

            Console.WriteLine("\nOverdraft Amount");
            int overdraftAccount = int.Parse(Console.ReadLine());
            int balanceAccount = 0;
            balanceAccount = balanceAccount + overdraftAccount;
            
            var accountDto = new AccountDto
            {
                Accountnumber = accountNumber,
                Placeholder = placeHolder,
                Accountype = accountType,
                Balanceaccount = balanceAccount
            };
            List<AccountDto> listaccount = new List<AccountDto>();
            listaccount.Add(accountDto);
            
        return accountDto;
        }

        private static void DepositAccount()
        {
            Console.WriteLine("Deposit");

            Console.WriteLine("Digite el numero de cuenta");
            var accountNumber = Console.ReadLine();

            // si el numero de cuenta es igual al de la lista
            Console.WriteLine("Digite el saldo a depositar");
            var balanceAccount = Console.ReadLine();
            // se debe sumar al balance de la cuenta de la lista 
        }

        private static void GetBalanceAccount()
        {
            Console.Clear();
            Console.WriteLine("Balance Account");
            Console.WriteLine("---------------");
            Console.WriteLine("Digite el numero de cuenta");
            int accountNumber = int.Parse(Console.ReadLine());
            List<AccountDto> list = new List<AccountDto>();
            //se debe comparar el numero de cuenta con el de la lista
            var numberAccount = list.IndexOf(accountNumber);
            Console.WriteLine(numberAccount);

            //se debe retornar el balance de la cuenta
        }

        private static void WithdrawalAccount()
        {
            Console.Clear();
            Console.WriteLine("Withdraw Account");
            Console.WriteLine("----------------");
            Console.WriteLine("Digite el numero de cuenta");
            var accountNumber = Console.ReadLine();

            //se verifica el numero de cuenta
            Console.WriteLine("Se ingreso a la cuenta correctamente....");
            //se verifica el tipo de cuenta
            //si es saving
            Console.WriteLine("¿Cual es el saldo a retirar?");
            var retirarDinero = Console.ReadLine();

            // var balanceAccount = GetBalanceAccount();
            

        }
    }
}
