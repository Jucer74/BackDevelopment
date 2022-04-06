namespace Solid.Principles
{
  using System.Collections.Generic;
  using System.IO;
  using System.Xml.Serialization;
  using Define;
  using Dto;

  public class ReportXML : IReportGenerator
  {
    public void Generate(string reportFilename, List<EmployeeData> employees)
    {
      var fullReportFileName = $"{Constants.ReportsPath}{reportFilename}.xml";
      var sw = new StreamWriter(fullReportFileName);
      XmlSerializer xml = new XmlSerializer(typeof(List<EmployeeData>));
      xml.Serialize(sw, employees);
      sw.Flush();
      sw.Close();
    }
  }
}