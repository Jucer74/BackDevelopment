//->NSZ<-\\
using System;
using System.Globalization;
using System.Collections.Generic;

namespace BankApp
{
    class Program
    {   
        
        public static List<AccountDto> listAccount = new List<AccountDto>();    
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
                Console.WriteLine("---------------");
                Console.WriteLine("      BANK     ");
                Console.WriteLine("---------------");
                Console.WriteLine("1. Crear Cuenta");
                Console.WriteLine("2. Ver Balance de Cuenta");
                Console.WriteLine("3. Cuenta de Deposito");
                Console.WriteLine("4. Cuenta de Retiro");
                Console.WriteLine("0. Salir");
                Console.WriteLine("---------------");
                option = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch(option)
                {
                    case '0':
                        Console.WriteLine("Salir del Banco");
                        break;
                    case '1':
                        InsertAccount();
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
                        Console.WriteLine("Opcion Invalida");
                        break;
                }

                ;

                Console.WriteLine("Presione cualquier tecla para continuar");
                Console.ReadKey();
            }
        }
        private static void InsertAccount()
        {
            
            var option = ' ';
            var accountType = " ";
            Console.WriteLine("Numero de Cuenta   :");
            int accountNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Titular de Cuenta     :");
            var placeHolder = Console.ReadLine();
            Console.WriteLine("Tipo de Cuenta");
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

            Console.WriteLine("\nSobregiro de Cuenta");
            int overdraftAccount = int.Parse(Console.ReadLine());
            int balanceAccount = 0;
            balanceAccount = balanceAccount + overdraftAccount;

            AccountDto newAccount = new AccountDto();
            newAccount = CreateAccount(accountNumber, placeHolder, balanceAccount, accountType);

            listAccount.Add(newAccount);
        }
        private static AccountDto CreateAccount(int accountNumber, string placeHolder, int balanceAccount, string accountType)
        {
           
            AccountDto accountDto = new AccountDto();
            accountDto.Accountnumber = accountNumber;
            accountDto.Placeholder = placeHolder;
            accountDto.Accountype = accountType;
            accountDto.Balanceaccount = balanceAccount;

        return accountDto;
        }

        private static void DepositAccount()
        {
            Console.WriteLine("Cuenta de Deposito");

            Console.WriteLine("Enter Numero de Cuenta");
            int accountNumber = int.Parse(Console.ReadLine());
            
            //se debe comparar el numero de cuenta con el de la lista
            foreach (AccountDto searchAccount in listAccount)
            {
                if(searchAccount.Accountnumber == accountNumber){
                    Console.WriteLine("Balance de Cuenta:");
                    Console.WriteLine(searchAccount.Balanceaccount);

                    Console.WriteLine("Digite el saldo a depositar");
                    int balanceAccount = int.Parse(Console.ReadLine());

                    searchAccount.Deposit(balanceAccount);
                }

            }
        }

        private static void GetBalanceAccount()
        {
            Console.Clear();
            Console.WriteLine("Balance de Cuenta");
            Console.WriteLine("---------------");
            Console.WriteLine("Ingrese Numero de Cuenta");
            int accountNumber = int.Parse(Console.ReadLine());
            
            //se debe comparar el numero de cuenta con el de la lista
            foreach (AccountDto searchAccount in listAccount)
            {
                if(searchAccount.Accountnumber == accountNumber){
                    Console.WriteLine("Balance de Cuenta:");
                    Console.WriteLine(searchAccount.Balanceaccount);
                }

            }

            //se debe retornar el balance de la cuenta
        }

        private static void WithdrawalAccount()
        {
            Console.Clear();
            Console.WriteLine("Cuenta de Retiro");
            //se verifica el numero de cuenta
            Console.WriteLine("Ingrese Numero de Cuenta");
            int accountNumber = int.Parse(Console.ReadLine());
            
            //se debe comparar el numero de cuenta con el de la lista
            foreach (AccountDto searchAccount in listAccount)
            {
                if(searchAccount.Accountnumber == accountNumber){
                    Console.WriteLine("Balance de Cuenta:");
                    Console.WriteLine(searchAccount.Balanceaccount);

                    Console.WriteLine("Digite el saldo a retirar");
                    int balanceAccount = int.Parse(Console.ReadLine());

                    searchAccount.Withdrawal(balanceAccount);
                }

            }

        }
    }
}
//->NSZ<-\\