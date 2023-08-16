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