namespace SOLID.Principles.Define;

public class Constants
{
    public static readonly string DatabaseFileName = @"..\..\..\..\SOLID.Database\SOLIDDb.sqlite3";
    public static readonly string ReportsPath = @"..\..\..\..\Reports\";
    public static readonly string SelectEmployees = "SELECT Id, FirstName, LastName, HireDate, Email, Phone FROM Employees";
    public static readonly string InsertEmployee = "INSERT INTO Employees (FirstName, LastName, HireDate, Email, Phone) VALUES (?, ?, ?, ?, ?)";
    public static readonly string UpdateEmployees = "UPDATE Employees SET HireDate = datetime('now') WHERE Id = 1";
}