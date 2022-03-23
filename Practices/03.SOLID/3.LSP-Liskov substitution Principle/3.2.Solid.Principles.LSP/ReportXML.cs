namespace Solid.Principles
{
  using System.Collections.Generic;
  using System.IO;
  using System.Xml.Serialization;
  using Define;
  using Dto;

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
}
