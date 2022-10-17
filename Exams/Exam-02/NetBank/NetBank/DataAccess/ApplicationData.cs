global using NetBank.Common.SqlData;
global using NetBank.Entities;

namespace NetBank.DataAccess;

public class ApplicationData
{
   private readonly SqlDatabase sqlDatabase;

   public ApplicationData()
   {
      var connectionString = GetConnectionString();
      sqlDatabase = new SqlDatabase(connectionString);
   }

   /// <summary>
   /// Get the records from table
   /// </summary>
   /// <returns>a record List</returns>
   public List<ReportedCard> GetReportedCards()
   {
      try
      {
         sqlDatabase.CreateAndOpenConnection();

         var command = sqlDatabase.CreateCommand(Constants.SelectReportedCards);
         var dataReader = sqlDatabase.ExecuteReader(command);

         var reportedCardList = new List<ReportedCard>();

         while (dataReader.Read())
         {
            var reportedCard = new ReportedCard
            {
               Id = Convert.ToInt32(dataReader["Id"].ToString()),
               IssuingNetwork = dataReader["IssuingNetwork"].ToString(),
               CreditCardNumber = dataReader["CreditCardNumber"].ToString(),
               FirstName = dataReader["FirstName"].ToString(),
               LastName = dataReader["LastName"].ToString(),
               StatusCard= dataReader["StatusCard"].ToString(),
               ReportedDate = Convert.ToDateTime(dataReader["ReportedDate"].ToString()),
               LastUpdatedDate  = Convert.ToDateTime(dataReader["LastUpdatedDate"].ToString())
            };

            reportedCardList.Add(reportedCard);
         }

         return reportedCardList;
      }
      finally
      {
         sqlDatabase.CloseConnection();
      }
   }

   /// <summary>
   /// Update Record
   /// </summary>
   /// <param name="creditCardNumber">Credit Card Number to Mark</param>
   /// <returns>Rows Affected</returns>
   public bool UpdateReportedCard(string creditCardNumber)
   {
      try
      {
         sqlDatabase.CreateAndOpenConnection();

         var command = sqlDatabase.CreateCommand(Constants.UpdateReportedCards);

         sqlDatabase.AddInParameter(command, "StatusCard", "Recovered", 10, DbType.String);
         sqlDatabase.AddInParameter(command, "CreditCardNumber", creditCardNumber, 50, DbType.String);

         var rowsAffects = sqlDatabase.ExecuteNonQuery(command);

         return rowsAffects > 0;
      }
      finally
      {
         sqlDatabase.CloseConnection();
      }
   }


   /// <summary>
   /// Build the Connection String to the database
   /// </summary>
   /// <returns>Connection String</returns>
   private static string GetConnectionString()
   {
      if(File.Exists(Constants.DatabaseFileName))
      {
         var sqlConnectionStringBuilder = new SqliteConnectionStringBuilder
         {
            DataSource = Constants.DatabaseFileName
         };

         return sqlConnectionStringBuilder.ToString();
      }

      return null;
   }
}