using System;

namespace BankApp
{
    class Program
    {
        private static Bank BankUsb = new Bank();
        private static int cont = 1000;
        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            char opcion = ' ';

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
                        Deposit();
                    break;
                    case '4':
                        Withdrawal();
                    break;
                    default:
                        Console.WriteLine("ERROR. Opción incorrecta");
                    break;
                }

            } while (opcion != '0');
            Console.ReadKey();
            Console.WriteLine("");
            Console.WriteLine("----------Programa finalizado----------");
            
        }

        public static void CreateAcount()
        {
            cont = cont + 1;
            bool Op = true;
            int accountNumber;
            string placeHolder;
            double balanceAmount;
            int accountType = 1;


            Console.Clear();
            Console.WriteLine("Digite su Nombre.");
            placeHolder = Console.ReadLine();
            Console.Clear();
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
                catch (FormatException)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Error. Opcion invalida");
                    Console.WriteLine("");
                }

                
            } while (Op);


            balanceAmount = 0.0;
            accountNumber = cont;
            try
            {
                BankUsb.CreateAccount(accountNumber,placeHolder,balanceAmount,accountType);
                
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"{e.Message}");
            }

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
            bool Op = true;

            do
            {
            Console.Clear();
            Console.WriteLine("Digite su numero de cuenta.");
            Console.Write("Cuenta: ");
                try
                {
                    accountNumber = int.Parse(Console.ReadLine());

                    Console.WriteLine("");
                    Console.WriteLine($"Su balance es: {BankUsb.GetBalance(accountNumber)}$");
                    Console.WriteLine("");
                    Op=false;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"{e.Message}");
                    Console.WriteLine("Digite cualquier tecla para repetir.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error. eso No es un numero");
                    Console.WriteLine("Digite cualquier tecla para repetir.");
                }
                Console.WriteLine("Digite cualquier tecla para continuar.");
                Console.ReadKey();
            } while (Op);
        }

        public static void Deposit()
        {
            int accountNumber;
            double amount = 0.0;
            bool Op = true;

            do
            {
                Console.Clear();
                Console.WriteLine("Digite su numero de cuenta.");
                Console.Write("Cuenta: ");
                try
                {
                    accountNumber = int.Parse(Console.ReadLine());

                    Console.WriteLine("");
                    Console.WriteLine("Digite el monto a depositar");
                    Console.Write("Monto: ");
                    amount = double.Parse(Console.ReadLine());

                    BankUsb.DepositAccount(accountNumber,amount);

                    
                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine("transacion correcta");
                    Console.WriteLine("");
                    Console.WriteLine($"Digite cualquier tecla para continuar");
                    Console.ReadKey();
                    Op=false;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"{e.Message}");
                    Console.WriteLine("Digite cualquier tecla para repetir.");
                    Console.ReadKey();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error. eso No es un numero");
                    Console.WriteLine("Digite cualquier tecla para repetir.");
                    Console.ReadKey();
                }
            } while (Op);
        }

        public static void Withdrawal()
        {
            int accountNumber;
            double amount = 0.0;
            bool Op = true;
            string accountType = "";
            bool iswithdrawal = false;
            char opcion = ' ';

            do
            {
                Console.Clear();
                Console.WriteLine("Digite su numero de cuenta.");
                Console.Write("Cuenta: ");
                try
                {
                    accountNumber = int.Parse(Console.ReadLine());

                    Console.WriteLine("");
                    Console.WriteLine($"Su balance es: {BankUsb.GetBalance(accountNumber)}$");
                    Console.WriteLine("");
                    Console.WriteLine("Digite el monto que desea retirar");
                    Console.Write("Monto: ");
                    amount = double.Parse(Console.ReadLine());

                    iswithdrawal = BankUsb.WithdrawalAccount(accountNumber,amount);

                    if (iswithdrawal)
                    {
                        Console.Clear();
                        Console.WriteLine("");
                        Console.WriteLine("transacion correcta");
                        Console.WriteLine("");
                        Console.WriteLine($"Digite cualquier tecla para continuar");
                        Console.ReadKey();
                        Op=false;
                        
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("!!!CUIDADO!!!");
                        Console.WriteLine("transacion incorrecta");
                        Console.WriteLine("");
                        Console.WriteLine("no puede retirar esa suma ya que su cuenta, es una cuenta de ahorros y no puede retirar mas de lo que tiene.");
                        Console.WriteLine($"Digite la opcion.");
                        Console.WriteLine($"1. Repetir retiro.");
                        Console.WriteLine($"2. Salir.");
                        Console.Write("Opcion: ");
                        opcion = Console.ReadKey().KeyChar;
                        if (opcion == '2')
                        {
                            Op = false;
                        }
                        else if(opcion == '1')
                        {
                            Op = true;
                        }
                        else
                        {
                            Console.WriteLine("Error. esa no es una opcion valida, saliendo al menu.");
                            Op = false;
                            Console.WriteLine("");
                            Console.WriteLine($"Digite cualquier tecla para continuar");
                            Console.ReadKey();
                        }
                        
                    }

                    
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"{e.Message}");
                    Console.WriteLine("Digite cualquier tecla para repetir.");
                    Console.ReadKey();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error. eso No es un numero");
                    Console.WriteLine("Digite cualquier tecla para repetir.");
                    Console.ReadKey();
                }
            } while (Op);

        }
    }
}
