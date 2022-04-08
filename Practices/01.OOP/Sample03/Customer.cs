public class Customer: Person
{
   public string AccountNumber { get; set; }
   public string AccountType { get; set; }

   public Customer(): base()
   {
      
   }

   public Customer( int id
                  , string firstName
                  , string lastNane
                  , DateTime dateOfBirth
                  , char sex
                  , string accoountNumber
                  , string accountType): 
         base(id, firstName,lastNane, dateOfBirth, sex)
   {
      this.AccountNumber = accoountNumber;
      this.AccountType = accountType;
   }
}