namespace Solid.Principles
{
  using System;
  using System.Collections.Generic;
  using System.Data;
  using System.Data.SQLite;
  using System.IO;
  using Define;
  using Dto;
  using SOLID.Common.SQLData;

  public class ApplicationData
  {
    private readonly SqlDatabase sqlDatabase;

    public ApplicationData()
    {
      sqlDatabase = new SqlDatabase(GetConnectionString());
    }

    /// <summary>
    /// This method used to insert into employee table
    /// </summary>
    /// <param name="empDto">Employee object</param>
    /// <returns>Successfully inserted or not</returns>
    public bool InsertEmployee(EmployeeDto empDto)
    {
      try
      {
        sqlDatabase.CreateAndOpenConnection();

        var command = sqlDatabase.CreateCommand(Constants.InsertEmployee);

        sqlDatabase.AddInParameter(command, "FirstName", empDto.FirstName, 50, DbType.String);
        sqlDatabase.AddInParameter(command, "LastName", empDto.LastName, 50, DbType.String);
        sqlDatabase.AddInParameter(command, "HireData", empDto.HireDate, 50, DbType.DateTime);
        sqlDatabase.AddInParameter(command, "Email", empDto.Email, 50, DbType.String);
        sqlDatabase.AddInParameter(command, "Phone", empDto.Phone, 50, DbType.String);

        var rowsAffects = sqlDatabase.ExecuteNonQuery(command);

        return rowsAffects > 0;
      }
      finally
      {
        sqlDatabase.CloseConnection();
      }
    }

    /// <summary>
    /// Get the Employees from table
    /// </summary>
    /// <returns>a employees Dto List</returns>
    public List<EmployeeDto> GetEmployees()
    {
      try
      {
        sqlDatabase.CreateAndOpenConnection();

        var command = sqlDatabase.CreateCommand(Constants.SelectEmployees);
        var dataReader = sqlDatabase.ExecuteReader(command);

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
      finally
      {
        sqlDatabase.CloseConnection();
      }
    }

    /// <summary>
    /// Method to generate report
    /// </summary>
    public void GenerateReport(string reportFilename)
    {
      var fullReportFileName = $"{Constants.ReportsPath}{reportFilename}";
      var sw = new StreamWriter(fullReportFileName);

      var employees = GetEmployees();

      foreach (var emp in employees)
      {
        sw.WriteLine($"{emp.Id},{emp.FirstName},{emp.LastName},{emp.HireDate},{emp.Email},{emp.Phone}");
      }

      sw.Flush();
      sw.Close();
    }

    /// <summary>
    /// Build the Connection String to the database
    /// </summary>
    /// <returns>Connection String</returns>
    private static string GetConnectionString()
    {
      var sqlConnectionStringBuilder = new SQLiteConnectionStringBuilder
      {
        DataSource = Constants.DatabaseFileName
      };

      return sqlConnectionStringBuilder.ToString();
    }
  }
}
