public class Person
{
    //  Atributes Camel Case

    private int id;
    private string firstname;
    private string lastname;
    private DateTime dateOfBirth;
    private char sex;

    //  Properties Pastal Case
    public int Id{ get; private set;}

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime DateOfBirth { get; set; }

    public char Sex { get; set; }

    //  Constructor Inicializa Los Atributos de la Clase

    public Person()
    {

    }

    public Person(int id, string firstname, string lastname, DateTime  dateOfBirth, char sex)
    {
        this.id = Id;
        this.firstname = FirstName;
        this.lastname = LastName;
        this.dateOfBirth = DateOfBirth;
        this.sex = Sex;
    }
        
    //  Public Methods

    //  Private Methods
}