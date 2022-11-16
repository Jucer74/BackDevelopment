using NetBank.DataAccess;
using System.Collections.Generic;

#region Variables

ApplicationData applicationData = new();

#endregion Variables

Console.WriteLine("NetBank Application");



var reportedCardsList = applicationData.GetReportedCards();
 Console.WriteLine(reportedCardsList.Count);

var result = applicationData.UpdateReportedCard("6376773337234061");
Console.WriteLine(result);

var isValid = CreditCardBL.IsValid("6376773337234061");
Console.WriteLine(isValid);