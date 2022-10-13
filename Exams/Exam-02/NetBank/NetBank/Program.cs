using NetBank.DataAccess;

#region Variables

ApplicationData applicationData = new();

#endregion

Console.WriteLine("NetBank Application");

//var reportedCardsList = applicationData.GetReportedCards();
//Console.WriteLine(reportedCardsList.Count);

var result = applicationData.UpdateReportedCard("6376773337234061");
Console.WriteLine(result);

   