using System;
namespace BankApp
{
    public class Overdraft: IOverDraft
    {
        public Overdraft()
        {
        }

        public void ValidateOverdraftValue(double amountOverdraftValue)
        {
            try
            {
                if (amountOverdraftValue > 100000)
                {
                    throw new Exception("****Exceeds The Value Allowed Per Transfer****");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
