namespace Sample03
{
    using System;

    public class Customer : Person
    {
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }

        public Customer() : base()
        {

        }
        public Customer(int id
                        , string firstName
                        , string lastName
                        , DateTime dateOfBirth
                        , char sex
                        , string accountNumber
                        , string AccountType) :
        base(id, firstName, lastName, dateOfBirth, sex)
        {

        }
    }
}