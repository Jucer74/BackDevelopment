using System.Collections.Generic;

namespace BankApp
{
    public interface ITransactionAccount
    {
        void GetBalance(List<BankAccount> accountList);
        void Deposit(List<BankAccount> accountList);
        void Withdrawal(List<BankAccount> accountList);
    }
}
