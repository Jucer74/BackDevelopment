public class Customer : Person
{
 public string AccountNumber { get; set; }
 public string AccountType { get; set; }
                
 public Customer(): base()
 {

 }

 public Person(int id, string firstname, string lastname, DateTime  dateOfBirth, char sex, string accountNumber, string accountType) :
                base(id, firstname, lastname, dateOfBirth, sex)
 {
this.AccountNumber = accountNumber;
this.AccountType = accountType;
 }
}