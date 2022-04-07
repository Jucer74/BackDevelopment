public class Person 
{
    //Atributo
    private int id;
    private string firstName;
    private string lastName;
    private DateTime dateOfBirth;
    private char sex;

    //Propiedades
    
    /*public int Id;{
        get{
            return this.id;

        }
        set{
            this.id=value;

        }
    }*/ 

    public int Id{get; set;}
    public string firstName { get; set; }
    public string lastName { get; set; }
    public DateTime dateOfBirth { get; set; }
    public char sex { get; set; }
    
    //Constructores
    public Person(){

    }

    public Person(int Id, string firstName, string lastName, DateTime dateOfBirth, char sex){
        this.Id= id;
        this.FirstName= firstName;
        this.LastName= lastName;
        this.DateOfBirth= dateOfBirth;
        this.Sex=sex;
        
    }

    //Metodo publicos

    //Metodo Privados
}