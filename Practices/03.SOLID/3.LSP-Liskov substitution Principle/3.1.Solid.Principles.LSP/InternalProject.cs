namespace Solid.Principles
{
  using Solid.Principles.Dto;
  using System;

  public class InternalProject: Project
  {
    public override void ShowDetails(ProjectDto projectDto)
    {
      base.ShowDetails(projectDto);
      Console.WriteLine("Internal Details");
      Console.WriteLine("----------------");
      Console.WriteLine($"Start Date : {projectDto.StartDate}\t\tDepartment Name : {projectDto.DepartmentName}\n");
    }
  }
}
