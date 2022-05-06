using System.Collections.Generic;

namespace BankApp
{
    public interface IAccountValidation
    {
        BankAccount SearchAccount(string textAccount, List<BankAccount> accountList);
        BankAccount ElegirAccountType(List<BankAccount> accountList);

        BankAccount CreateSavingAccount(List<BankAccount> accountList,  BankAccount bankAccount, int accountType);

        BankAccount CreateChekingAccount(List<BankAccount> accountList,
        BankAccount bankAccount, int accountType);
    }
}