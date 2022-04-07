public class Customer:Person
{
    public string  AcountNumber { get; set; }
    public string  AcountType { get; set; }

    public Customer(int id, string firstName,string lastName, DateTime dateOfBirth, char sex,string acountNumber, string acountType):base(id,firstName,lastName,dateOfBirth,sex)
    {   
        this.AcountNumber = acountNumber;
        this.AcountType = acountType;
    }

}