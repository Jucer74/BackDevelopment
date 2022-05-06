public class Person
{
    private int id;
    private string firstName;
    private string lastName;
    private DateTime dateOfBirth;
    private char sex;

    public int Id { get; set; }
    public string FirstName { get; set; }

    public string LastName { get; set; }
    public char Sex { get; set; }

    public Person()
    {

    }

    public Person(int id, string firstName, string lastName, DateTime dateOfBirth, char sex)
    {
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.dateOfBirth = dateOfBirth;
        this.sex = sex;
    }
}