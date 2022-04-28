using System;
namespace BankApp
{
    public interface IOverDraft
    {
        void ValidateOverdraftValue(double amountOverdraftValue);
    }
}
