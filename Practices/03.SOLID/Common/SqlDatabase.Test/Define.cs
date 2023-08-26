namespace SOLID.Common.SQLData.Tests.Define
{
  public class Constants
  {
    public static readonly string DatabaseFileName = @"..\..\..\DatabaseTest\TestDb.sqlite3";
    public static readonly string SelectEmployees = "SELECT * FROM Employees";
    public static readonly string UpdateEmployees = "UPDATE Employees SET HireDate = datetime('now') WHERE Id = 1";
  }
}
