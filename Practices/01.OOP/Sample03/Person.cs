public class Person
{
    
    //Properties
    public int Id{get; private set;}
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public char Sex { get; set; }
    
    //Constructors

    public Person()
    {
        
    }

    public Person(int id, string firstName, string lastName, DateTime dateOfBirth, char sex)
    {
        this.Id = id;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.DateOfBirth = dateOfBirth;
        this.Sex = sex;
    }
    //Methods-Public
    //Methos-Private
}