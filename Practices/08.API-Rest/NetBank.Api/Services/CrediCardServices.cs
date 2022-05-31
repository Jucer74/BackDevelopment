using System;
using System.Text.RegularExpressions;
using System.Text.Json;
using NetBank.Api.Models;
using NetBank.Api.Define;
using System.IO;
using System.Collections.Generic;
using NetBank.Api.Utilities;

namespace NetBank.Api.Services
{
   public class CreditCardService
   {
      private const string NUMBER_REGEX = "^[0-9]*$";
      private List<IssuingNetworkData> IssuingNetworkDataList = LoadIssuingNetworkData();
      
      public CreditCardResult Result { get; set; }


      public ValidationResultType Validate(string creditCardNumber)
      {
         if (!IsNumber(creditCardNumber))
         {
            Result = BadRequetResult();
            return ValidationResultType.BadRequest;
         }

         string issuingNetwork = GetIssuingNetworkName(creditCardNumber);

         if(issuingNetwork is null)
         {
            Result = NotFoundResult();
            return ValidationResultType.NotFound;
         }

         Result = new CreditCardResult( issuingNetwork, CreditCardValidator.IsValid(creditCardNumber));
         return ValidationResultType.Ok;

      }

      private static List<IssuingNetworkData> LoadIssuingNetworkData()
      {
         StreamReader r = new StreamReader("IssuingNetworkData.json");
         string jsonString = r.ReadToEnd();
         return JsonSerializer.Deserialize<List<IssuingNetworkData>>(jsonString);
      }

      private static bool IsNumber(string creditCardNumber)
      {
		  if(string.IsNullOrEmpty(creditCardNumber))
			  return false;
		  
         return new Regex(NUMBER_REGEX).IsMatch(creditCardNumber);
      }	

      private string GetIssuingNetworkName(string creditCardNumber)
      {
         string issuingNetworkName = null;

         foreach (var issuingNetworkItem in IssuingNetworkDataList)
         {
            if(IsValidStartsWithNumbers(issuingNetworkItem.StartsWithNumbers, creditCardNumber))
               return issuingNetworkItem.IssuingNetworkName;

            if(IsValidInRange(issuingNetworkItem.InRange, creditCardNumber))
               return issuingNetworkItem.IssuingNetworkName;
         }

         return issuingNetworkName;
      }

      private bool IsValidInRange(RangeNumber inRange, string creditCardNumber)
      {
         if (inRange is null)
            return false;
         
         string startsWithNumberToValid = string.Empty;
         int startsWithNumberItemLength = 0;

         for (int i = inRange.MinValue; i <= inRange.MaxValue; i++)
         {
            startsWithNumberToValid = i.ToString();
            startsWithNumberItemLength = startsWithNumberToValid.Length;

            if(creditCardNumber.Substring(0, startsWithNumberItemLength).Equals(startsWithNumberToValid))
               return true;
         }
         return false;
      }

      private bool IsValidStartsWithNumbers(List<int> startsWithNumbers, string creditCardNumber)
      {
         if(startsWithNumbers.Count == 0)
            return false;

         string startsWithNumberToValid = string.Empty;
         int startsWithNumberItemLength = 0;

         foreach (var startsWithNumberItem in startsWithNumbers)
         {
            startsWithNumberToValid = startsWithNumberItem.ToString();
            startsWithNumberItemLength = startsWithNumberToValid.Length;

            if(creditCardNumber.Substring(0, startsWithNumberItemLength).Equals(startsWithNumberToValid))
               return true;
         }

         return false;
      }

      private CreditCardResult BadRequetResult()
      {
         return new CreditCardResult("Bad Request", false);
      }

      private CreditCardResult NotFoundResult()
      {
         return new CreditCardResult("Not Found", false);
      }

   }
}