namespace Solid.Principles
{
  using System;
  using System.Collections.Generic;
  using Define;
  using Dto;
  using SOLID.Common.SQLData.Interface;
  public class ProjectData: IProjectData
  {

    private readonly ISqlDatabase _sqlDatabase;

    public ProjectData(ISqlDatabase sqlDatabase)
    {
      _sqlDatabase = sqlDatabase;
    }

    /// <summary>
    /// Get the Pjoects from table
    /// </summary>
    /// <returns>Projects Dto List</returns>
    public List<ProjectDto> GetProjects()
    {
      var command = _sqlDatabase.CreateCommand(Constants.SelectProjects);
      var dataReader = _sqlDatabase.ExecuteReader(command);

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
  }
}
