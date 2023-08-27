using System;
using System.Linq.Expressions;

try
{
    MenuSelect();
}
catch (Exception e)
{
    Console.WriteLine(e);
}
static int Menu()
{
    Console.Write("     Banking Operation       \n" + "--------------------------------\n");
    Console.Write("1. Create Account\n" + "2. Get Balance\n" + "3. Deposit Amount\n" + "4. Withdrawal Amount\n");
    Console.Write("0. Exit\n" + "Select Option:\n");
    string? menuSelected = Console.ReadLine();
    return Convert.ToInt32(menuSelected);
}
void MenuSelect()
{   
    int option = -1;
    do
    {
        
        option = Menu();

        if ((Options)option == Options.CreateAccount)
        {
            Console.WriteLine("Create Account");
        }
        else if ((Options)option == Options.GetBalance)
        { 
            Console.WriteLine("Get Balance");
        }
        else if ((Options)option == Options.DepositAmount)
        { 
            Console.WriteLine("Deposit Amount");
        }
        else if ((Options)option == Options.WithdrawalAmount)
        { 
            Console.WriteLine("Withdrawal Amount");
        }
    }while ((Options)option != Options.Exit);
}

public enum Options
{
    CreateAccount = 1,
    GetBalance = 2,
    DepositAmount = 3,
    WithdrawalAmount = 4,
    Exit = 0
}
