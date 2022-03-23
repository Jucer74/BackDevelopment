namespace Solid.Principles
{
  using Solid.Principles.Dto;
  using System;
  public class ExternalProject:Project
  {
    public void ShowBudgetDetails(ProjectDto projectDto)
    {
      base.ShowDetails(projectDto);
      Console.WriteLine("External Details");
      Console.WriteLine("----------------");
      Console.WriteLine($"Budget : {projectDto.Budget}\t\t\tContractor Name : {projectDto.ContractorName}\n");
    }
  }
}
