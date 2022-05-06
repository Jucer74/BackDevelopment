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
    private static void GenerateReport()
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

  IReportGenerator reportGenerator = null;
  switch ((ReportType)reportTypeOption)
  {
    case ReportType.CSV:
      reportGenerator = new ReportCSV();
      break;
    case ReportType.XML:
      reportGenerator = new ReportXML();
      break;

  };

  reportGenerator.Generate(reportFileName, employees);

  Console.WriteLine("the report was generated.");
}

  }
}
