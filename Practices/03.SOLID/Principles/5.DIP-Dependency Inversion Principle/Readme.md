# Dependency Inversion Principle (DIP)
* Las clases de alto nivel no deberían depender de las clases de bajo nivel. Ambas deberían depender de las abstracciones.
* Las abstracciones no deberían depender de los detalles. Los detalles deberían depender de las abstracciones.

En otras palabras, dependa de las interfaces y no de las clases.

### Ejemplo
En este caso tenemos las clases EmployeeData y ProjectData 

**EmployeeData**
```csharp
public class EmployeeData: IEmployeeData
{
  private readonly SqlDatabase sqlDatabase;

  public EmployeeData()
  {
    sqlDatabase = new SqlDatabase(GetConnectionString());
  }
  
  // El resto de la clase 
}
```

**ProjectData**
```csharp
public class ProjectData: IProjectData
{
  private readonly SqlDatabase sqlDatabase;
  
  public ProjectData()
  {
    sqlDatabase = new SqlDatabase(GetConnectionString());
  }
 
  // El resto de la clase 
}
```


### Qué anda mal?
Cada clase internamente utiliza una instancia de la clase **SqlDatabase** para conectarse a la base de datos y si necesitaramos cambiar de tipo de base de datos o cambiar su comportamiento tendriamos que cambiar todas las clases dependientes.


### Cómo lo solucionamos?
La solución, como el nombre del principio lo sugiere, es inyectar la instancia de la base de datos en lugar de crearla internamente dentro de cada clase así:

Para la clase **EmployeeData**

```csharp
using SOLID.Common.SQLData.Interface;
using SOLID.Principles.Define;
using SOLID.Principles.Dto;
using System.Data;

namespace SOLID.Principles;

public class EmployeeData : IEmployeeData
{
    private readonly ISqlDatabase _sqlDatabase;

    public EmployeeData(ISqlDatabase sqlDatabase)
    {
        _sqlDatabase = sqlDatabase;
    }

    /// <summary>
    /// This method used to insert into employee table
    /// </summary>
    /// <param name="empDto">Employee object</param>
    /// <returns>Successfully inserted or not</returns>
    public bool InsertEmployee(EmployeeDto empDto)
    {
        try
        {
            _sqlDatabase.CreateAndOpenConnection();

            var command = _sqlDatabase.CreateCommand(Constants.InsertEmployee);

            _sqlDatabase.AddInParameter(command, "FirstName", empDto.FirstName, 50, DbType.String);
            _sqlDatabase.AddInParameter(command, "LastName", empDto.LastName, 50, DbType.String);
            _sqlDatabase.AddInParameter(command, "HireData", empDto.HireDate, 50, DbType.DateTime);
            _sqlDatabase.AddInParameter(command, "Email", empDto.Email, 50, DbType.String);
            _sqlDatabase.AddInParameter(command, "Phone", empDto.Phone, 50, DbType.String);

            var rowsAffects = _sqlDatabase.ExecuteNonQuery(command);

            return rowsAffects > 0;
        }
        finally
        {
            _sqlDatabase.CloseConnection();
        }
    }

    /// <summary>
    /// Get the Employees from table
    /// </summary>
    /// <returns>a employees Dto List</returns>
    public List<EmployeeDto> GetEmployees()
    {
        try
        {
            _sqlDatabase.CreateAndOpenConnection();

            var command = _sqlDatabase.CreateCommand(Constants.SelectEmployees);
            var dataReader = _sqlDatabase.ExecuteReader(command);

            var employees = new List<EmployeeDto>();

            while (dataReader.Read())
            {
                var emp = new EmployeeDto
                {
                    Id = Convert.ToInt32(dataReader["Id"].ToString()),
                    FirstName = dataReader["FirstName"].ToString()!,
                    LastName = dataReader["LastName"].ToString()!,
                    HireDate = Convert.ToDateTime(dataReader["HireDate"].ToString()),
                    Email = dataReader["Email"].ToString()!,
                    Phone = dataReader["Phone"].ToString()!
                };

                employees.Add(emp);
            }

            return employees;
        }
        finally
        {
            _sqlDatabase.CloseConnection();
        }
    }
}
```

Y para La Clase **ProjectData**
```csharp
using SOLID.Common.SQLData.Interface;
using SOLID.Principles.Define;
using SOLID.Principles.Dto;
using System.Data.SQLite;

namespace SOLID.Principles;

public class ProjectData : IProjectData
{
    private readonly ISqlDatabase _sqlDatabase;

    public ProjectData(ISqlDatabase sqlDatabase)
    {
        _sqlDatabase = sqlDatabase;
    }

    /// <summary>
    /// Get the Pjoects from table
    /// </summary>
    /// <returns>Projects Dto List</returns>
    public List<ProjectDto> GetProjects()
    {
        try
        {
            _sqlDatabase.CreateAndOpenConnection();

            var command = _sqlDatabase.CreateCommand(Constants.SelectProjects);
            var dataReader = _sqlDatabase.ExecuteReader(command);

            var projects = new List<ProjectDto>();

            while (dataReader.Read())
            {
                var prj = new ProjectDto
                {
                    Id = Convert.ToInt32(dataReader["Id"].ToString()),
                    Name = dataReader["Name"].ToString()!,
                    Description = dataReader["Description"].ToString()!,
                    Type = dataReader["Type"].ToString()![0],
                    DepartmentName = dataReader["DepartmentName"].ToString()!,
                    StartDate = Convert.ToDateTime(dataReader["StartDate"].ToString()),
                    Budget = Convert.ToDecimal(dataReader["Budget"].ToString()),
                    ContractorName = dataReader["ContractorName"].ToString()!
                };

                projects.Add(prj);
            }

            return projects;
        }
        finally
        {
            _sqlDatabase.CloseConnection();
        }
    }
}

``` 
Notese que eliminamos la funcion de GetConnectionString de las clases de datos pero la movimos a la clase P**rogram**.

De igual forma usamos la interface y su instancia de la siguiente manera:

```csharp
using SOLID.Common.SQLData.Interface;
using SOLID.Common.SQLData;
using SOLID.Principles;
using SOLID.Principles.Define;
using SOLID.Principles.Dto;
using System.Globalization;
using System.Data.SQLite;

/***********/
/*-- Main -*/
/***********/
ISqlDatabase sqlDatabase = new SqlDatabase(GetConnectionString());
EmployeeData employeeData = new EmployeeData(sqlDatabase);
ProjectData projectData = new ProjectData(sqlDatabase);

try
{
    Menu();
}
catch (Exception e)
{
    Console.WriteLine(e);
}

/*****************/
/*-- Functions --*/
/*****************/
void Menu()
{
    var option = ' ';

    while (option != '0')
    {
        Console.Clear();
        Console.WriteLine("     S.O.L.I.D. Principles    ");
        Console.WriteLine("------------------------------");
        Console.WriteLine("1. Insert new Employee");
        Console.WriteLine("2. Get Employee List");
        Console.WriteLine("3. Generate Employees Report");
        Console.WriteLine("4. Show Projects");
        Console.WriteLine("0. Exit");
        Console.WriteLine("Select Option:");
        option = Console.ReadKey().KeyChar;
        Console.WriteLine();

        switch (option)
        {
            case '0':
                Console.WriteLine("Exit");
                break;

            case '1':
                InsertEmployee();
                break;

            case '2':
                GetEmployees();
                break;

            case '3':
                GenerateReport();
                break;

            case '4':
                ShowProjects();
                break;

            default:
                Console.WriteLine("Invalid Option");
                break;
        }

      ;

        Console.WriteLine("\nPress any key to continue... ");
        Console.ReadKey();
    }
}

void ShowProjects()
{
    Console.Clear();
    Console.WriteLine("Show Projects");
    Console.WriteLine("-------------");
    Console.WriteLine();

    var projectList = projectData.GetProjects();

    Project project = null!;

    foreach (var prj in projectList)
    {
        if (prj.Type == (char)ProjectType.Internal)
        {
            project = new InternalProject();
        }
        if (prj.Type == (char)ProjectType.External)
        {
            project = new ExternalProject();
        }

        project.ShowDetails(prj);
    }

    Console.WriteLine();
}

void GetEmployees()
{
    Console.Clear();
    Console.WriteLine("Employee List");
    Console.WriteLine("-------------");
    Console.WriteLine();

    var employees = employeeData.GetEmployees();

    foreach (var emp in employees)
    {
        DisplayEmployee(emp);
    }

    Console.WriteLine("\n({0}) Rows Retrieved", employees.Count);
    Console.WriteLine();
}

void DisplayEmployee(EmployeeDto emp)
{
    Console.WriteLine($"{emp.Id},{emp.FirstName},{emp.LastName},{emp.HireDate},{emp.Email},{emp.Phone}");
}

void InsertEmployee()
{
    Console.Clear();
    Console.WriteLine("Insert new Employee");
    Console.WriteLine("-------------------");
    Console.WriteLine();

    var employeeDto = CreateEmployeDto();

    if (employeeData.InsertEmployee(employeeDto))
    {
        Console.WriteLine("\nThe Employee was insert Successfully\n");
    }
    else
    {
        Console.WriteLine("\nThe Employee was not inserted\n");
    }
}

EmployeeDto CreateEmployeDto()
{
    Console.Write("First Name             : ");
    var firstName = Console.ReadLine();
    Console.Write("Last Name              : ");
    var lastName = Console.ReadLine();
    Console.Write("Hire Date (yyyy-MM-dd) : ");
    var hireDateString = Console.ReadLine();
    Console.Write("Email                  : ");
    var email = Console.ReadLine();
    Console.Write("Phone                  : ");
    var phone = Console.ReadLine();

    if (!DateTime.TryParseExact(hireDateString, "yyyy-MM-dd", null, DateTimeStyles.None, out var hireDate))
    {
        hireDate = DateTime.Now;
    }

    var employeeDto = new EmployeeDto
    {
        FirstName = firstName!,
        LastName = lastName!,
        HireDate = hireDate,
        Email = email!,
        Phone = phone!
    };

    return employeeDto;
}

void GenerateReport()
{
    Console.Clear();
    Console.WriteLine("Generate Report");
    Console.WriteLine("---------------");
    Console.WriteLine();

    Console.Write("Report File Name         : ");
    var reportFileName = Console.ReadLine();
    Console.Write("Report Type (1-CSV 2-XML): ");
    var reportTypeOption = ' ';
    while (reportTypeOption != (char)ReportType.CSV && reportTypeOption != (char)ReportType.XML)
    {
        reportTypeOption = Console.ReadKey().KeyChar;
    }

    Console.WriteLine();

    var employees = employeeData.GetEmployees();

    IReportGenerator reportGenerator = null!;
    switch ((ReportType)reportTypeOption)
    {
        case ReportType.CSV:
            reportGenerator = new ReportCSV();
            break;

        case ReportType.XML:
            reportGenerator = new ReportXML();
            break;
    };

    reportGenerator.Generate(reportFileName!, employees);

    Console.WriteLine("the report was generated.");
}

/// Build the Connection String to the database
/// </summary>
/// <returns>Connection String</returns>
string GetConnectionString()
{
    var sqlConnectionStringBuilder = new SQLiteConnectionStringBuilder
    {
        DataSource = Constants.DatabaseFileName
    };

    return sqlConnectionStringBuilder.ToString();
}
``` 

Ahora podemos ver que se utiliza un objeto de tipo **ISqlDatabase** y cada clase en su constructor recibe uan instancia del mismo tipo, con lo cual en lugar de instanciarla internamente es creada por fuera de la clase e inyectada al constructor y puede ser usada dentro de la clase. De esta forma y mientras cumpla con la misma interface, la base de datos podría ser de cualquier tipo e incluso el comportamiento de cada método podría ser diferente. 