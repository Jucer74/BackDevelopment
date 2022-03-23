namespace Solid.Principles
{
  using System;
  using System.Collections.Generic;
  using System.Data.SQLite;
  using Define;
  using Dto;
  using SOLID.Common.SQLData;
  public class ProjectData: IProjectData
  {

    private readonly SqlDatabase sqlDatabase;

    public ProjectData()
    {
      sqlDatabase = new SqlDatabase(GetConnectionString());
    }

    /// <summary>
    /// Get the Pjoects from table
    /// </summary>
    /// <returns>Projects Dto List</returns>
    public List<ProjectDto> GetProjects()
    {
      try
      {
        sqlDatabase.CreateAndOpenConnection();

        var command = sqlDatabase.CreateCommand(Constants.SelectProjects);
        var dataReader = sqlDatabase.ExecuteReader(command);

        var projects = new List<ProjectDto>();

        while (dataReader.Read())
        {
          var prj = new ProjectDto
          {
            Id = Convert.ToInt32(dataReader["Id"].ToString()),
            Name = dataReader["Name"].ToString(),
            Description = dataReader["Description"].ToString(),
            Type = dataReader["Type"].ToString()[0],
            DepartmentName = dataReader["DepartmentName"].ToString(),
            StartDate = Convert.ToDateTime(dataReader["StartDate"].ToString()),
            Budget = Convert.ToDecimal(dataReader["Budget"].ToString()),
            ContractorName = dataReader["ContractorName"].ToString()
          };

          projects.Add(prj);
        }

        return projects;
      }
      finally
      {
        sqlDatabase.CloseConnection();
      }
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
