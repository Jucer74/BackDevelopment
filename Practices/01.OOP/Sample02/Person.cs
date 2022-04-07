public class Person
{
    //Propiedades - Properties
    public int Id {get; private set;}
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public char Sex { get; set; }

    //Constructores - Constructor
    public Person()
    {

    }
    
    public Person(int id, string firstName, string lastName, DataTime dateOfBirth, char sex)
    {
        this.Id = id;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.DateOfBirth = dateOfBirth;
        this.Sex = sex;
    }

    //Metodos Publicos - Methods Publics

    //Metodos Privados - Methods Privates
}