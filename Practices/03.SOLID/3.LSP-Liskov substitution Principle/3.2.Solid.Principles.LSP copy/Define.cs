namespace Solid.Principles.Define
{
  public class Constants
  {
    public static readonly string DatabaseFileName = @"..\..\..\..\..\SOLIDDatabase\SOLIDDb.sqlite3";
    public static readonly string ReportsPath = @"..\..\..\..\..\Reports\";
    public static readonly string SelectEmployees = "SELECT Id, FirstName, LastName, HireDate, Email, Phone FROM Employees";
    public static readonly string InsertEmployee = "INSERT INTO Employees (FirstName, LastName, HireDate, Email, Phone) VALUES (?, ?, ?, ?, ?)";
    public static readonly string UpdateEmployees = "UPDATE Employees SET HireDate = datetime('now') WHERE Id = 1";
    public static readonly string SelectProjects = "SELECT Id, Name, Description, Type, DepartmentName, StartDate, Budget, ContractorName FROM Projects";
  }

  public enum ReportType
  {
    CSV='1',
    XML='2'
  }

  public enum ProjectType
  {
    Internal='I',
    External='E'
  }
}
