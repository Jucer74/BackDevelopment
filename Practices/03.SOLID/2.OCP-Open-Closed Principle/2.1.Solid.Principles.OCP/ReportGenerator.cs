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
