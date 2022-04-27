using System;

namespace BankApp
{
    public class Program
    {
        
        private static Bank BankSociety = new Bank();


        static void Main(string[] args)
        { 
        Console.WriteLine("Inciando...");
          
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
           BankAccount bankAccount = new BankAccount();

            var option = ' ';

            while (option != '0')
            {
                 
                Console.Clear();
                Console.WriteLine("         Bank Society         ");
                Console.WriteLine("------------------------------");
                Console.WriteLine("1. Crear Cuenta");
                Console.WriteLine("2. Obtener el saldo de la cuenta");
                Console.WriteLine("3. Depostiar en la cuenta");
                Console.WriteLine("4. Retirar de la cuenta");
                Console.WriteLine("0. Exit");
                Console.WriteLine("\nSelect Option = ");
                option = Console.ReadKey().KeyChar; 
                Console.WriteLine();

                switch (option)
                { 
                    case '0':
                    Console.WriteLine("Salida");
                    break;

                    case '1':
                    CreateAccount();
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
            int balanceAmount;
            int accountType = 1 ;
           

            Console.Clear();

            Console.WriteLine("\nDigite su número de cuenta : ");
            accountNumber = Console.ReadLine();

            Console.WriteLine("\nDigite el nombre del titular de la cuenta: ");
            placeHolder = Console.ReadLine();

            do
            {
                Console.WriteLine("Digite el tipo de cuenta: ");
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
                    }
                
               
            }while (option2);

            balanceAmount = 0;

            BankSociety.CreateAccount(accountNumber,placeHolder,balanceAmount,accountType);

            
        }

    }   
} 
