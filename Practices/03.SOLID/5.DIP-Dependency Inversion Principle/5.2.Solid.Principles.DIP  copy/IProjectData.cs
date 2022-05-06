namespace Solid.Principles
{
  using Dto;
  using System.Collections.Generic;

  public interface IProjectData
  {
    /// <summary>
    /// Get the Pjoects from table
    /// </summary>
    /// <returns>Projects Dto List</returns>
    List<ProjectDto> GetProjects();
  }
}
