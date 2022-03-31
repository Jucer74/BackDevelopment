namespace SOLID.Common.SQLData
{
  using System;
  using System.Data;
  using System.Data.Common;
  using System.Data.SQLite;
  using Interface;

  public class SqlDatabase : ISqlDatabase
  {
    // Attributes
    #region Attributes
    // Connection String
    private string _connectionString;
    // current connection
    private SQLiteConnection _connection;
    #endregion Attributes

    // Properties
    #region Properties
    /// <summary>
    /// Connection String
    /// </summary>
    public string ConnectionString
    {
      get
      {
        return _connectionString;
      }
      set
      {
        _connectionString = value;
      }
    }

    /// <summary>
    /// Active Connection
    /// </summary>
    public SQLiteConnection Connection
    {
      get
      {
        return _connection;
      }
      set
      {
        _connection = value;
      }
    }
    #endregion Properties

    // Constructor
    #region Constructores
    /// <summary>
    /// Default Constructor
    /// </summary>
    public SqlDatabase()
    {
        this._connectionString = "";
    }

    /// <summary>
    /// Constructor with Connection String
    /// </summary>
    /// <param name="connectionString">Cadena de Conexion</param>
    public SqlDatabase(string connectionString)
    {
        this._connectionString = connectionString;
    }
    #endregion Constructores

    // Methods
    #region Methods

    // Connection Methods
    #region Connection Methods
    /// <summary>
    /// Create database connection.
    /// Needs the Connection String assigned.
    /// </summary>
    /// <returns>Database Connection</returns>
    public IDbConnection CreateConnection()
    {
      _connection = new SQLiteConnection(_connectionString);
      return _connection;
    }

    /// <summary>
    /// Create database connection.
    /// Ignore the Connection String assigned and use the parameter
    /// </summary>
    /// <param name="connectionString">Connection String</param>
    /// <returns>Database Connection</returns>
    public IDbConnection CreateConnection(string connectionString)
    {
      _connection = new SQLiteConnection(connectionString);
      return _connection;
    }

    /// <summary>
    /// Create and Open Connection
    /// Needs the Connection String assigned.
    /// </summary>
    /// <returns>Database Connection opened</returns>
    public IDbConnection CreateAndOpenConnection()
    {
        _connection = CreateConnection() as SQLiteConnection;
        OpenConnection(_connection);
        return _connection;
    }

    /// <summary>
    /// Create and Open Connection
    /// Ignore the Connection String assigned and use the parameter
    /// </summary>
    /// <param name="connectionString">Connection String</param>
    /// <returns>Database Connection opened</returns>
    public IDbConnection CreateAndOpenConnection(string connectionString)
    {
        _connection = CreateConnection(connectionString) as SQLiteConnection;
        OpenConnection(_connection);
        return _connection;
    }

    /// <summary>
    /// Open the Database Connection
    /// Uses the Property Connection
    /// </summary>
    public void OpenConnection()
    {
      if (_connection.State != ConnectionState.Open)
      {
        _connection.Open();
      }
    }

    /// <summary>
    /// Open the Database Connection
    /// </summary>
    /// <param name="connection">Current Connection</param>
    public void OpenConnection(IDbConnection connection)
    {
      if (connection.State != ConnectionState.Open)
      {
        connection.Open();
      }
    }

    /// <summary>
    /// Close the database Connection
    /// Uses the Property Connection
    /// </summary>
    public void CloseConnection()
    {
      if (_connection.State != ConnectionState.Closed)
      {
        _connection.Close();
      }
    }

    /// <summary>
    /// Close the database Connection
    /// </summary>
    /// <param name="connection">Connection to close</param>
    public void CloseConnection(IDbConnection connection)
    {
      if (connection.State != ConnectionState.Closed)
      {
        connection.Close();
      }
    }

    /// <summary>
    /// Check is the connection is Open
    /// Uses the Property Connection
    /// </summary>
    /// <returns>return <see langword="true"/> if is open, otherwise return <see langword="false"/>.</returns>
    public bool IsOpenConnection()
    {
      return (_connection.State == ConnectionState.Open);
    }

    /// <summary>
    /// Check is the connection is Open
    /// </summary>
    /// <param name="connection">Connection to check</param>
    /// <returns>return <see langword="true"/> if is open, otherwise return <see langword="false"/>.</returns>
    public bool IsOpenConnection(IDbConnection connection)
    {
      return (connection.State == ConnectionState.Open);
    }

    #endregion Connection Methods

    // Command Methods
    #region Command Methods
    /// <summary>
    /// Check If the command can be executed
    /// </summary>
    /// <param name="command">Command to Execute</param>
    /// <returns>return <see langword="true"/> if is open, otherwise return <see langword="false"/>.</returns>
    private bool IsValidCommand(IDbCommand command)
    {
      if (command is null)
      {
        throw new SQLiteException("The command cannot be null");
      }

      return true;
    }

    /// <summary>
    /// Create and return a command in the curent connection
    /// Uses the Property Connection
    /// </summary>
    /// <returns>Command Object</returns>
    public IDbCommand CreateCommand()
    {
      if (!IsOpenConnection(_connection))
      {
        throw new SQLiteException("The connection is not opened");
      }
      return _connection.CreateCommand();
    }

    /// <summary>
    /// Create and return a command in the connection
    /// </summary>
    /// <param name="connection">Active connection</param>
    /// <returns>Command Object</returns>
    public IDbCommand CreateCommand(IDbConnection connection)
    {
      if (!IsOpenConnection(connection))
      {
        throw new SQLiteException("The connection is not opened");
      }
      return connection.CreateCommand();
    }

    /// <summary>
    /// Create and return a command in the curent connection
    /// </summary>
    /// <param name="commandText">Command text to execute</param>
    /// <returns>Command Object</returns>
    public IDbCommand CreateCommand(string commandText)
    {
      // Create the Command
      IDbCommand command = CreateCommand();
      command.CommandText = commandText;
      command.CommandType = CommandType.Text;
      return command;
    }

    /// <summary>
    /// Create and return a command in the curent connection
    /// </summary>
    /// <param name="connection">Active connection</param>
    /// <param name="commandType">Comand Type</param>
    /// <param name="commandText">Command text to execute</param>
    /// <returns>Command Object</returns>
    public IDbCommand CreateCommand(IDbConnection connection, CommandType commandType, string commandText)
    {
      // Create the Command
      IDbCommand command = CreateCommand(connection);
      command.CommandText = commandText;
      command.CommandType = commandType;
      return command;
    }

    #endregion Command Methods

    // ExecuteNonQuery Methods
    #region ExecuteNonQuery Methods
    /// <summary>
    /// Execute the comnand and return the rows affects
    /// </summary>
    /// <param name="command">Comand</param>
    /// <returns>Rows affects</returns>
    public int ExecuteNonQuery(IDbCommand command)
    {
      int rowsAffects = -1;

      if(IsValidCommand(command))
      {
        rowsAffects = command.ExecuteNonQuery();
      }

      return rowsAffects;
    }

    /// <summary>
    /// Create a Command with the query and returns the rows affects
    /// </summary>
    /// <param name="query">Query text to execute</param>
    /// <returns>Rows affects number</returns>
    public int ExecuteNonQuery(string query)
    {
      // Create a command
      IDbCommand command = CreateCommand();
      command.CommandText = query;
      command.CommandType = CommandType.Text;

      // Execute the command
      int rowsAffects = ExecuteNonQuery(command);

      return rowsAffects;
    }

    /// <summary>
    /// Create a Command with the query and returns the rows affects
    /// </summary>
    /// <param name="connection">ACtive Connection</param>
    /// <param name="commandType">Command Type</param>
    /// <param name="query">Query to Execute</param>
    /// <returns></returns>
    public int ExecuteNonQuery(IDbConnection connection, CommandType commandType, string query)
    {
      // Create a command
      IDbCommand command = CreateCommand(connection, commandType, query);
      // Execute the command
      int rowsAffects = ExecuteNonQuery(command);

      return rowsAffects;
    }

    #endregion ExecuteNonQuery Methods

    // ExecuteReader Methods
    #region ExecuteReader Methods
    /// <summary>
    /// Execute a command and return an <see cref="IDataReader"/> datareader
    /// Uses the Property Connection
    /// </summary>
    /// <param name="command">Command to Execute</param>
    /// <returns>A DataReader</returns>
    public IDataReader ExecuteReader(IDbCommand command)
    {
      IDataReader dr = null;

      if(IsValidCommand(command))
      {
        dr = command.ExecuteReader();
        command.Dispose();
      }

      return dr;
    }

    /// <summary>
    /// Execute a command and return an <see cref="IDataReader"/> datareader
    /// Uses the Property Connection
    /// </summary>
    /// <param name="query">Query text to execute</param>
    /// <returns>Un DataReader</returns>
    public IDataReader ExecuteReader(string query)
    {
      // Create the command
      IDbCommand command = CreateCommand();
      command.CommandText = query;
      command.CommandType = CommandType.Text;
      // Execute DataReader
      IDataReader dr = ExecuteReader(command);

      return dr;
    }

    /// <summary>
    /// Execute a command and return an <see cref="IDataReader"/> datareader
    /// </summary>
    /// <param name="connection">Active Connection</param>
    /// <param name="query">Query text to execute</param>
    /// <returns>Un DataReader</returns>
    public IDataReader ExecuteReader(IDbConnection connection, CommandType commandType, string query)
    {
      // Create Command
      IDbCommand command = CreateCommand(connection, commandType, query);
      // Execute DataReader
      IDataReader dr = ExecuteReader(command);

      return dr;
    }

    #endregion ExecuteReader Methods 

    // DataAdapter Methods
    #region DataAdapter Methods
    /// <summary>
    /// Create and return a SQLiteDataAdapter 
    /// </summary>
    /// <param name="command">Command</param>
    /// <returns>An IDbDataAdapter</returns>
    private IDbDataAdapter CreateDataAdapter(IDbCommand command)
    {
      IDataAdapter da = null;

      if(IsValidCommand(command))
      {
        da = new SQLiteDataAdapter(command as SQLiteCommand);
        command.Dispose();
      }

      return da as SQLiteDataAdapter;
    }

    /// <summary>
    /// Create and return a SQLiteDataAdapter 
    /// </summary>
    /// <param name="query">Query to Execute</param>
    /// <returns>An IDbDataAdapter</returns>
    private IDbDataAdapter CreateDataAdapter(string query)
    {
      IDataAdapter da = null;

      // Create the command
      IDbCommand command = CreateCommand();
      command.CommandText = query;
      command.CommandType = CommandType.Text;
      // Eecute the command
      da = CreateDataAdapter(command);

      return da as SQLiteDataAdapter;
    }

    /// <summary>
    /// Create and return a SQLiteDataAdapter 
    /// </summary>
    /// <param name="connection">Active Connection</param>
    /// <param name="commandType">Command Type</param>
    /// <param name="query">Query to Execute</param>
    /// <returns>An IDbDataAdapter</returns>
    private IDbDataAdapter CreateDataAdapter(IDbConnection connection, CommandType commandType, string query)
    {
      // Create the command
      IDbCommand command = CreateCommand(connection, commandType, query);
      // Execute the command
      IDataAdapter da = CreateDataAdapter(command);

      return da as SQLiteDataAdapter;
    }
    #endregion DataAdapter Methods

    // ExecuteDataSet Methods
    #region ExecuteDataSet Methods
    /// <summary>
    /// Return a DataSet with the command result
    /// </summary>
    /// <param name="command">Command to Execute</param>
    /// <returns>A Fill DataSet with results</returns>
    public DataSet ExecuteDataSet(IDbCommand command)
    {
      DataSet ds = null;
      
      if (IsValidCommand(command))
      {
        // Create DataAdapter
        IDbDataAdapter adapter = CreateDataAdapter(command);
        ds = new DataSet();
        // Fill the DataSet
        adapter.Fill(ds);
        command.Dispose();
      }

      return ds;
    }

    /// <summary>
    /// Return a DataSet with the command result
    /// </summary>
    /// <param name="query">Query to Execute</param>
    /// <returns>A Fill DataSet with results</returns>
    public DataSet ExecuteDataSet(string query)
    {
      // Create the command
      IDbCommand command = CreateCommand();
      command.CommandText = query;
      // Execute the command
      DataSet ds = ExecuteDataSet(command);

      return ds;
    }

    /// <summary>
    /// Ejecuta una consulta y retorna un DataSet
    /// </summary>
    /// <param name="connection">La conexion</param>
    /// <param name="query">El Query o consulta SQL</param>
    /// <returns>Un DataSet que contiene el resultado del comando</returns>
    public DataSet ExecuteDataSet(IDbConnection connection, CommandType commandType, string query)
    {
      // Create the command
      IDbCommand command = CreateCommand(connection, commandType, query);
      // Execute the command
      DataSet ds = ExecuteDataSet(command);

      return ds;    
    }
    #endregion ExecuteDataSet Methods

    // ExecuteDataTable Methods
    #region ExecuteDataTable Methods
    /// <summary>
    /// Create an DataAdapter and Fill a DataTable
    /// </summary>
    /// <param name="command">Command to Execute</param>
    /// <returns>A Fill DataTable</returns>
    public DataTable ExecuteDataTable(IDbCommand command)
    {
      DataTable dt = null;
      
      if(IsValidCommand(command))
      {
        IDbDataAdapter adapter = CreateDataAdapter(command);
        dt = new DataTable();
        // Fill the DataSet
        (adapter as DbDataAdapter).Fill(dt);
        command.Dispose();
      }

      return dt;
    }

    /// <summary>
    /// Create an DataAdapter and Fill a DataTable
    /// </summary>
    /// <param name="query">Query to Execute</param>
    /// <returns>A Fill DataTable</returns>
    public DataTable ExecuteDataTable(string query)
    {
      // Create the command
      IDbCommand command = CreateCommand();
      command.CommandText = query;
      command.CommandType = CommandType.Text;
      // Execute the command
      DataTable dt = ExecuteDataTable(command);

      return dt;
    }

    /// <summary>
    /// Create an DataAdapter and Fill a DataTable
    /// </summary>
    /// <param name="connection">Active Connection</param>
    /// <param name="commandType">Command Type</param>
    /// <param name="query">Query to Execute</param>
    /// <returns>A Fill DataTable</returns>
    public DataTable ExecuteDataTable(IDbConnection connection, CommandType commandType, string query)
    {
      // Create the command
      IDbCommand command = CreateCommand(connection, commandType, query);
      // Execute the command
      DataTable dt = ExecuteDataTable(command);

      return dt;
    }
    #endregion ExecuteDataTable Methods

    // ExecuteScalar Methods
    #region ExecuteScalar Methods
    /// <summary>
    /// Execute the command and return the value
    /// </summary>
    /// <param name="command">Command to Execute</param>
    /// <returns>Return the first Value</returns>
    public object ExecuteScalar(IDbCommand command)
    {

      object obj = null;
      
      if(IsValidCommand(command))
      {
        // Execute the command
        obj = command.ExecuteScalar();
        command.Dispose();
      }

      return obj;
    }

    /// <summary>
    /// Execute the command and return the value
    /// </summary>
    /// <param name="query">Query to </param>
    /// <returns>Return the first Value</returns>
    public object ExecuteScalar(string query)
    {
      // Create the command
      IDbCommand command = CreateCommand();
      command.CommandText = query;
      command.CommandType = CommandType.Text;
      // Get the Value
      object obj = ExecuteScalar(command);

      return obj;
    }

    /// <summary>
    /// Execute the command and return the value
    /// </summary>
    /// <param name="connection">Active Conection</param>
    /// <param name="commandType">Command Type</param>
    /// <param name="query">Query to </param>
    /// <returns>Return the first Value</returns>
    public object ExecuteScalar(IDbConnection connection, CommandType commandType, string query)
    {
      // Create the command
      IDbCommand command = CreateCommand(connection, commandType, query);
      // Get the Value
      object obj = ExecuteScalar(command);

      return obj;
    }
    #endregion Métodos de ExcecuteScalar

    // Parameter Methods
    #region Parameter Methods
    /// <summary>
    /// Returns a new DbParameter
    /// </summary>
    /// <returns>A DbParameter</returns>
    private DbParameter CreateParameter()
    {
      return new SQLiteParameter();
    }

    /// <summary>
    /// Add a Parameter to the Command
    /// </summary>
    /// <param name="command">Current Command</param>
    /// <param name="parameterName">Parameter Name</param>
    /// <param name="direction">Paramter Direction</param>
    /// <param name="value">Parameer Value</param>
    /// <param name="size">Parameter Size</param>
    /// <param name="dbType">Parameter Database Type</param>
    public void AddCommandParameter(IDbCommand command, string parameterName, ParameterDirection direction, object value, int? size, DbType dbType)
    {
      if(IsValidCommand(command))
      {
        // Create and setup the parameter
        DbParameter parameter = CreateParameter();
        parameter.Direction = direction;

        if (string.IsNullOrEmpty(parameterName))
        {
          throw new SQLiteException("The parameter name cannot be null or empty");
        }

        parameter.ParameterName = $"@{parameterName}";
        parameter.DbType = dbType;

        if (value == null)
        {
            parameter.Value = DBNull.Value;
        }
        else
        {
            parameter.Value = value;
        }

        if(size.HasValue)
        {
          parameter.Size = size.Value;
        }

        // Add the Parameter
        command.Parameters.Add(parameter);
      }
    }

    /// <summary>
    /// Add an Input Parameter to the Command 
    /// </summary>
    /// <param name="command">Current Command</param>
    /// <param name="parameterName">Parameter Name</param>
    /// <param name="value">Parameer Value</param>
    /// <param name="size">Parameter Size</param>
    /// <param name="dbType">Parameter Database Type</param>
    public void AddInParameter(IDbCommand command, string parameterName, object value, int? size, DbType dbType)
    {
      AddCommandParameter(command, parameterName, ParameterDirection.Input, value, size, dbType);
    }

    /// <summary>
    /// Add an Output Parameter to the Command 
    /// </summary>
    /// <param name="command">Current Command</param>
    /// <param name="parameterName">Parameter Name</param>
    /// <param name="value">Parameer Value</param>
    /// <param name="size">Parameter Size</param>
    /// <param name="dbType">Parameter Database Type</param>
    public void AddOutParameter(IDbCommand command, string parameterName, Object value, int? size, DbType dbType)
    {
      AddCommandParameter(command, parameterName, ParameterDirection.Output, value, size, dbType);
    }

    /// <summary>
    /// Add an Input/Output Parameter to the Command 
    /// </summary>
    /// <param name="command">Current Command</param>
    /// <param name="parameterName">Parameter Name</param>
    /// <param name="value">Parameer Value</param>
    /// <param name="size">Parameter Size</param>
    /// <param name="dbType">Parameter Database Type</param>
    public void AddIOParameter(IDbCommand command, string parameterName, Object value, int? size, DbType dbType)
    {
      AddCommandParameter(command, parameterName, ParameterDirection.InputOutput, value, size, dbType);
    }

    /// <summary>
    /// Add a Return Value Parameter to the Command 
    /// </summary>
    /// <param name="command">Current Command</param>
    /// <param name="parameterName">Parameter Name</param>
    /// <param name="value">Parameer Value</param>
    /// <param name="size">Parameter Size</param>
    /// <param name="dbType">Parameter Database Type</param>
    public void AddReturnValueParameter(IDbCommand command, string parameterName, Object value, int? size, DbType dbType)
    {
      AddCommandParameter(command, parameterName, ParameterDirection.ReturnValue, value, size, dbType);
    }
    #endregion Parameter Methods

    #endregion Methods
  }
}
