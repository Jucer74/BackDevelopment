namespace Solid.Principles
{
  using Define;
  using Dto;
  using System;
  using System.Globalization;
  using SOLID.Common.SQLData;
  using SOLID.Common.SQLData.Interface;
  using System.Data.SQLite;

  internal class Program
  {
    private static readonly ISqlDatabase sqlDatabase = new SqlDatabase(GetConnectionString());
    private static readonly EmployeeData employeeData = new EmployeeData(sqlDatabase);
    private static readonly ProjectData projectData = new ProjectData(sqlDatabase);

    private static void Main(string[] args)
    {
      try
      {
        Console.WriteLine("Starting...");
        sqlDatabase.CreateAndOpenConnection();
        Menu();
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
      }
      finally
      {
        sqlDatabase.CloseConnection();
      }
    }

    private static void Menu()
    {
      var option = ' ';

      while (option != '0')
      {
        Console.Clear();
        Console.WriteLine("     S.O.L.I.D. Principles    ");
        Console.WriteLine("------------------------------");
        Console.WriteLine("1. Insert new Employee");
        Console.WriteLine("2. Get Employee List");
        Console.WriteLine("3. Generate Employees Report");
        Console.WriteLine("4. Show Projects");
        Console.WriteLine("0. Exit");
        Console.WriteLine("Select Option:");
        option = Console.ReadKey().KeyChar;
        Console.WriteLine();

        switch (option)
        {
          case '0':
            Console.WriteLine("Exit");
            break;

          case '1':
            InsertEmployee();
            break;

          case '2':
            GetEmployees();
            break;

          case '3':
            GenerateReport();
            break;

          case '4':
            ShowProjects();
            break;

          default:
            Console.WriteLine("Invalid Option");
            break;
        }

        ;

        Console.WriteLine("\nPress any key to continue... ");
        Console.ReadKey();
      }
    }

    private static void ShowProjects()
    {
      Console.Clear();
      Console.WriteLine("Show Projects");
      Console.WriteLine("-------------");
      Console.WriteLine();

      var projectList = projectData.GetProjects();

      Project project=null;

      foreach (var prj in projectList)
      {
        if(prj.Type == (char)ProjectType.Internal)
        {
          project = new InternalProject();
        }
        if (prj.Type == (char)ProjectType.External)
        {
          project = new ExternalProject();
        }

        project.ShowDetails(prj);
      }

      Console.WriteLine();
    }

    private static void GetEmployees()
    {
      Console.Clear();
      Console.WriteLine("Employee List");
      Console.WriteLine("-------------");
      Console.WriteLine();

      var employees = employeeData.GetEmployees();

      foreach (var emp in employees)
      {
        DisplayEmployee(emp);
      }

      Console.WriteLine("\n({0}) Rows Retrieved", employees.Count);
      Console.WriteLine();
    }

    private static void DisplayEmployee(EmployeeDto emp)
    {
      Console.WriteLine($"{emp.Id},{emp.FirstName},{emp.LastName},{emp.HireDate},{emp.Email},{emp.Phone}");
    }

    private static void InsertEmployee()
    {
      Console.Clear();
      Console.WriteLine("Insert new Employee");
      Console.WriteLine("-------------------");
      Console.WriteLine();

      var employeeDto = CreateEmployeDto();

      if (employeeData.InsertEmployee(employeeDto))
      {
        Console.WriteLine("\nThe Employee was insert Successfully\n");
      }
      else
      {
        Console.WriteLine("\nThe Employee was not inserted\n");
      }
    }

    private static EmployeeDto CreateEmployeDto()
    {
      Console.Write("First Name             : ");
      var firstName = Console.ReadLine();
      Console.Write("Last Name              : ");
      var lastName = Console.ReadLine();
      Console.Write("Hire Date (yyyy-MM-dd) : ");
      var hireDateString = Console.ReadLine();
      Console.Write("Email                  : ");
      var email = Console.ReadLine();
      Console.Write("Phone                  : ");
      var phone = Console.ReadLine();

      if (!DateTime.TryParseExact(hireDateString, "yyyy-MM-dd", null, DateTimeStyles.None, out var hireDate))
      {
        hireDate = DateTime.Now;
      }

      var employeeDto = new EmployeeDto
      {
        FirstName = firstName,
        LastName = lastName,
        HireDate = hireDate,
        Email = email,
        Phone = phone
      };

      return employeeDto;
    }

    private static void GenerateReport()
    {
      Console.Clear();
      Console.WriteLine("Generate Report");
      Console.WriteLine("---------------");
      Console.WriteLine();

      Console.Write("Report File Name         : ");
      var reportFileName = Console.ReadLine();
      Console.Write("Report Type (1-CSV 2-XML): ");
      var reportTypeOption = ' ';
      while (reportTypeOption != (char)ReportType.CSV && reportTypeOption != (char)ReportType.XML)
      {
        reportTypeOption = Console.ReadKey().KeyChar;
      }

      Console.WriteLine();

      var employees = employeeData.GetEmployees();

      IReportGenerator reportGenerator = null;
      switch ((ReportType)reportTypeOption)
      {
        case ReportType.CSV:
          reportGenerator = new ReportCSV();
          break;

        case ReportType.XML:
          reportGenerator = new ReportXML();
          break;
      }

      ;

      reportGenerator.Generate(reportFileName, employees);

      Console.WriteLine("the report was generated.");
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