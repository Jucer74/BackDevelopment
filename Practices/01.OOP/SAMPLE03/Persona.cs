public class Person 
{
    //atributes

    // private int id;
    // private string firstName, lastName;
    // private DateTime dateOfBirth;
    // private char sex;
    


    //properties
    // public int id
    //{
    //     get{
    //         return this.id;
    //     }
    //     set{
    //         this.id = value;
    //     }
    // }
    // 

    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public char Sex { get; set; }

    
    //Constructors
    public Persona()
    {
        
    }
    public Persona(int id, string firstName,string lastName, DateTime dateOfBirth, char sex)
    {
        
    }
    //Methods - Publics
    //Methods - Privates
}