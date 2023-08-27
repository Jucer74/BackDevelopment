using System;
using System.Linq.Expressions;

try
    {
        Menu();
    }catch (Exception e)
    {
        Console.WriteLine(e);
    }

    void Menu()
    {
        var option = 0;
        while((Options)option != Options.Exit)
        {
        Console.Write("1. Create Account\n" + "2. Get Balance\n" + "3. Deposit Amount\n" + "4. Withdrawal Amount\n" + "0. Exit\n" + "Select Option:\n");
        option = Console.Read();

        if((Options)option == Options.CreateAccount)
        {}
        else if((Options)option == Options.GetBalance)
        {}
        else if((Options)option == Options.DepositAmount)
        {}
        else if((Options)option == Options.WithdrawalAmount)
        {}
        }

    }

public enum Options
{
    CreateAccount = 1,
    GetBalance = 2,
    DepositAmount = 3,
    WithdrawalAmount = 4,
    Exit = 0
}
