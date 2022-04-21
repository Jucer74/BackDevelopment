public class BankAccount
{
public int AccountNumber{ get; set; }

public string PlaceHolder{ get; set; }

public double BalanceAmount{ get; set; }

public int AccountType{ get; set; }

public BankAccount()
{
    
}

public BankAccount(int accountNumber, string placeholder, double balanceamount, int accounttype)
{
    this.accountnumber = AccountNumber;
    this.placeholder = PlaceHolder;
    this.balanceamount = BalanceAmount;
    this.accounttype = AccountType;
}

public static void CheckBalance()
{
    return BalanceAmount;
}
public static void Deposit(double quantity)
{
balanceamount = balanceamount + quantity;

return Console.WriteLine("Your New Balance is: "+ balanceamount);

}
public static void Withraw(double quantity)
{
balanceamount = balanceamount - quantity;

return Console.WriteLine("Thank you for withrawing, your new balance is" + balanceamount);
}
}
