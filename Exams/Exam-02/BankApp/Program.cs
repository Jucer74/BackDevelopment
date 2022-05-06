using System;
using System.Collections.Generic;
using System.Globalization;

namespace BankApp
{
    internal class Program
    {
        public static List<BankAccount> accountsList = new List<BankAccount>();
        public static double amountAccount;
        public static double amountWithDrawal;
        public static double lookingAccount = 0;

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
            var option = ' ';

            while (option != '0')
            {
                Console.Clear();
                Console.WriteLine("     BIENVENIDO AL BANCO    ");
                Console.WriteLine("------------------------------");
                Console.WriteLine("1. Crear una cuenta");
                Console.WriteLine("2. Obtener el balance de la cuenta");
                Console.WriteLine("3. Depositar a una cuenta");
                Console.WriteLine("4. Retirar de la cuenta");
                Console.WriteLine("0. Salir");
                Console.WriteLine("Seleccione una opcion:");
                option = Console.ReadKey().KeyChar;
                Console.ReadKey();
                Console.WriteLine();
                Console.Clear();

                switch (option)
                {
                    case '0':
                        Console.WriteLine("Salir");
                        break;
                    case '1':
                        CreateAccount();
                        break;
                    case '2':
                        Balance();
                        break;
                    case '3':
                        Deposit();
                        break;
                    case '4':
                        Withdrawal();
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
              ;

                Console.WriteLine("\nPresiona cualquier tecla para continuar... ");
                Console.ReadKey();
            }
        }

        private static void CreateAccount()
        {
            bool optionType = true;
            int optionTypeAccount;
            BankAccount newAccount;

            do
            {
                Console.WriteLine("Digite el tipo de cuenta: ");
                Console.WriteLine("1. Cuenta de ahorro");
                Console.WriteLine("2. Cuenta corriente");
                Console.WriteLine("Seleccione una opcion:");
                optionTypeAccount = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (optionTypeAccount == 1)
                {
                    newAccount = new SavingAccount();
                }
                else
                {
                    newAccount = new CheckingAccount();
                }

                Console.WriteLine("Digite su Nombre: ");
                newAccount.PlaceHolder = Console.ReadLine();
                Console.Clear();

                Console.WriteLine("Digite el número de su cuenta nueva: ");
                newAccount.AccountNumber = int.Parse(Console.ReadLine());
                Console.Clear();

                newAccount.AccountType = optionTypeAccount;

                accountsList.Add(newAccount);
            } while (!optionType);


            Console.Clear();
            Console.WriteLine($" ¡¡ Cuenta creada !! ");
            Console.WriteLine("Nombre: " + newAccount.PlaceHolder);
            Console.WriteLine("Numero de cuenta: " + newAccount.AccountNumber);
        }

        public static void Balance()
        {
            Console.WriteLine("Ingrese el número de cuenta: ");
            lookingAccount = int.Parse(Console.ReadLine());

            foreach (BankAccount account in accountsList)
            {
                if (account.AccountNumber == lookingAccount)
                {
                    Console.Clear();
                    Console.WriteLine("El valor de su balance es: " + "$ " + account.BalanceAccount);
                }
                else
                {
                    Console.WriteLine("Error: Cuenta no encontrada");
                }
            }
        }

        public static void Deposit()
        {
            Console.WriteLine("Ingrese el número de cuenta: ");
            lookingAccount = int.Parse(Console.ReadLine());

            foreach (BankAccount account in accountsList)
            {
                if (account.AccountNumber == lookingAccount)
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese el valor del monto a depositar: ");
                    amountAccount = int.Parse(Console.ReadLine());
                    account.Deposit(amountAccount);

                    Console.WriteLine("El nuevo valor de su balance es " + "$ " + account.BalanceAccount);
                }
                else
                {
                    Console.WriteLine("Error: Cuenta no encontrada");
                }
            }
        }

        public static void Withdrawal()
        {
            bool optionType = true;

            do
            {
                Console.WriteLine("Ingrese el número de cuenta: ");
                lookingAccount = int.Parse(Console.ReadLine());
                Console.Clear();

                Console.WriteLine("Ingrese el valor del monto a retirar: ");
                amountWithDrawal = int.Parse(Console.ReadLine());

                foreach (BankAccount account in accountsList)
                {
                    if (account.AccountNumber == lookingAccount)
                    {
                        if (account.AccountType == 1)
                        {
                            if (account.BalanceAccount >= amountWithDrawal)
                            {
                                account.Withdrawal(amountWithDrawal);
                                Console.WriteLine("El nuevo valor de su balance es " + "$ " + account.BalanceAccount);
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Error: El monto a retirar es mayor al balance");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            account.Withdrawal(amountWithDrawal);
                            Console.WriteLine("El nuevo valor de su balance es " + "$ " + account.BalanceAccount);
                            Console.ReadKey();
                        }
                    }
                }
            } while (!optionType);
        }
    }
}
