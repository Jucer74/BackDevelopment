public class Person{
	private int id;
	private string firstName;
	private string lastName;
	private DateTime dateOfBirth;
	private char sex;

	public int Id{
		get{
          return this.id;
		}
		set{
           this.id = value;
		}
	}

    public int Id { get; set; }

    public string FirtsName { get; set; }

    public string LastName { get; set; }

    public DateTime DateOfBirth { get; set; }

    public char Sex { get; set; }

	public Person()
    {

    }

	public Person(int id, string firstName, string lastName, DateTime dateOfBirth, char sex)
    {
		this.Id = id
		this.FirtsName = firstName;
		this.LastName = lastName;
		this.DateOfBirth = dateOfBirth;
		this.Sex = sex;
    }

}