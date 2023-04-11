# Liskov Substitution Principle (LSP)

La **L** de SOLID alude al apellido de quien lo creó, **Barbara Liskov**, y dice que “las clases derivadas deben poder sustituirse por sus clases base”.

*Si **S** es un subtipo de **T**, entonces los objetos de tipo **T** pueden ser sustituidos por objetos de tipo **S** (es decir, los objetos de tipo **S** pueden sustituir objetos de tipo **T**), sin alterar ninguna de las propiedades deseables de la aplicación.
*

En pocas palabras, que una clase hija puede ser usada como si fuera una clase padre sin alterar su comportamiento.

Por ejemplo, cuando trabajamos con herencia creamos una clase hija para que herede las funcionalidades de la clase padre pero lo que pasa es que a veces hay métodos que no queremos usar y al ser heredado quedan accesibles a través de nuestra nueva clase. La solución simple es sobrescribirlos y hacer que arrojen una excepción o dejarlos vacío

### Ejemplo
En el ejemplo adicionamos la opcion de mostrar los datos de los proyectos actuales, en la clase **Program** asi:

```csharp
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
```

Ahora definimos dos tipos de proyectos, internos y externos, los cuales son definidos en la clase **Define** asi:
```csharp
public enum ProjectType
{
    Internal = 'I',
    External = 'E'
}
```
De igual forma adicionamos la nueva constante **SelectProjects** con la definicion de la consulta para poder obtener los datos de los proyectos asi:
```csharp
public class Constants
{
    public static readonly string DatabaseFileName = @"..\..\..\..\SOLID.Database\SOLIDDb.sqlite3";
    public static readonly string ReportsPath = @"..\..\..\..\Reports\";
    public static readonly string SelectEmployees = "SELECT Id, FirstName, LastName, HireDate, Email, Phone FROM Employees";
    public static readonly string InsertEmployee = "INSERT INTO Employees (FirstName, LastName, HireDate, Email, Phone) VALUES (?, ?, ?, ?, ?)";
    public static readonly string UpdateEmployees = "UPDATE Employees SET HireDate = datetime('now') WHERE Id = 1";
    public static readonly string SelectProjects = "SELECT Id, Name, Description, Type, DepartmentName, StartDate, Budget, ContractorName FROM Projects";
}

```

Tambien definimos una nueva clase llamada **ProjectDto** para poder administrar los datos de los proyectos asi:
```csharp
using System.ComponentModel.DataAnnotations;

namespace Solid.Principles.Dto;

public class ProjectDto
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;

    [Required]
    public char Type { get; set; }

    [Required]
    public string DepartmentName { get; set; } = null!;

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public decimal Budget { get; set; }

    [Required]
    public string ContractorName { get; set; } = null!;
}
```

Simplificamos la obtencion de los proyectos adicionando la function **GetProjects** dentro de la clase **ApplicationData** asi:
```csharp
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
```

Definimos la clase **Project**, la cual permite mostrar los datos básicos del proyecto, así:

```csharp
using SOLID.Principles.Dto;
using SOLID.Principles.Define;

namespace SOLID.Principles;

public class Project
{
    public virtual void ShowDetails(ProjectDto projectDto)
    {
        ProjectType projectType = projectDto.Type == (char)ProjectType.Internal ? ProjectType.Internal : ProjectType.External;

        Console.WriteLine("{0}", "".PadRight(50, '-'));
        Console.WriteLine("Project Details");
        Console.WriteLine("---------------");
        Console.WriteLine($"Id : {projectDto.Id}\t\t\tType : {projectDto.Type}-{projectType.ToString()}\n");
        Console.WriteLine($"Name : {projectDto.Name}\n");
        Console.WriteLine($"Description :\n{projectDto.Description}\n");
    }
}
```

Ahora creamos La clase **InternalProject** permite mostrar los datos adicionales correspondinetes a la información interna.

```csharp
using SOLID.Principles.Dto;

namespace SOLID.Principles;

public class InternalProject : Project
{
    public override void ShowDetails(ProjectDto projectDto)
    {
        base.ShowDetails(projectDto);

        Console.WriteLine("Internal Details");
        Console.WriteLine("----------------");
        Console.WriteLine($"Start Date : {projectDto.StartDate}\t\tDepartment Name : {projectDto.DepartmentName}\n");
    }
}
```

Y tambien creamos La clase **ExternalProject** permite mostrar los datos adicionales correspondientes a las información externa. 

```csharp
using SOLID.Principles.Dto;

namespace SOLID.Principles;

public class ExternalProject : Project
{
    public void ShowBudgetDetails(ProjectDto projectDto)
    {
        base.ShowDetails(projectDto);

        Console.WriteLine("External Details");
        Console.WriteLine("----------------");
        Console.WriteLine($"Budget : {projectDto.Budget}\t\t\tContractor Name : {projectDto.ContractorName}\n");
    }
}
```


### Qué anda mal?
Si revisamos el código la clase **InternalProject** sobresecribe la función **ShowDetails** pero internamente utiliza la función de su clase padre:

```csharp
base.ShowDetails(projectDto)
```

Lo cual permite mostrar correctamente los datos básicos del proyecto y adiciona los datos del proyecto interno.

Por otra parte miramos la clase **ExternalProject**, en donde encontramos una nueva función llamada **ShowBudgetDetails** que permite mostrar los datos del proyecto externo, pero notamos que no se implementa o no se sobreescribe la funcion de la clase padre, lo cual solo permite que no se genere excepción al ejecutar el llamado de  esta clase, pero si no se llama a esta nueva función entonces no se muestran los datos del proyecto externo.

Miremos el llamado actual, En este caso la salida de los proyectos es la siguiente:

```
Show Projects
-------------

--------------------------------------------------
Project Details
---------------
Id : 1  Type : I-Internal

Name : Digital Transformation

Description :
Migrate all internal systems to the new cloud platform.

Internal Details
----------------
Start Date : 10/8/2020 12:00:00 AM  Department Name : IT

--------------------------------------------------
Project Details
---------------
Id : 2  Type : E-External

Name : Government Audit

Description :
Validate compliance with government standards to present new projects.
```

En este caso vemos que el primer proyecto muestra los datos basicos y luego adiciona los datos internos, pero en el segundo solo se muestran los datos básicos y no adiciona los datos externos.

### Cómo lo solucionamos?
La forma de solucionarlo es independizando la implementacion de cada detalle tanto interno como externo, mediante el uso de una interface y una clase que la implementa, así:

**Proyecto Interno**

Definimos La Interface **IInternalDetails** asi:
```csharp
using SOLID.Principles.Dto;

namespace SOLID.Principles;

public interface IInternalDetails
{
  void ShowInternal(ProjectDto projectDto);
}
```

Modificamos la Clase **InternalProjec** para adicionar la dependencia de la nueva interface asi:
```csharp
using SOLID.Principles.Dto;

namespace SOLID.Principles;

public class InternalProject : Project, IInternalDetails
{
    public override void ShowDetails(ProjectDto projectDto)
    {
        base.ShowDetails(projectDto);
        ShowInternal(projectDto);
    }

    public void ShowInternal(ProjectDto projectDto)
    {
        Console.WriteLine("Internal Details");
        Console.WriteLine("----------------");
        Console.WriteLine($"Start Date : {projectDto.StartDate}\t\tDepartment Name : {projectDto.DepartmentName}\n");
    }
}
```

**Proyecto Externo**

Definimos La Interface **IExternalDetails** asi:
```csharp
using SOLID.Principles.Dto;

namespace SOLID.Principles;

public interface IExternalDetails
{
    void ShowExternal(ProjectDto projectDto);
}
```

Modificamos La Clase **ExternalProject** para adicionar la dependencia de los detalles internos y externos usando las nuevas interfaces asi:
```csharp
using SOLID.Principles.Dto;

namespace SOLID.Principles;

public class ExternalProject : Project, IInternalDetails, IExternalDetails
{
    public override void ShowDetails(ProjectDto projectDto)
    {
        base.ShowDetails(projectDto);
        ShowInternal(projectDto);
        ShowExternal(projectDto);
    }

    public void ShowInternal(ProjectDto projectDto)
    {
        Console.WriteLine("Internal Details");
        Console.WriteLine("----------------");
        Console.WriteLine($"Start Date : {projectDto.StartDate}\t\tDepartment Name : {projectDto.DepartmentName}\n");
    }

    public void ShowExternal(ProjectDto projectDto)
    {
        Console.WriteLine("External Details");
        Console.WriteLine("----------------");
        Console.WriteLine($"Budget : {projectDto.Budget}\t\t\tContractor Name : {projectDto.ContractorName}\n");
    }
}
```

Si revisamos **IInternalProject** crea una nueva funcion llamada **ShowInternal** para solo mostrar los datos Internos del proyecto y a su vez la clase **InternalProject** se modificó para heredar de clase **Project** e implementar la interface.

De otro lado la interface **IExternalProject** crea una nueva función llamada **ShowExternal** para solo mostrar los datos externos del proyecto y a su vez la clase **ExternalProject** hereda de la clase padre **Project** pero tambien de las interfaces **IInternalProject** e **IExternalProject**.

Ambas clases sobrescriben la funcion **ShowDetails** de la clase padre, pero internamente usan la función base y adicionan solo los datos necesarios segun el tipo de proyecto.

El resultado ahora permite mostrar los datos de forma correcta así:
```
Show Projects
-------------

----------------------------------------------------------------------------------------------------
Project Details
---------------
Id : 1  Type : I-Internal

Name : Digital Transformation

Description :
Migrate all internal systems to the new cloud platform.

Internal Details
----------------
Start Date : 10/8/2020 12:00:00 AM  Department Name : IT

----------------------------------------------------------------------------------------------------
Project Details
---------------
Id : 2  Type : E-External

Name : Government Audit

Description :
Validate compliance with government standards to present new projects.

Internal Details
----------------
Start Date : 7/27/2020 12:00:00 AM  Department Name : Account

External Details
----------------
Budget : 15830.99   Contractor Name : Microsoft Corp.
```

Ahora podemos ver que el proyecto Interno muestra los datos básicos y los datos internos, mientras que el proyecto externo muestra estos valores mas los datos externos del proyecto.

