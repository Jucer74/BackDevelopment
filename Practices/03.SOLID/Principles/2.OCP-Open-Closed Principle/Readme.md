# Open/Close Principle (OCP)
Un módulo o clase debe **estar abierto para su extensión** pero **cerrado para su modificación**.

Lo cual permite que sea facilmente extendible sin tener que modificarse internamente.

### Ejemplo
En este ejemplo modificaremos la clase **ReporGenerator** para que se puedan crear reportes en formato separado por comas o en formato XML así:

```csharp
namespace Solid.Principles
{
  using System.Collections.Generic;
  using System.IO;
  using System.Xml.Serialization;
  using Define;
  using Dto;

  public class ReportGenerator
  {
    /// <summary>
    /// Method to generate report
    /// </summary>
    public static void Generate(string reportFilename, List<EmployeeDto> employees, ReportType reporType)
    {
      switch (reporType)
      {
        case ReportType.CSV:
          GenerateCSV(reportFilename, employees);
          break;
        case ReportType.XML:
          GenerateXML(reportFilename, employees);
          break;
      }
    }

    private static void GenerateCSV(string reportFilename, List<EmployeeDto> employees)
    {
      var fullReportFileName = $"{Constants.ReportsPath}{reportFilename}.csv";
      var sw = new StreamWriter(fullReportFileName);

      foreach (var emp in employees)
      {
        sw.WriteLine($"{emp.Id},{emp.FirstName},{emp.LastName},{emp.HireDate},{emp.Email},{emp.Phone}");
      }

      sw.Flush();
      sw.Close();
    }

    private static void GenerateXML(string reportFilename, List<EmployeeDto> employees)
    {
      var fullReportFileName = $"{Constants.ReportsPath}{reportFilename}.xml";
      var sw = new StreamWriter(fullReportFileName);
      XmlSerializer xml = new XmlSerializer(typeof(List<EmployeeDto>));
      xml.Serialize(sw, employees);
      sw.Flush();
      sw.Close();
    }
  }
}

```

De igual forma crearemos un nuevo tipo de dato para poder seleccionar el tipo de reporte, creando una nueva enumeracion dentro del archivo de **Define** asi:

```csharp
public enum ReportType
{
  CSV='1',
  XML='2'
}
```


### Qué anda mal?
Si queremos adicionar un nuevo formato como por ejemplo PDF, deberiamos modificar la misma Clase (**ReportGenerator**), por lo tanto se estaría rompiendo el princio de OCP, pues la idea es que este abierto para extender una nueva funcionalidad sin tener que modificar la clase.

### Cómo lo solucionamos?
La forma de solucionarlo es permitir que su implementacion de la función que genera el reporte, no dependa de la clase en si, sino de los argumentos que reciba para poder ejecutar su operación, de la siguiente manera:

1. creamos una Interface para independizar su implementación así:

```csharp
using SOLID.Principles.Dto;

namespace SOLID.Principles;

public interface IReportGenerator
{
    void Generate(string reportFilename, List<EmployeeDto> employees);
}
```

2. creamos una clase por cada tipo de reporte que queramos generar.

Una clase para el Formato separado por comas.
```csharp
using SOLID.Principles.Define;
using SOLID.Principles.Dto;

namespace SOLID.Principles;

public class ReportCSV : IReportGenerator
{
    public void Generate(string reportFilename, List<EmployeeDto> employees)
    {
        var fullReportFileName = $"{Constants.ReportsPath}{reportFilename}.csv";
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

Una clase para el formato XML
```csharp
using SOLID.Principles.Define;
using SOLID.Principles.Dto;
using System.Xml.Serialization;

namespace SOLID.Principles;

public class ReportXML : IReportGenerator
{
    public void Generate(string reportFilename, List<EmployeeDto> employees)
    {
        var fullReportFileName = $"{Constants.ReportsPath}{reportFilename}.xml";
        var sw = new StreamWriter(fullReportFileName);
        XmlSerializer xml = new XmlSerializer(typeof(List<EmployeeDto>));
        xml.Serialize(sw, employees);
        sw.Flush();
        sw.Close();
    }
}
```

3. Modificamos el llamado para que la función en **Program** para que solo reciba la instancia del objeto segun el tipo de reporte a generar asi: 
```csharp
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

De esta forma si queremos adicionar un nuevo formato como PDF, solo adicionamos una nueva clase **ReportPDF** que implemente la creación del reporte y pasamos una instacia de esta a la función **Generate** de la clase **ReportGenerator**, sin tener que modificarla.