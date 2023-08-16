using SOLID.Principles.Dto;

namespace SOLID.Principles;

public interface IProjectData
{
    /// <summary>
    /// Get the Pjoects from table
    /// </summary>
    /// <returns>Projects Dto List</returns>
    List<ProjectDto> GetProjects();
}