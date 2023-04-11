namespace SOLID.Common.SQLData.Tests
{
  using System;
  using System.Collections.Generic;
  using System.Data;
  using System.Data.SQLite;
  using Data;
  using Define;
  using global::SqlDatabase.Test;
  using Xunit;

  [TestCaseOrderer("SqlDatabase.Test.PriorityOrderer", "SqlDatabase.Test")]
  public class SqlDatabaseTests
  {
    private string GetConnectionString()
    {
      var sqlConnectionStringBuilder = new SQLiteConnectionStringBuilder
      {
        DataSource = Constants.DatabaseFileName
      };

      return sqlConnectionStringBuilder.ToString();
    }

    [Fact, TestPriority(1)]
    public void CreateConnectionTest()
    {
      // Arrange
      var cnnStr = GetConnectionString();

      // Act
      var sqlDatabase = new SqlDatabase(cnnStr);
      var connection = sqlDatabase.CreateConnection();

      // Assert
      Assert.NotNull(connection);
      Assert.Equal("SQLiteConnection", connection.GetType().Name);
    }

    [Fact, TestPriority(2)]
    public void CreateConnectionWithConnectionStringTest()
    {
      // Arrange
      var cnnStr = GetConnectionString();

      // Act
      var sqlDatabase = new SqlDatabase();
      var connection = sqlDatabase.CreateConnection(cnnStr);

      // Assert
      Assert.NotNull(connection);
      Assert.Equal("SQLiteConnection", connection.GetType().Name);
    }

    [Fact, TestPriority(3)]
    public void CreateAndOpenConnectionTest()
    {
      // Arrange
      var cnnStr = GetConnectionString();

      // Act
      var sqlDatabase = new SqlDatabase
      {
        ConnectionString = cnnStr
      };

      var connection = sqlDatabase.CreateAndOpenConnection();

      // Assert
      Assert.NotNull(connection);
      Assert.Equal("SQLiteConnection", connection.GetType().Name);
      Assert.Equal(ConnectionState.Open, connection.State);
    }

    [Fact, TestPriority(4)]
    public void CreateAndOpenConnectionWithConnectionStringTest()
    {
      // Arrange
      var cnnStr = GetConnectionString();

      // Act
      var sqlDatabase = new SqlDatabase();
      var connection = sqlDatabase.CreateAndOpenConnection(cnnStr);

      // Assert
      Assert.NotNull(connection);
      Assert.Equal("SQLiteConnection", connection.GetType().Name);
      Assert.Equal(ConnectionState.Open, connection.State);
    }

    [Fact, TestPriority(5)]
    public void OpenConnectionTest()
    {
      // Arrange
      var cnnStr = GetConnectionString();
      var sqlDatabase = new SqlDatabase(cnnStr);
      var connection = sqlDatabase.CreateConnection();

      // Act
      sqlDatabase.OpenConnection();

      // Assert
      Assert.NotNull(connection);
      Assert.Equal("SQLiteConnection", connection.GetType().Name);
      Assert.Equal(ConnectionState.Open, connection.State);
    }

    [Fact, TestPriority(6)]
    public void OpenConnectionWithConnectionTest()
    {
      // Arrange
      var cnnStr = GetConnectionString();
      var sqlDatabase = new SqlDatabase(cnnStr);
      var connection = sqlDatabase.CreateConnection();

      // Act
      sqlDatabase.OpenConnection(connection);

      // Assert
      Assert.NotNull(connection);
      Assert.Equal("SQLiteConnection", connection.GetType().Name);
      Assert.Equal(ConnectionState.Open, connection.State);
    }

    [Fact, TestPriority(7)]
    public void CloseConnectionTest()
    {
      // Arrange
      var cnnStr = GetConnectionString();
      var sqlDatabase = new SqlDatabase(cnnStr);
      var connection = sqlDatabase.CreateConnection();
      sqlDatabase.OpenConnection(connection);

      // Act
      sqlDatabase.CloseConnection();

      // Assert
      Assert.NotNull(connection);
      Assert.Equal(ConnectionState.Closed, connection.State);
    }

    [Fact, TestPriority(8)]
    public void CloseConnectionWithConnectionTest()
    {
      // Arrange
      var cnnStr = GetConnectionString();
      var sqlDatabase = new SqlDatabase(cnnStr);
      var connection = sqlDatabase.CreateConnection();
      sqlDatabase.OpenConnection(connection);

      // Act
      sqlDatabase.CloseConnection(connection);

      // Assert
      Assert.NotNull(connection);
      Assert.Equal(ConnectionState.Closed, connection.State);
    }

    [Fact, TestPriority(9)]
    public void IsOpenConnectionTest()
    {
      // Arrange
      var cnnStr = GetConnectionString();
      var sqlDatabase = new SqlDatabase(cnnStr);
      var connection = sqlDatabase.CreateConnection();
      sqlDatabase.OpenConnection(connection);

      // Act
      var isOpenConnection = sqlDatabase.IsOpenConnection();

      // Assert
      Assert.NotNull(connection);
      Assert.Equal("SQLiteConnection", connection.GetType().Name);
      Assert.True(isOpenConnection);
    }

    [Fact, TestPriority(10)]
    public void IsOpenConnectionWithConnectionTest()
    {
      // Arrange
      var cnnStr = GetConnectionString();
      var sqlDatabase = new SqlDatabase(cnnStr);
      var connection = sqlDatabase.CreateConnection();
      sqlDatabase.OpenConnection(connection);

      // Act
      var isOpenConnection = sqlDatabase.IsOpenConnection(connection);

      // Assert
      Assert.NotNull(connection);
      Assert.Equal("SQLiteConnection", connection.GetType().Name);
      Assert.True(isOpenConnection);
    }

    [Fact, TestPriority(11)]
    public void CreateCommandTest()
    {
      // Arrange
      var cnnStr = GetConnectionString();
      var sqlDatabase = new SqlDatabase(cnnStr);
      var connection = sqlDatabase.CreateConnection();
      sqlDatabase.OpenConnection(connection);

      // Act
      var command = sqlDatabase.CreateCommand();

      // Assert
      Assert.NotNull(command);
      Assert.Equal("SQLiteCommand", command.GetType().Name);
    }

    [Fact, TestPriority(12)]
    public void CreateCommandTestWithConnection()
    {
      // Arrange
      var cnnStr = GetConnectionString();
      var sqlDatabase = new SqlDatabase(cnnStr);
      var connection = sqlDatabase.CreateConnection();
      sqlDatabase.OpenConnection(connection);

      // Act
      var command = sqlDatabase.CreateCommand(connection);

      // Assert
      Assert.NotNull(command);
      Assert.Equal("SQLiteCommand", command.GetType().Name);
    }

    [Fact, TestPriority(13)]
    public void CreateCommandTestWithCommandText()
    {
      // Arrange
      var cnnStr = GetConnectionString();
      var sqlDatabase = new SqlDatabase(cnnStr);
      sqlDatabase.CreateConnection();
      sqlDatabase.OpenConnection();

      // Act
      var command = sqlDatabase.CreateCommand(Constants.UpdateEmployees);

      // Assert
      Assert.NotNull(command);
      Assert.Equal("SQLiteCommand", command.GetType().Name);
    }

    [Fact, TestPriority(14)]
    public void CreateCommandTestFullParameters()
    {
      // Arrange
      var cnnStr = GetConnectionString();
      var sqlDatabase = new SqlDatabase(cnnStr);
      var connection = sqlDatabase.CreateConnection();
      sqlDatabase.OpenConnection(connection);

      // Act
      var command = sqlDatabase.CreateCommand(connection, CommandType.Text, Constants.UpdateEmployees);

      // Assert
      Assert.NotNull(command);
      Assert.Equal("SQLiteCommand", command.GetType().Name);
    }

    [Fact, TestPriority(15)]
    public void ExecuteNonQueryWithCommandTest()
    {
      // Arrange
      var cnnStr = GetConnectionString();
      var sqlDatabase = new SqlDatabase(cnnStr);
      sqlDatabase.CreateAndOpenConnection();
      var command = sqlDatabase.CreateCommand(Constants.UpdateEmployees);

      // Act
      var rowsAffects = sqlDatabase.ExecuteNonQuery(command);

      // Assert
      Assert.NotNull(command);
      Assert.Equal(1, rowsAffects);
    }

    [Fact, TestPriority(16)]
    public void ExecuteNonQueryWithQueryTest()
    {
      // Arrange
      var cnnStr = GetConnectionString();
      var sqlDatabase = new SqlDatabase(cnnStr);
      sqlDatabase.CreateAndOpenConnection();

      // Act
      var rowsAffects = sqlDatabase.ExecuteNonQuery(Constants.UpdateEmployees);

      // Assert
      Assert.Equal(1, rowsAffects);
    }

    [Fact, TestPriority(17)]
    public void ExecuteNonQueryWithFullParametersTest()
    {
      // Arrange
      var cnnStr = GetConnectionString();
      var sqlDatabase = new SqlDatabase(cnnStr);
      var connection = sqlDatabase.CreateAndOpenConnection();

      // Act
      var rowsAffects = sqlDatabase.ExecuteNonQuery(connection, CommandType.Text, Constants.UpdateEmployees);

      // Assert
      Assert.Equal(1, rowsAffects);
    }

    [Fact, TestPriority(18)]
    public void ExecuteReaderWithCommandTest()
    {
      // Arrange
      var cnnStr = GetConnectionString();
      var sqlDatabase = new SqlDatabase(cnnStr);
      sqlDatabase.CreateAndOpenConnection();
      var command = sqlDatabase.CreateCommand(Constants.SelectEmployees);

      // Act
      var dataReader = sqlDatabase.ExecuteReader(command);

      // Assert
      Assert.NotNull(dataReader);
      Assert.Equal("SQLiteDataReader", dataReader.GetType().Name);
      Assert.Equal(6, dataReader.FieldCount);
    }

    [Fact, TestPriority(19)]
    public void ExecuteReaderWithQueryTest()
    {
      // Arrange
      var cnnStr = GetConnectionString();
      var sqlDatabase = new SqlDatabase(cnnStr);
      sqlDatabase.CreateAndOpenConnection();

      // Act
      var dataReader = sqlDatabase.ExecuteReader(Constants.SelectEmployees);

      // Assert
      Assert.NotNull(dataReader);
      Assert.Equal("SQLiteDataReader", dataReader.GetType().Name);
      Assert.Equal(6, dataReader.FieldCount);
    }

    [Fact, TestPriority(20)]
    public void ExecuteReaderWithFullParametersTest()
    {
      // Arrange
      var cnnStr = GetConnectionString();
      var sqlDatabase = new SqlDatabase(cnnStr);
      var connection = sqlDatabase.CreateAndOpenConnection();

      // Act
      var dataReader = sqlDatabase.ExecuteReader(connection, CommandType.Text, Constants.SelectEmployees);

      // Assert
      Assert.NotNull(dataReader);
      Assert.Equal("SQLiteDataReader", dataReader.GetType().Name);
      Assert.Equal(6, dataReader.FieldCount);
    }

    [Fact, TestPriority(21)]
    public void ExecuteReaderTest()
    {
      // Arrange
      var cnnStr = GetConnectionString();
      var sqlDatabase = new SqlDatabase(cnnStr);
      sqlDatabase.CreateAndOpenConnection();
      var command = sqlDatabase.CreateCommand(Constants.SelectEmployees);

      // Act
      var dataReader = sqlDatabase.ExecuteReader(command);

      List<Employee> employees = new List<Employee>();

      while (dataReader.Read())
      {
        Employee emp = new Employee
        {
          Id = Convert.ToInt32(dataReader["Id"].ToString()),
          FirstName = dataReader["FirstName"].ToString(),
          LastName = dataReader["LastName"].ToString(),
          HireDate = Convert.ToDateTime(dataReader["HireDate"].ToString()),
          Email = dataReader["Email"].ToString(),
          Phone = dataReader["Phone"].ToString()
        };

        employees.Add(emp);
      }

      // Assert
      Assert.NotNull(dataReader);
      Assert.Equal(3, employees.Count);
    }
  }
}
