using NetBank.BusinessLogic;
using NetBank.DataAccess;


#region Variables

ApplicationData applicationData = new();

#endregion Variables

Console.WriteLine("NetBank Application");
var option = '1';
string cardNumber = "12345";





while (option != '0') 
{
   Console.WriteLine("|--------------------NetBank01--------------------|");
   Console.WriteLine("1. Card List.");
   Console.WriteLine("2. Issuing Network Cards List.");
   Console.WriteLine("3. Card Data by Number.");
   Console.WriteLine("4. Reactivate.");
   Console.WriteLine("5. Validate Card");
   Console.WriteLine("0. Exit.");
   option = Console.ReadKey().KeyChar;
   Console.WriteLine();
   switch (option)
   {
      case '1':
         var reportedCardsList = applicationData.GetReportedCards();
         foreach (var card in reportedCardsList)
         {
            Console.WriteLine(card.Id + " " + card.IssuingNetwork + " " + card.CreditCardNumber + " " + card.FirstName + " " + card.LastName + " " + card.StatusCard);
         }

         break;
      case '2':
         Console.WriteLine("--> Select Issuign Network: ");
         Console.WriteLine("1. American Express");
         Console.WriteLine("2. Diners Club");
         Console.WriteLine("3. InstaPlayment");
         Console.WriteLine("4. JCB");
         Console.WriteLine("5. Maestro");
         Console.WriteLine("6. MasterdCard");
         Console.WriteLine("7. Visa");
         Console.WriteLine("8. Visa Electron");
         option = Console.ReadKey().KeyChar;
         Console.WriteLine();
         switch (option)
         {
            case '1':
               var AmericaExpressList = applicationData.GetReportedIssuingNetwork("americanexpress");
               foreach (var card in AmericaExpressList)
               {
                  Console.WriteLine(card.Id + " " + card.IssuingNetwork + " " + card.CreditCardNumber + " " + card.FirstName + " " + card.LastName + " " + card.StatusCard);
               }
               break;
            case '2':
               Console.WriteLine("1. Diners Club - Carte Blanche");
               Console.WriteLine("2. Diners Club - International");
               Console.WriteLine("3. Diners Club - USA & Canada");
               Console.WriteLine("4. Diners Club - Enroute");
               option = Console.ReadKey().KeyChar;
               Console.WriteLine();
               switch (option)
               {
                  case '1':
                     var dc_CarteBlancheList = applicationData.GetReportedIssuingNetwork("diners-club-carte-blanche");
                     foreach (var card in dc_CarteBlancheList)
                     {
                        Console.WriteLine(card.Id + " " + card.IssuingNetwork + " " + card.CreditCardNumber + " " + card.FirstName + " " + card.LastName + " " + card.StatusCard);
                     }
                     break;
                  case '2':
                     var dc_International = applicationData.GetReportedIssuingNetwork("diners-club-international");
                     foreach (var card in dc_International)
                     {
                        Console.WriteLine(card.Id + " " + card.IssuingNetwork + " " + card.CreditCardNumber + " " + card.FirstName + " " + card.LastName + " " + card.StatusCard);
                     }
                     break;
                  case '3':
                     var dc_US_CAList = applicationData.GetReportedIssuingNetwork("diners-club-us-ca");
                     foreach (var card in dc_US_CAList)
                     {
                        Console.WriteLine(card.Id + " " + card.IssuingNetwork + " " + card.CreditCardNumber + " " + card.FirstName + " " + card.LastName + " " + card.StatusCard);
                     }
                     break;
                  case '4':
                     var dc_Enroute = applicationData.GetReportedIssuingNetwork("diners-club-enroute");
                     foreach (var card in dc_Enroute)
                     {
                        Console.WriteLine(card.Id + " " + card.IssuingNetwork + " " + card.CreditCardNumber + " " + card.FirstName + " " + card.LastName + " " + card.StatusCard);
                     }
                     break;
               }

               break;

            case '3':
             
               var instapaymentList = applicationData.GetReportedIssuingNetwork("instapayment");
               foreach (var paymentCard in instapaymentList)
               {
                  Console.WriteLine(paymentCard.Id + " " + paymentCard.IssuingNetwork + " " + paymentCard.CreditCardNumber + " " + paymentCard.FirstName + " " + paymentCard.LastName + " " + paymentCard.StatusCard);
               }
               break;
            case '4':
               var jcbList = applicationData.GetReportedIssuingNetwork("jcb");
               foreach (var card in jcbList)
               {
                  Console.WriteLine(card.Id + " " + card.IssuingNetwork + " " + card.CreditCardNumber + " " + card.FirstName + " " + card.LastName + " " + card.StatusCard);
               }
               break;
            case '5':
               var maestroList = applicationData.GetReportedIssuingNetwork("maestro");
               foreach (var card in maestroList)
               {
                  Console.WriteLine(card.Id + " " + card.IssuingNetwork + " " + card.CreditCardNumber + " " + card.FirstName + " " + card.LastName + " " + card.StatusCard);
               }
               break;
            case '6':
               var masterCardList = applicationData.GetReportedIssuingNetwork("mastercard");
               foreach (var card in masterCardList)
               {
                  Console.WriteLine(card.Id + " " + card.IssuingNetwork + " " + card.CreditCardNumber + " " + card.FirstName + " " + card.LastName + " " + card.StatusCard);
               }
               break;
            case '7':
               var visaList = applicationData.GetReportedIssuingNetwork("visa");
               foreach (var card in visaList)
               {
                  Console.WriteLine(card.Id + " " + card.IssuingNetwork + " " + card.CreditCardNumber + " " + card.FirstName + " " + card.LastName + " " + card.StatusCard);
               }
               break;
            case '8':
               var visaElectronList = applicationData.GetReportedIssuingNetwork("visa-electron");
               foreach (var card in visaElectronList)
               {
                  Console.WriteLine(card.Id + " " + card.IssuingNetwork + " " + card.CreditCardNumber + " " + card.FirstName + " " + card.LastName + " " + card.StatusCard);
               }
               break;
         }
         break;
      case '3':
         Console.WriteLine("--> Insert Card Number: ");
         cardNumber = Console.ReadLine();
         var CardsList = applicationData.GetReportedCards();
         foreach (var card in CardsList)
         {
            if (card.CreditCardNumber == cardNumber)
            {
               Console.WriteLine(card.Id + " " + card.IssuingNetwork + " " + card.CreditCardNumber + " " + card.FirstName + " " + card.LastName + " " + card.StatusCard);
            }
         }
         break;
      case '4':
         Console.WriteLine("--> Insert Card Number: ");
         cardNumber = Console.ReadLine();


         var result = applicationData.UpdateReportedCard(cardNumber);
         Console.WriteLine(result);
         var updateStatusCard = applicationData.GetReportedCards();
         foreach (var card in updateStatusCard)
         {
            if (card.CreditCardNumber == cardNumber)
            {
               Console.WriteLine(card.Id + " " + card.IssuingNetwork + " " + card.CreditCardNumber + " " + card.FirstName + " " + card.LastName + " " + card.StatusCard);
            }
         }
         break;

      case '5':
         Console.WriteLine("--> Insert Card Number: ");
         cardNumber = Console.ReadLine();
         var isValid = CreditCardBL.IsValid(cardNumber);
         if(isValid == true)
         {
            Console.WriteLine("VALID.");
         }
         else
         {
            Console.WriteLine("NOT_VALID.");
         }
         
         break;
   }
}