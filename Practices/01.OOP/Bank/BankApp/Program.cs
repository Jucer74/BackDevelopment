using System;

namespace BankApp
{
    class Program
    {
        private static Bank BankUsb = new Bank();
        static void Main(string[] args)
        {

        }

        public static void Menu()
        {
            char opcion = ' ';
            int cont = 1000;

            do
            {
                Console.Clear();
                Console.WriteLine("           Bienvenido         ");
                Console.WriteLine("************BankUsb************");
                Console.WriteLine("1. Crear cuenta");
                Console.WriteLine("2. Obtener balance");
                Console.WriteLine("3. Depositar en la cuenta");
                Console.WriteLine("4. Retirar dinero");
                Console.WriteLine("0. Crear cuenta");
                Console.WriteLine("*************Menu**************");
                Console.Write("Opción: ");
                opcion = Console.ReadKey().KeyChar;
                Console.WriteLine("");

                switch (opcion)
                {
                    case '0':
                        Console.WriteLine("Digite cualquier tecla para finalizar");
                    break;
                    case '1':
                        CreateAcount();
                    break;
                    case '2':
                        GetBalanceAccount();
                    break;
                    case '3':

                    break;
                    case '4':

                    break;
                    default:
                        Console.WriteLine("ERROR. Opción incorrecta");
                    break;
                }

            } while (opcion != '0');
            Console.WriteLine("");
            Console.WriteLine("----------Programa finalizado----------");
            
        }

        public static void CreateAcount()
        {
            cont++;
            bool Op = true;
            int accountNumber;
            string placeHolder;
            decimal balanceAmount;
            int accountType;


            Console.Clear();
            Console.WriteLine("Digite su Nombre.");
            placeHolder = Console.ReadLine();
            Console.WriteLine("Digite su balance inicial.");
            do
            {
                Console.WriteLine("Digite el tipo de cuenta.");
                Console.WriteLine("1. Cuenta de ahorro");
                Console.WriteLine("2. Cuenta corriente");
                try
                {
                    accountType = int.Parse(Console.ReadLine());

                    if (accountType >= 1 && accountType <= 2)
                    {
                        Op = false;
                    }
                    else
                    {
                        Op = true;
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("Error. Opcion invalida");
                }

                
            } while (Op);


            balanceAmount = 0.0;
            accountNumber = cont;

            BankUsb.CreateAccount(accountNumber,placeHolder,balanceAmount,accountType);

            Console.Clear();
            Console.WriteLine($"---------------------------");
            Console.WriteLine($"     Cuenta creada");
            Console.WriteLine("");
            Console.WriteLine($"Su numero de cuenta es: {accountNumber}");
            Console.WriteLine($"");
            Console.WriteLine($"Digite cualquier tecla para continuar");
            Console.ReadKey();


        }

        public static void GetBalanceAccount()
        {
            int accountNumber;


            Console.Clear();
            Console.WriteLine("Digite su numero de cuenta.");
            Console.Write("Cuenta: ");
            try
            {
                accountNumber = int.Parse(Console.ReadLine());

                Console.WriteLine($"Su balance es: {BankUsb.GetBalance()}$");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"{e.Message}");
            }


        }
    }
}
