public class Person
{
    //Atributes (CAMELCASE)
    private int id;
    private string firstName;
    private string lastName;
    private DateTime dateOfBirth;
    private char sex;

    //Properties (PASCAL)

    /* public int Id
    {
        get
        {
            return this.id;
        }
        set
        {
            this.Id = value;
        }
    } */

    //MANERA CORRECTA
    public int Id {get; set;}
    private string FirstName {get; set;}
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public char Sex { get; set; }
    
    //Constructors (CAMELCASE)

    /* public Person()
    {

    } */

    public Person(int id, string firstName, string lastName, DateTime dateOfBirth, char sex)
    {
        this.Id = id;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.DateOfBirth = dateOfBirth;
        this.Sex = sex;
    }

    //Methods - Publics (PASCALCASE)

    //Mthos - Privates (PASCALCASE)

    //Constant's (UpperCase)

    //Parameter (CAMELCASE)

    //Clase (PASCALCASE)
}