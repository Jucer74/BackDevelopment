using NetBank.Common.SqlData.Interface;

namespace NetBank.Common.SqlData;

public class SqlDatabase : ISqlDatabase
{
   // Attributes

   #region Attributes

   #endregion Attributes

   // Properties

   #region Properties

   /// <summary>
   /// Connection String
   /// </summary>
   public string ConnectionString { get; set; }

   /// <summary>
   /// Active Connection
   /// </summary>
   public SqliteConnection Connection { get; set; }

   #endregion Properties

   // Constructor

   #region Constructores

   /// <summary>
   /// Default Constructor
   /// </summary>
   public SqlDatabase()
   {
      ConnectionString = "";
   }

   /// <summary>
   /// Constructor with Connection String
   /// </summary>
   /// <param name="connectionString">Cadena de Conexion</param>
   public SqlDatabase(string connectionString)
   {
      ConnectionString = connectionString;
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
      Connection = new SqliteConnection(ConnectionString);
      return Connection;
   }

   /// <summary>
   /// Create database connection.
   /// Ignore the Connection String assigned and use the parameter
   /// </summary>
   /// <param name="connectionString">Connection String</param>
   /// <returns>Database Connection</returns>
   public IDbConnection CreateConnection(string connectionString)
   {
      Connection = new SqliteConnection(connectionString);
      return Connection;
   }

   /// <summary>
   /// Create and Open Connection
   /// Needs the Connection String assigned.
   /// </summary>
   /// <returns>Database Connection opened</returns>
   public IDbConnection CreateAndOpenConnection()
   {
      Connection = CreateConnection() as SqliteConnection;
      OpenConnection(Connection);
      return Connection;
   }

   /// <summary>
   /// Create and Open Connection
   /// Ignore the Connection String assigned and use the parameter
   /// </summary>
   /// <param name="connectionString">Connection String</param>
   /// <returns>Database Connection opened</returns>
   public IDbConnection CreateAndOpenConnection(string connectionString)
   {
      Connection = CreateConnection(connectionString) as SqliteConnection;
      OpenConnection(Connection);
      return Connection;
   }

   /// <summary>
   /// Open the Database Connection
   /// Uses the Property Connection
   /// </summary>
   public void OpenConnection()
   {
      if (Connection.State != ConnectionState.Open)
      {
         Connection.Open();
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
      if (Connection.State != ConnectionState.Closed)
      {
         Connection.Close();
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
      return (Connection.State == ConnectionState.Open);
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
         throw new SqliteException("The command cannot be null", 1);
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
      if (!IsOpenConnection(Connection))
      {
         throw new SqliteException("The connection is not opened", 1);
      }
      return Connection.CreateCommand();
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
         throw new SqliteException("The connection is not opened", 1);
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

      if (IsValidCommand(command))
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

      if (IsValidCommand(command))
      {
         dr = command.ExecuteReader();
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

      if (IsValidCommand(command))
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

   #endregion ExecuteScalar Methods

   // Parameter Methods

   #region Parameter Methods

   /// <summary>
   /// Returns a new DbParameter
   /// </summary>
   /// <returns>A DbParameter</returns>
   private DbParameter CreateParameter()
   {
      return new SqliteParameter();
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
      if (IsValidCommand(command))
      {
         // Create and setup the parameter
         DbParameter parameter = CreateParameter();
         parameter.Direction = direction;

         if (string.IsNullOrEmpty(parameterName))
         {
            throw new SqliteException("The parameter name cannot be null or empty", 1);
         }

         parameter.ParameterName = $"${parameterName}";
         parameter.DbType = dbType;

         if (value == null)
         {
            parameter.Value = DBNull.Value;
         }
         else
         {
            parameter.Value = value;
         }

         if (size.HasValue)
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