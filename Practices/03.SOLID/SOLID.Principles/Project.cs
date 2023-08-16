using SOLID.Principles.Dto;
using SOLID.Principles.Define;

namespace SOLID.Principles;

public class Project
{
    public virtual void ShowDetails(ProjectDto projectDto)
    {
        ProjectType projectType = projectDto.Type == (char)ProjectType.Internal ? ProjectType.Internal : ProjectType.External;

        Console.WriteLine("{0}", "".PadRight(50, '-'));
        Console.WriteLine("Project Details");
        Console.WriteLine("---------------");
        Console.WriteLine($"Id : {projectDto.Id}\t\t\tType : {projectDto.Type}-{projectType.ToString()}\n");
        Console.WriteLine($"Name : {projectDto.Name}\n");
        Console.WriteLine($"Description :\n{projectDto.Description}\n");
    }
}