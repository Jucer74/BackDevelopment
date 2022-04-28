public class Customer: Person{
    public string AccountNumber { get; set; }
    public string AccountType { get; set; }
}

public Customer():base(){

}

public Customer(int Id, string firstName, string lastName, DateTime dateOfBirth, char sex):
        base(id, firstName,lastName, dateOfBirth, sex);{
    this.AccountNumber = accountNumber;
    this.AccountType = accountType;
}