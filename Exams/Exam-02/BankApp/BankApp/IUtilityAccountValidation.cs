using System.Collections.Generic;

namespace BankApp
{
    public interface IUtilityAccountValidation
    {
        BankAccount SearchAccount(string textAccount, List<BankAccount> accountList);
        BankAccount SelectAccountType(List<BankAccount> accountList);
    }
}
