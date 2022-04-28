namespace Bank
{
  using Bank.Define;
  using Bank.Dto;
  using System;

  public class Account
  {
    public virtual void ShowDetails(AccountDto projectDto)
    {
      ProjectType projectType = projectDto.Type == (char)ProjectType.Internal? ProjectType.Internal: ProjectType.External;

      Console.WriteLine("{0}", "".PadRight(100, '-'));
      Console.WriteLine("Project Details");
      Console.WriteLine("---------------");
      Console.WriteLine($"Id : {projectDto.Id}\t\t\tType : {projectDto.Type}-{projectType.ToString()}\n");
      Console.WriteLine($"Name : {projectDto.Name}\n");
      Console.WriteLine($"Description :\n{projectDto.Description}\n");
    }
  }
}
