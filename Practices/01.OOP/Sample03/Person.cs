public class Person
{

    //Constantes

    //Atributos
    //Si se tiene el modo rapido, no necesita esto 
    private int id; 
    private string firstName;
    private string lastName;
    private DateTime dateOfBirth;
    private char sex;

    //Propiedades
    /* MODO ANTIGUO
    public int Id
    {
        get
        {
            return this.id;
        }
        set
        {
            this.id = value;
        }
    } */

    /* MODO RAPIDO */
    public int Id { get; private set;}
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public char Sex { get; set; }

    //Constructores
    public Person (int id, string firstName, string lastName, DateTime dateOfBirth, char sex)
    {
        this.Id = id;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.DateOfBirth = daOfBirth;
        this.Sex = sex;
    }

    //Metodos - Publicos

    //Metodos - Privados

}