namespace Solid.Principles
{
  using Solid.Principles.Dto;
  using System;

  public class InternalProject: Project, IInternalDetails
  {
    public override void ShowDetails(ProjectDto projectDto)
    {
      base.ShowDetails(projectDto);
      ShowInternal(projectDto);
    }

    public void ShowInternal(ProjectDto projectDto)
    {
      Console.WriteLine("Internal Details");
      Console.WriteLine("----------------");
      Console.WriteLine($"Start Date : {projectDto.StartDate}\t\tDepartment Name : {projectDto.DepartmentName}\n");
    }
  }
}
