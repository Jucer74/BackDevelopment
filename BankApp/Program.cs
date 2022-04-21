// See https://aka.ms/new-console-template for more information
public class AplicactioBank
{

    private double clientBalance;
    private string Account;
    private string TypeAccount;

    public double Balance
    {

        get { return clientBalance; }

    }

    public string NumberAccount
    {

        get { return Account; }
        set { Account = value; }

    }

    public bool retiro(double amount)
    {
        if (clientBalance >= amount)
        {
            clientBalance -= amount;
            return true;
        }
        else
        {
            console.WriteLine("fondos insuficientes");
            return false;
        }
    }

}
