namespace Solid.Principles
{
  using Solid.Principles.Dto;
  using System;
  public class ExternalProject:Project, IInternalDetails, IExternalDetails
  {
    public override void ShowDetails(ProjectDto projectDto)
    {
      base.ShowDetails(projectDto);
      ShowInternal(projectDto);
      ShowExternal(projectDto);
    }

    public void ShowInternal(ProjectDto projectDto)
    {
      Console.WriteLine("Internal Details");
      Console.WriteLine("----------------");
      Console.WriteLine($"Start Date : {projectDto.StartDate}\t\tDepartment Name : {projectDto.DepartmentName}\n");
    }

    public void ShowExternal(ProjectDto projectDto)
    {
      Console.WriteLine("External Details");
      Console.WriteLine("----------------");
      Console.WriteLine($"Budget : {projectDto.Budget}\t\t\tContractor Name : {projectDto.ContractorName}\n");
    }

  }
}
