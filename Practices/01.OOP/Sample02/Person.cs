public class Person
{
    //Atributos
    private string firstName;
    private string lastNAME;
    private DateTime dateOfBirth;
    private char sex;

    //Properties
    public int Id { get; private set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public char Sex { get; set; }

    //Constructor
    public Person()
    {
        this.Id = id;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.DateOfBirth = dateOfBirth;
        this.Sex = sex;
    }
}