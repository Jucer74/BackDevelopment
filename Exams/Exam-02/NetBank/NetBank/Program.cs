using NetBank.DataAccess;

#region Variables

ApplicationData applicationData = new();

#endregion Variables

Console.WriteLine("NetBank Application");

var reportedCardsList = applicationData.GetReportedCards();
PrintReportedCards(reportedCardsList); 

//Console.WriteLine(reportedCardsList.Count);

//var result = applicationData.UpdateReportedCard("6376773337234061");
//Console.WriteLine(result);

//var isValid = CreditCardBL.IsValid("6376773337234061");
//Console.WriteLine(isValid);

void PrintReportedCards(List<ReportedCard> reportedCards)
{
   // Title
   Console.WriteLine("Id,IssuingNetwork,CreditCardNumber,FirstName,LastName,StatusCard,ReportedDate,LastUpdatedDate");

   // Loop to print the records
   foreach (var reportedCard in reportedCards)
   {
      Console.WriteLine("{0},{1},{2},{3},{4},{5},{6:MM/dd/yyyy},{7:MM/dd/yyyy}", reportedCard.Id,
                                                                                 reportedCard.IssuingNetwork,
                                                                                 reportedCard.CreditCardNumber,
                                                                                 reportedCard.FirstName,
                                                                                 reportedCard.LastName,
                                                                                 reportedCard.StatusCard,
                                                                                 reportedCard.ReportedDate,
                                                                                 reportedCard.LastUpdatedDate);
   }
}