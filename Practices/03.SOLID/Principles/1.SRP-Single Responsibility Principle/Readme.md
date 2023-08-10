## Single Responsibility Principle (SRP)
Un módulo solo debe tener **un motivo para cambiar**.

Lo cual quiere decir que una clase debería estar destinada a **una única responsabilidad** y no mezclar la de otros o las que no le incumben a su dominio.

## Ejemplo
El siguiente ejemplo es una clase (**ApplicationData**) que permite interactuar con los datos de los empleados y permite generar un reporte con los mismos.

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
    /// Method to generate report
    /// </summary>
    public void GenerateReport(string reportFilename)
    {
        var fullReportFileName = $"{Constants.ReportsPath}{reportFilename}";
        var sw = new StreamWriter(fullReportFileName);

        var employees = GetEmployees();

        foreach (var emp in employees)
        {
            sw.WriteLine($"{emp.Id},{emp.FirstName},{emp.LastName},{emp.HireDate},{emp.Email},{emp.Phone}");
        }

        sw.Flush();
        sw.Close();
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

### Qué anda mal?
El código en general esta bien, pero el problema es que comparte la responsabilidad de generar un reporte, la cual no esta dentro de su dominio principal, el cual es interactuar con los registro de la tabla **Employees**.

Sabemos que no tiene una sola responsabilidad si hacemos las siguientes preguntas:

* Qué clase debemos cambiar si queremos cambiar el tipo de formato en el que se genera el reporte de separado por comas a XML?
* Qué clase debemos cambiar si queremos adicionar una funcion para borrar los datos de los empleados?

Si la respuesta es la misma (**ApplicationData**), entonces esta clase no tiene una sola responsabilidad.

### Comó lo solucionamos?
La forma de solucionarlo es muy sencila, solo separemos responsabilidaddes, y esto lo logramos creando una nueva clase llamada **ReportGenerator** en donde delegamos la responsabilidad de generar el archivo separado por comas y eliminamos esta funcion de la clase **ApplicationData**.

```csharp
using SOLID.Principles.Define;
using SOLID.Principles.Dto;

namespace SOLID.Principles;

public class ReportGenerator
{
    /// <summary>
    /// Method to generate report
    /// </summary>
    public static void Generate(string reportFilename, List<EmployeeDto> employees)
    {
        var fullReportFileName = $"{Constants.ReportsPath}{reportFilename}";
        var sw = new StreamWriter(fullReportFileName);

        foreach (var emp in employees)
        {
            sw.WriteLine($"{emp.Id},{emp.FirstName},{emp.LastName},{emp.HireDate},{emp.Email},{emp.Phone}");
        }

        sw.Flush();
        sw.Close();
    }
}
```
De igual forma cambiamos la referencia a la generacion del reporte en la clse principal de **Program** asi:

```csharp
void GenerateReport()
{
    Console.Clear();
    Console.WriteLine("Generate Report");
    Console.WriteLine("---------------");
    Console.WriteLine();

    Console.Write("Report File Name : ");

    var reportFileName = Console.ReadLine();

    var employees = applicationData.GetEmployees();

    ReportGenerator.Generate(reportFileName!, employees);

    Console.WriteLine("the report was generated.");
}
```

