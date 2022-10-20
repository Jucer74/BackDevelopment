namespace NetBank.DataAccess
{
   public static class Constants
   {
      public static readonly string DatabaseFileName = @"../../../../../Database/NetBankDB.db";
      public static readonly string SelectReportedCards = "SELECT Id, IssuingNetwork, CreditCardNumber, FirstName, LastName, StatusCard, ReportedDate, LastUpdatedDate FROM ReportedCards";
      public static readonly string SelectReportedCardByCardNumber = "SELECT Id, IssuingNetwork, CreditCardNumber, FirstName, LastName, StatusCard, ReportedDate, LastUpdatedDate FROM ReportedCards WHERE CreditCardNumber = $CreditCardNumber";
      public static readonly string UpdateReportedCards = "UPDATE ReportedCards SET StatusCard = $StatusCard  , LastUpdatedDate = datetime('now') WHERE CreditCardNumber = $CreditCardNumber";
   }
}
