namespace CreditBank.Api.Models
{
   public class ReportedCard
   {
      public int Id { get; set; }
      public string IssuingNetwork { get; set; }
      public string CreditCardNumber { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string StatusCard { get; set; }
      public DateTime ReportedDate { get; set; }
      public LastUpdatedDate LastUpdatedDate { get; set; }

      

   }
}
