public  class Customer:Person
{
    public string AccountNumber { get; set; }
    public string AccountType { get; set; }   

    public Customer() : base()
    {

    }

    public Customer (int id
                     , string firstName
                     , string lastName
                     , DateTipe dateOfBirth
                     , char sex
                     , string accountNumber
                     , string AccountType):
        base(id, firstName, dateOfBirth, sex)
    {
        this.AccountNumber = accountNumber;
        this.AccountType = AccountType;
    }
}