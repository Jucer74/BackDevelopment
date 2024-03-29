# Interface Segregation Principle (ISP)
Muchas interfaces especificas son mejores que una sola interfaz.

Un problema muy común es tener una **interfaz obsesa**, es decir con muchas funcionalidades y el problema radica cuando queremos hacer uso de esta tenemos métodos que no vamos a poder usar.


### Ejemplo
En este caso tenemos la clase **ApplicationData**, que se encarga de realizar la acciones sobre los datos e interactua con la base de datos.

```csharp
using SOLID.Common.SQLData;
using SOLID.Principles.Define;
using SOLID.Principles.Dto;
using System.Data;
using System.Data.SQLite;

namespace SOLID.Principles;

public class ApplicationData
{
    private readonly SqlDatabase sqlDatabase;

    public ApplicationData()
    {
        sqlDatabase = new SqlDatabase(GetConnectionString());
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
            sqlDatabase.CreateAndOpenConnection();

            var command = sqlDatabase.CreateCommand(Constants.InsertEmployee);

            sqlDatabase.AddInParameter(command, "FirstName", empDto.FirstName, 50, DbType.String);
            sqlDatabase.AddInParameter(command, "LastName", empDto.LastName, 50, DbType.String);
            sqlDatabase.AddInParameter(command, "HireData", empDto.HireDate, 50, DbType.DateTime);
            sqlDatabase.AddInParameter(command, "Email", empDto.Email, 50, DbType.String);
            sqlDatabase.AddInParameter(command, "Phone", empDto.Phone, 50, DbType.String);

            var rowsAffects = sqlDatabase.ExecuteNonQuery(command);

            return rowsAffects > 0;
        }
        finally
        {
            sqlDatabase.CloseConnection();
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
            sqlDatabase.CreateAndOpenConnection();

            var command = sqlDatabase.CreateCommand(Constants.SelectEmployees);
            var dataReader = sqlDatabase.ExecuteReader(command);

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
            sqlDatabase.CloseConnection();
        }
    }

    /// <summary>
    /// Get the Pjoects from table
    /// </summary>
    /// <returns>Projects Dto List</returns>
    public List<ProjectDto> GetProjects()
    {
        try
        {
            sqlDatabase.CreateAndOpenConnection();

            var command = sqlDatabase.CreateCommand(Constants.SelectProjects);
            var dataReader = sqlDatabase.ExecuteReader(command);

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
            sqlDatabase.CloseConnection();
        }
    }

    /// <summary>
    /// Build the Connection String to the database
    /// </summary>
    /// <returns>Connection String</returns>
    private static string GetConnectionString()
    {
        var sqlConnectionStringBuilder = new SQLiteConnectionStringBuilder
        {
            DataSource = Constants.DatabaseFileName
        };

        return sqlConnectionStringBuilder.ToString();
    }
}
```
Aunque no es una interface si tiene muchas acciones, y se encarga de interactuar con dos tablas,  y se podría implementar una sola interfaz con todas las funciones y en esta clase implementarlas. 

### Qué anda mal?
La clase **ApplicationData** se encarga de todas las operaciones sobre la base de datos y sobre dos tablas diferentes lo que la hace ser una clase obesa a pesar de no ser la implementación de una interfaz.

De igual manera vemos que la clase **Program** utiliza directamente el llamado a esta clase para interactuar con los datos de las dos funcionalidades directamente asi:

```csharp
using SOLID.Principles;
using SOLID.Principles.Define;
using SOLID.Principles.Dto;
using System.Globalization;

/***********/
/*-- Main -*/
/***********/
ApplicationData applicationData = new ApplicationData();

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

    var projectList = applicationData.GetProjects();

    Project project = null;

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

    var employees = applicationData.GetEmployees();

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

    if (applicationData.InsertEmployee(employeeDto))
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

    var employees = applicationData.GetEmployees();

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
```
Aca podemos ver el uso de la clase **ApplicationData** y el llamado de los métodos para cada tabla (Employees y Projects)


### Cómo lo solucionamos?
La solucion es sencilla, es dividir y especificar, es decir crear una interface y una clase para para cada tabla, en lugar de tener una sola para todas las interacciones con la base de datos así:

Para la tabla **Employees**

Creamos La Interface **IEmployeeData** asi:
```csharp
using SOLID.Principles.Dto;

namespace SOLID.Principles;

public interface IEmployeeData
{
    /// <summary>
    /// This method used to insert into employee table
    /// </summary>
    /// <param name="empDto">Employee object</param>
    /// <returns>Successfully inserted or not</returns>
    bool InsertEmployee(EmployeeDto empDto);

    /// <summary>
    /// Get the Employees from table
    /// </summary>
    /// <returns>a employees Dto List</returns>
    List<EmployeeDto> GetEmployees();
}
```

Creamos la Clase **EmployeeData** que implementa la interface correspondiente asi>
```csharp
using SOLID.Common.SQLData;
using SOLID.Principles.Define;
using SOLID.Principles.Dto;
using System.Data;
using System.Data.SQLite;

namespace SOLID.Principles;

public class EmployeeData : IEmployeeData
{
    private readonly SqlDatabase sqlDatabase;

    public EmployeeData()
    {
        sqlDatabase = new SqlDatabase(GetConnectionString());
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
            sqlDatabase.CreateAndOpenConnection();

            var command = sqlDatabase.CreateCommand(Constants.InsertEmployee);

            sqlDatabase.AddInParameter(command, "FirstName", empDto.FirstName, 50, DbType.String);
            sqlDatabase.AddInParameter(command, "LastName", empDto.LastName, 50, DbType.String);
            sqlDatabase.AddInParameter(command, "HireData", empDto.HireDate, 50, DbType.DateTime);
            sqlDatabase.AddInParameter(command, "Email", empDto.Email, 50, DbType.String);
            sqlDatabase.AddInParameter(command, "Phone", empDto.Phone, 50, DbType.String);

            var rowsAffects = sqlDatabase.ExecuteNonQuery(command);

            return rowsAffects > 0;
        }
        finally
        {
            sqlDatabase.CloseConnection();
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
            sqlDatabase.CreateAndOpenConnection();

            var command = sqlDatabase.CreateCommand(Constants.SelectEmployees);
            var dataReader = sqlDatabase.ExecuteReader(command);

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
            sqlDatabase.CloseConnection();
        }
    }

    /// <summary>
    /// Build the Connection String to the database
    /// </summary>
    /// <returns>Connection String</returns>
    private static string GetConnectionString()
    {
        var sqlConnectionStringBuilder = new SQLiteConnectionStringBuilder
        {
            DataSource = Constants.DatabaseFileName
        };

        return sqlConnectionStringBuilder.ToString();
    }
} 
``` 
Para la tabla **Projects**

Creamos la Interface **IProjectData** asi:
```csharp
using SOLID.Principles.Dto;

namespace SOLID.Principles;

public interface IProjectData
{
    /// <summary>
    /// Get the Pjoects from table
    /// </summary>
    /// <returns>Projects Dto List</returns>
    List<ProjectDto> GetProjects();
}
```

Creamos la Clase **ProjectData** para implementar la interface correspondiente asi:
```csharp
using SOLID.Common.SQLData;
using SOLID.Principles.Define;
using SOLID.Principles.Dto;
using System.Data.SQLite;

namespace SOLID.Principles;

public class ProjectData : IProjectData
{
    private readonly SqlDatabase sqlDatabase;

    public ProjectData()
    {
        sqlDatabase = new SqlDatabase(GetConnectionString());
    }

    /// <summary>
    /// Get the Pjoects from table
    /// </summary>
    /// <returns>Projects Dto List</returns>
    public List<ProjectDto> GetProjects()
    {
        try
        {
            sqlDatabase.CreateAndOpenConnection();

            var command = sqlDatabase.CreateCommand(Constants.SelectProjects);
            var dataReader = sqlDatabase.ExecuteReader(command);

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
            sqlDatabase.CloseConnection();
        }
    }

    /// <summary>
    /// Build the Connection String to the database
    /// </summary>
    /// <returns>Connection String</returns>
    private static string GetConnectionString()
    {
        var sqlConnectionStringBuilder = new SQLiteConnectionStringBuilder
        {
            DataSource = Constants.DatabaseFileName
        };

        return sqlConnectionStringBuilder.ToString();
    }
}
``` 
De esta forma cambiamos de usar una sola clase y usamos una especifica por cada tabla y cada una de ellas solo con las operaciones propias de cada una.

Por lo tanto cambiamos la clase **Program** para hacer uso específico de cada una así:

```csharp
using SOLID.Principles;
using SOLID.Principles.Define;
using SOLID.Principles.Dto;
using System.Globalization;

/***********/
/*-- Main -*/
/***********/
EmployeeData employeeData = new EmployeeData();
ProjectData projectData = new ProjectData();

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
``` 
De esta forma podemos eliminar la clse **ApplictionData** y excluirla del proyecto.