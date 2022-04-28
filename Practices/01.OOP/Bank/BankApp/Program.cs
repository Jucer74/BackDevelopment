using System;
using System.Collections.Generic;

namespace BankApp
{
    public class Program 
    {
        
        private static Bank BankCompany = new Bank();


        static void Main(string[] args)
        { 
        Console.WriteLine("Iniciando...");
          
            try
            {
                Menu();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
             
        }

        public static void Menu()
        {
           /* BankAccount bankAccount = new BankAccount(); */

            var option = ' ';

            while (option != '0')
            {
                 
                Console.Clear();
                Console.WriteLine("         Bank Company        ");
                Console.WriteLine("------------------------------");
                Console.WriteLine("1. Crear Cuenta");
                Console.WriteLine("2. Obtener el saldo de la cuenta");
                Console.WriteLine("3. Depostiar en la cuenta");
                Console.WriteLine("4. Retirar de la cuenta");
                Console.WriteLine("0. Exit");
                Console.WriteLine("\nSeleccione una opción = ");
                option = Console.ReadKey().KeyChar; 
                Console.WriteLine();

                switch (option)
                { 
                    case '0':
                    Console.WriteLine("---------Salida---------");
                    break;

                    case '1':
                    CreateAccount();
                    break;

                    
                    case '2':
                    GetBalanceAccount();
                    break;

                    
                    case '3':
                    Console.WriteLine("3");
                    break;

                    
                    case '4':
                    Console.WriteLine("4");
                    break;

                    default:
                    Console.WriteLine("ERORR Opción no válida");
                    break;
                }; 

                Console.WriteLine("\nPulse cualquier tecla para continuar... ");
                Console.ReadKey();
            } 

        } //menu

       
        public static void CreateAccount()
        {
            
            bool option2 = true;
            string accountNumber;
            string placeHolder;
            double balanceAmount;
            int accountType = 1 ;
           

            Console.Clear();

            Console.WriteLine("\nDigite su número de cuenta : ");
            accountNumber = Console.ReadLine();

            Console.WriteLine("\nDigite el nombre del titular de la cuenta: ");
            placeHolder = Console.ReadLine();

            balanceAmount = 0.0;

            do
            {
                Console.WriteLine("\nDigite el tipo de cuenta: ");
                Console.WriteLine("1. Cuenta de ahorro");
                Console.WriteLine("2. Cuenta corriente");

        
                    accountType = int.Parse(Console.ReadLine());

                    if (accountType >= 1 && accountType <= 2)
                    {
                        option2 = false;
                        
                    }
                    else
                    {
                        option2 = true;
                        Console.WriteLine("\nERORR Opción no válida");
                    }
                
               
            }while (option2);

            BankCompany.CreateAccount(accountNumber,placeHolder,balanceAmount,accountType);

            Console.WriteLine($"Su cuenta fue creada!, su numero de cuenta es: {accountNumber}");
            
        } //Crear cuenta

        public static void GetBalanceAccount() 
        {

            bool option2=true;
            string accountNumber;

            do{
                Console.Clear();
                Console.WriteLine("Saldo de Cuenta");
                Console.WriteLine("---------------");
                Console.WriteLine("Digite el numero de la cuenta");
                accountNumber = (Console.ReadLine());

                Console.WriteLine($"Su balance es: {BankCompany.GetBalanceAccount(accountNumber)}");

                option2=false;

            } while (option2);

        }// Obtener Balance

    }   
} 
