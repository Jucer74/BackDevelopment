namespace Solid.Principles
{
  using System.Collections.Generic;
  using Define;
  using Dto;

  public interface IReportGenerator
  {
    void Generate(string reportFilename, List<EmployeeDto> employees);
  }
}
