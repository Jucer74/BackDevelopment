public class Person
{
    
    //Atrtibutes -> Valores internos de mi clase. Siempre se encapsulan en una propiedad (get,set)
    // private int id;
    private string firstname;
    private string lastname;
    private DateTime dateOfBirth;
    private char sex;


    //Properties
    // public int Id
    // {
    //     get
    //     {
    //         return this.id;    
    //     }
    //     set
    //     {
    //         this.id = value;
    //     }
    // }

    public int Id { get; set;}
    public string Firstname { get; set; }

    public string Lastname { get; set; }
    public DateTime DateOfBirth { get; set; }
    public char Sex { get; set; }

    //Constructors
    public Person()
    {

    }

    public Person(int id, string firstname, string lastname, DateTime dateOfBirth, char sex)
    {
        this.Id = id;
        this.Firstname = firstname;
        this.Lastname = lastname;
        this.DateOfBirth = dateOfBirth;
        this.Sex = sex;
    }
    //Methods - publics
    
    //Methods - privates
    

}