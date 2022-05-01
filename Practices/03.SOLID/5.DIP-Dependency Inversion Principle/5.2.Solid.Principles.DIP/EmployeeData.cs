namespace Solid.Principles
{
  using System;
  using System.Collections.Generic;
  using System.Data;
  using System.Data.SQLite;
  using Define;
  using Dto;
  using SOLID.Common.SQLData.Interface;

  public class EmployeeData: IEmployeeData
  {
    private readonly ISqlDatabase _sqlDatabase;

    public EmployeeData(ISqlDatabase sqlDatabase)
    {
      _sqlDatabase = sqlDatabase;
    }

    /// <summary>
    /// This method used to insert into employee table
    /// </summary>
    /// <param name="empDto">Employee object</param>
    /// <returns>Successfully inserted or not</returns>
    public bool InsertEmployee(EmployeeDto empDto)
    {
      var command = _sqlDatabase.CreateCommand(Constants.InsertEmployee);

      _sqlDatabase.AddInParameter(command, "FirstName", empDto.FirstName, 50, DbType.String);
      _sqlDatabase.AddInParameter(command, "LastName", empDto.LastName, 50, DbType.String);
      _sqlDatabase.AddInParameter(command, "HireData", empDto.HireDate, 50, DbType.DateTime);
      _sqlDatabase.AddInParameter(command, "Email", empDto.Email, 50, DbType.String);
      _sqlDatabase.AddInParameter(command, "Phone", empDto.Phone, 50, DbType.String);

      var rowsAffects = _sqlDatabase.ExecuteNonQuery(command);

      return rowsAffects > 0;
    }

    /// <summary>
    /// Get the Employees from table
    /// </summary>
    /// <returns>a employees Dto List</returns>
    public List<EmployeeDto> GetEmployees()
    {
      var command = _sqlDatabase.CreateCommand(Constants.SelectEmployees);
      var dataReader = _sqlDatabase.ExecuteReader(command);

      var employees = new List<EmployeeDto>();

      while (dataReader.Read())
      {
        var emp = new EmployeeDto
        {
          Id = Convert.ToInt32(dataReader["Id"].ToString()),
          FirstName = dataReader["FirstName"].ToString(),
          LastName = dataReader["LastName"].ToString(),
          HireDate = Convert.ToDateTime(dataReader["HireDate"].ToString()),
          Email = dataReader["Email"].ToString(),
          Phone = dataReader["Phone"].ToString()
        };

        employees.Add(emp);
      }

      return employees;
    }
  }
}
