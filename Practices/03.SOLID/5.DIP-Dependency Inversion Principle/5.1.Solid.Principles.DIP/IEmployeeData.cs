namespace Solid.Principles
{
  using Dto;
  using System.Collections.Generic;

  public interface IEmployeeData
  {
    /// <summary>
    /// This method used to insert into employee table
    /// </summary>
    /// <param name="empDto">Employee object</param>
    /// <returns>Successfully inserted or not</returns>
    bool InsertEmployee(EmployeeDto empDto);

    /// <summary>
    /// Get the Employees from table
    /// </summary>
    /// <returns>a employees Dto List</returns>
    List<EmployeeDto> GetEmployees();
  }
}
