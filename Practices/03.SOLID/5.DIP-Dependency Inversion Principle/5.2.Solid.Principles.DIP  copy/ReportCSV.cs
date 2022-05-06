namespace Solid.Principles
{
  using System;
  using System.Collections.Generic;
  using System.IO;
  using Define;
  using Dto;

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
}
