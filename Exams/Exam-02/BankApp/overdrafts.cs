using System;
namespace BankApp
{
    public class overdrafts: IOverDrafts
    {
        public overdrafts()
        {
        }
        
        //método para validar sobreGiro 
        public void ValidateOverdraftValue(double amountOverdraftValue)
        {
            try
            {
                if (amountOverdraftValue > 100000)
                {
                    throw new Exception("Excede valor permitido por transferencia");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}