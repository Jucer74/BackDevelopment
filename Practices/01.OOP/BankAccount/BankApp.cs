using System;

namespace BankAccount
{
    class BankApp

    {
        public int AccountNumber;
        public string PlaceHolder;
        public double BalanceAmount;
        public int AccountType;

        private static void Main(string[] args)
        {
            Console.WriteLine("Starting...");
            Menu();
        }
        private static void Menu()
            {
                
            var option = ' ';

            while (option != '0')
            {
                Console.Clear();
                Console.WriteLine("     National Bank Services   ");
                Console.WriteLine("------------------------------");
                Console.WriteLine("1. Create a New Account");
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
                   Console.WriteLine("Create Account");
                    break;

                case '2':
                    Console.WriteLine("Get Balance");
                    break;

                case '3':
                    Console.WriteLine("Deposit");
                    break;

                case '4':
                    Console.WriteLine("Withdrawal");
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
/*         public List<BankAccountInformation> AccountList()
        {
            var employees = new List<EmployeeDto>();

            while (dataReader.Read())
            {
                var emp = new EmployeeDto
                {
                    Id = Convert.ToInt32(dataReader["Id"].ToString()),
                    FirstName = dataReader["FirstName"].ToString(),
                    LastName = dataReader["LastName"].ToString(),
                    HireDate = Convert.ToDateTime(dataReader["HireDate"].ToString()),
                    Email = dataReader["Email"].ToString(),
                    Phone = dataReader["Phone"].ToString()
                };

                employees.Add(emp);
            }
        } */
        private static void CreateAccount()
        {
            Console.Clear();
            Console.WriteLine("Insert new Employee");
            Console.WriteLine("-------------------");
             Console.WriteLine();

             var employeeDto = CreateEmployeDto();

             if (employeeData.InsertEmployee(employeeDto))
            {
                Console.WriteLine("\nThe Employee was insert Successfully\n");
            }
            else
            {
                Console.WriteLine("\nThe Employee was not inserted\n");
            }
        }

        private static AccountDto CreateEmployeDto()
        {
            Console.Write("Account Number             : ");
            var accountNumber = Console.ReadLine();
            Console.Write("PlaceHolder              : ");
            var placeHolder = Console.ReadLine();
            Console.Write("Account Type : ");
            var accountType = Console.ReadLine();
            Console.Write("Balance Amount                  : ");
            var balanceAmount = Console.ReadLine();
            Console.Write("OverdraftAmount                  : ");
            var overdraftAmount = Console.ReadLine();

            var accountDto = new AccountDto
            {
                AccountNumber = accountNumber,
                PlaceHolder = placeHolder,
                AccountType = accountType,
                BalanceAmount = balanceAmount,
                OverdraftAmount = overdraftAmount,
            };

            return employeeDto;
        }        

         private static void GetBalance()
        {
            //AccountNumber
        }
         private static void DepositAccount()
        {
            //AccountNumber
            //Amount
        }

        private static void WithdrawalAccount()
        {
            //AccountNumber
            //Amount => Checking Amount
        }

    }
}
