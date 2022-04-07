public class Person{

    //Atributes 
        /* private int id; */

        /* private string FirstName;

        private string LastName;

        private DateTime dateOfBirth;

        private char sex; */

    //Properties
    /*   public int Id 
    {
        get
        {
            return this.Id;
        }

        set
        {
            this.Id = value;
        }
    } */

    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime DateOfBirth { get; set; }

    public char Sex { get; set; }

    //Constructors

    public Person(int id, string firtsName, string lastName, DateTime dateOfBirth, char sex) 
    {
        
    }


    //Methods - Public

    //Methods - Private

}