public class Customer : Person
{
    public string AccountNumber { get; set; }

    public string AccountType { get; set; }

    public Customer() : base()
    {
        
    }

    public Customer(int id, string firtsName, string lastName, DateTime dateOfBirth, char sex, string accountType, string accountType) :base (id, firtsName, lastName, dateOfBirth, sex)
    {
        this.AccountNumber = accountNumber;
        this.AccountType = accountType;
    }
}
