public class Person
{
    //Los tipos de campos de la clase depende del negocio (contexto de uso)
    // Atributes (camel Case)
    
    //Properties (Pascal Case)
    public int id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public char Sex { get; set; }

    //Contructor (inicializar los atributos de la clase)
    public Person(int id, string firstName, string lastName, DateTime dateOfBirth, char sex)
    {
        this.Id = id;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.DateOfBirth = dateOfBirth;
        this.Sex = sex;
    }
}