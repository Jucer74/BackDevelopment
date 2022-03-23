

namespace SOLID.Common.SQLData.Interface
{
  using System;
  using System.Data;

  public interface ISqlDatabase
  {
    // Connection Methods
    #region Connection Methods
    /// <summary>
    /// Create database connection.
    /// Needs the Connection String assigned.
    /// </summary>
    /// <returns>Database Connection</returns>
    IDbConnection CreateConnection();
  
    /// <summary>
    /// Create database connection.
    /// Ignore the Connection String assigned and use the parameter
    /// </summary>
    /// <param name="connectionString">Connection String</param>
    /// <returns>Database Connection</returns>
    IDbConnection CreateConnection(string connectionString);

    /// <summary>
    /// Create and Open Connection
    /// Needs the Connection String assigned.
    /// </summary>
    /// <returns>Database Connection opened</returns>
    IDbConnection CreateAndOpenConnection();

    /// <summary>
    /// Create and Open Connection
    /// Ignore the Connection String assigned and use the parameter
    /// </summary>
    /// <param name="connectionString">Connection String</param>
    /// <returns>Database Connection opened</returns>
    IDbConnection CreateAndOpenConnection(string connectionString);

    /// <summary>
    /// Open the Database Connection
    /// Uses the Property Connection
    /// </summary>
    void OpenConnection();

    /// <summary>
    /// Open the Database Connection
    /// </summary>
    /// <param name="connection">Current Connection</param>
    void OpenConnection(IDbConnection connection);

    /// <summary>
    /// Close the database Connection
    /// Uses the Property Connection
    /// </summary>
    void CloseConnection();

    /// <summary>
    /// Close the database Connection
    /// </summary>
    /// <param name="connection">Connection to close</param>
    void CloseConnection(IDbConnection connection);

    /// <summary>
    /// Check is the connection is Open
    /// Uses the Property Connection
    /// </summary>
    /// <returns>return <see langword="true"/> if is open, otherwise return <see langword="false"/>.</returns>
    bool IsOpenConnection();

    /// <summary>
    /// Check is the connection is Open
    /// </summary>
    /// <param name="connection">Connection to check</param>
    /// <returns>return <see langword="true"/> if is open, otherwise return <see langword="false"/>.</returns>
    bool IsOpenConnection(IDbConnection connection);
    #endregion Connection Methods

    // Command Methods
    #region Command Methods
    /// <summary>
    /// Create and return a command in the curent connection
    /// Uses the Property Connection
    /// </summary>
    /// <returns>Command Object</returns>
    IDbCommand CreateCommand();

    /// <summary>
    /// Create and return a command in the connection
    /// </summary>
    /// <param name="connection">Active connection</param>
    /// <returns>Command Object</returns>
    IDbCommand CreateCommand(IDbConnection connection);

    /// <summary>
    /// Create and return a command in the curent connection
    /// </summary>
    /// <param name="commandText">Command text to execute</param>
    /// <returns>Command Object</returns>
    IDbCommand CreateCommand(string commandText);

    /// <summary>
    /// Create and return a command in the curent connection
    /// </summary>
    /// <param name="connection">Active connection</param>
    /// <param name="commandType">Comand Type</param>
    /// <param name="commandText">Command text to execute</param>
    /// <returns>Command Object</returns>
    IDbCommand CreateCommand(IDbConnection connection, CommandType commandType, string commandText);

    #endregion Command Methods

    // ExecuteNonQuery Methods
    #region ExecuteNonQuery Methods
    /// <summary>
    /// Execute the comnand and return the rows affects
    /// </summary>
    /// <param name="command">Comand</param>
    /// <returns>Rows affects</returns>
    int ExecuteNonQuery(IDbCommand command);

    /// <summary>
    /// Create a Command with the query and returns the rows affects
    /// </summary>
    /// <param name="query">Query text to execute</param>
    /// <returns>Rows affects number</returns>
    int ExecuteNonQuery(string query);

    /// <summary>
    /// Create a Command with the query and returns the rows affects
    /// </summary>
    /// <param name="connection">ACtive Connection</param>
    /// <param name="commandType">Command Type</param>
    /// <param name="query">Query to Execute</param>
    /// <returns></returns>
    int ExecuteNonQuery(IDbConnection connection, CommandType commandType, string query);
    #endregion ExecuteNonQuery Methods

    // ExecuteReader Methods
    #region ExecuteReader Methods
    /// <summary>
    /// Execute a command and return an <see cref="IDataReader"/> datareader
    /// Uses the Property Connection
    /// </summary>
    /// <param name="command">Command to Execute</param>
    /// <returns>A DataReader</returns>
    IDataReader ExecuteReader(IDbCommand command);

    /// <summary>
    /// Execute a command and return an <see cref="IDataReader"/> datareader
    /// Uses the Property Connection
    /// </summary>
    /// <param name="query">Query text to execute</param>
    /// <returns>Un DataReader</returns>
    IDataReader ExecuteReader(string query);

    /// <summary>
    /// Execute a command and return an <see cref="IDataReader"/> datareader
    /// </summary>
    /// <param name="connection">Active Connection</param>
    /// <param name="query">Query text to execute</param>
    /// <returns>Un DataReader</returns>
    IDataReader ExecuteReader(IDbConnection connection, CommandType commandType, string query);
    #endregion ExecuteReader Methods 

    // ExecuteDataSet Methods
    #region ExecuteDataSet Methods
    /// <summary>
    /// Return a DataSet with the command result
    /// </summary>
    /// <param name="command">Command to Execute</param>
    /// <returns>A Fill DataSet with results</returns>
    DataSet ExecuteDataSet(IDbCommand command);

    /// <summary>
    /// Return a DataSet with the command result
    /// </summary>
    /// <param name="query">Query to Execute</param>
    /// <returns>A Fill DataSet with results</returns>
    DataSet ExecuteDataSet(string query);

    /// <summary>
    /// Ejecuta una consulta y retorna un DataSet
    /// </summary>
    /// <param name="connection">La conexion</param>
    /// <param name="query">El Query o consulta SQL</param>
    /// <returns>Un DataSet que contiene el resultado del comando</returns>
    DataSet ExecuteDataSet(IDbConnection connection, CommandType commandType, string query);
    #endregion ExecuteDataSet Methods

    // ExecuteDataTable Methods
    #region ExecuteDataTable Methods
    /// <summary>
    /// Create an DataAdapter and Fill a DataTable
    /// </summary>
    /// <param name="command">Command to Execute</param>
    /// <returns>A Fill DataTable</returns>
    DataTable ExecuteDataTable(IDbCommand command);

    /// <summary>
    /// Create an DataAdapter and Fill a DataTable
    /// </summary>
    /// <param name="query">Query to Execute</param>
    /// <returns>A Fill DataTable</returns>
    DataTable ExecuteDataTable(string query);

    /// <summary>
    /// Create an DataAdapter and Fill a DataTable
    /// </summary>
    /// <param name="connection">Active Connection</param>
    /// <param name="commandType">Command Type</param>
    /// <param name="query">Query to Execute</param>
    /// <returns>A Fill DataTable</returns>
    DataTable ExecuteDataTable(IDbConnection connection, CommandType commandType, string query);
    #endregion ExecuteDataTable Methods

    // ExecuteScalar Methods
    #region ExecuteScalar Methods
    /// <summary>
    /// Execute the command and return the value
    /// </summary>
    /// <param name="command">Command to Execute</param>
    /// <returns>Return the first Value</returns>
    object ExecuteScalar(IDbCommand command);

    /// <summary>
    /// Execute the command and return the value
    /// </summary>
    /// <param name="query">Query to </param>
    /// <returns>Return the first Value</returns>
    object ExecuteScalar(string query);

    /// <summary>
    /// Execute the command and return the value
    /// </summary>
    /// <param name="connection">Active Conection</param>
    /// <param name="commandType">Command Type</param>
    /// <param name="query">Query to </param>
    /// <returns>Return the first Value</returns>
    object ExecuteScalar(IDbConnection connection, CommandType commandType, string query);
    #endregion Métodos de ExcecuteScalar

    // Parameter Methods
    #region Parameter Methods
    /// <summary>
    /// Add a Parameter to the Command
    /// </summary>
    /// <param name="command">Current Command</param>
    /// <param name="parameterName">Parameter Name</param>
    /// <param name="direction">Paramter Direction</param>
    /// <param name="value">Parameer Value</param>
    /// <param name="size">Parameter Size</param>
    /// <param name="dbType">Parameter Database Type</param>
    void AddCommandParameter(IDbCommand command, string parameterName, ParameterDirection direction, object value, int? size, DbType dbType);

    /// <summary>
    /// Add an Input Parameter to the Command 
    /// </summary>
    /// <param name="command">Current Command</param>
    /// <param name="parameterName">Parameter Name</param>
    /// <param name="value">Parameer Value</param>
    /// <param name="size">Parameter Size</param>
    /// <param name="dbType">Parameter Database Type</param>
    void AddInParameter(IDbCommand command, string parameterName, object value, int? size, DbType dbType);

    /// <summary>
    /// Add an Output Parameter to the Command 
    /// </summary>
    /// <param name="command">Current Command</param>
    /// <param name="parameterName">Parameter Name</param>
    /// <param name="value">Parameer Value</param>
    /// <param name="size">Parameter Size</param>
    /// <param name="dbType">Parameter Database Type</param>
    void AddOutParameter(IDbCommand command, string parameterName, Object value, int? size, DbType dbType);

    /// <summary>
    /// Add an Input/Output Parameter to the Command 
    /// </summary>
    /// <param name="command">Current Command</param>
    /// <param name="parameterName">Parameter Name</param>
    /// <param name="value">Parameer Value</param>
    /// <param name="size">Parameter Size</param>
    /// <param name="dbType">Parameter Database Type</param>
    void AddIOParameter(IDbCommand command, string parameterName, Object value, int? size, DbType dbType);

    /// <summary>
    /// Add a Return Value Parameter to the Command 
    /// </summary>
    /// <param name="command">Current Command</param>
    /// <param name="parameterName">Parameter Name</param>
    /// <param name="value">Parameer Value</param>
    /// <param name="size">Parameter Size</param>
    /// <param name="dbType">Parameter Database Type</param>
    void AddReturnValueParameter(IDbCommand command, string parameterName, Object value, int? size, DbType dbType);
    #endregion Parameter Methods
  }
}
