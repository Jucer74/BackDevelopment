namespace MoneyBankAPI.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; } = null!;
        public decimal ValueAmount { get; set; }
    }

    

}
