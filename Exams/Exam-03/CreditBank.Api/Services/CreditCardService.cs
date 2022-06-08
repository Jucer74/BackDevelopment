using CreditBank.Api.Utilities;
using CreditBank.Api.Exceptions;

namespace NetBank.Api.Services
{
   public class CreditCardService
   {
        private string messageIsValid;

        public string GetCreditCardCheckDigitStatus(string creditCardNumber)
      {
            if (!CreditCardValidator.IsNumericCard(creditCardNumber))
            {
                throw new BadRequestException($"Credit Card [{creditCardNumber}] is NOT Numeric");
            }

            if (!CreditCardValidator.IsValid(creditCardNumber))
            {
                return messageIsValid = messageIsValid = $"Credit Card [{creditCardNumber}] is NOT Valid";
            }
            return messageIsValid = $"Credit Card [{creditCardNumber}] is Valid";
        }

   }
}