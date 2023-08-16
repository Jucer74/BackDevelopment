using SOLID.Principles.Define;
using SOLID.Principles.Dto;

namespace SOLID.Principles
{
    public enum ReportType
    {
        CSV = '1',
        XML = '2'
    }

    public interface IReportGenerator
    {
        void Generate(string reportFilename, List<EmployeeDto> employees);
    }
}
