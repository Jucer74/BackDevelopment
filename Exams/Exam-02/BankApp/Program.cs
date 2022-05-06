namespace Bank
{

    using System;
    using System.Globalization;
    using Dto;

    internal class Program
    {
        private static readonly ApplicationData applicationData = new ApplicationData();
        private static void Main(string[] args)
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
                Console.WriteLine("     BankApp    ");
                Console.WriteLine("------------------------------");
                Console.WriteLine("1. Create Account ");
                Console.WriteLine("2. Get Balance Account");
                Console.WriteLine("3. Deposit Account");
                Console.WriteLine("4. Withdrawal Account");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Select Option:");
                option = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (option)
                {
                    case '0':
                        Console.WriteLine("Exit");
                        break;
                    case '1':
                        GetEmployees();
                        break;
                    case '2':
                        GetEmployees();
                        break;
                    case '3':
                        GetEmployees();
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }

              ;

                Console.WriteLine("\nPress any key to continue... ");
                Console.ReadKey();
            }
        }

        private static void GetEmployees()
    {
      Console.Clear();
      Console.WriteLine("Employee List");
      Console.WriteLine("-------------");
      Console.WriteLine();

      var employees = applicationData.GetEmployees();

      foreach (var emp in employees)
      {
        DisplayEmployee(emp);
      }

      Console.WriteLine("\n({0}) Rows Retrieved", employees.Count);
      Console.WriteLine();
    }
    }
}