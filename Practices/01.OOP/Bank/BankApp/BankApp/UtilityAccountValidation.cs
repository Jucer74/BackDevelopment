using System;
using System.Collections.Generic;

namespace BankApp
{
    public class UtilityAccountValidation: IUtilityAccountValidation
    {
        public UtilityAccountValidation()
        {
        }

        public BankAccount SearchAccount(string textAccount, List<BankAccount> accountList)
        {
            BankAccount bankAccount = null;
            for (int i = 0; i < accountList.Count; i++)
            {
                if (accountList[i].AccountNumber.Contains(textAccount))
                {
                    bankAccount = accountList[i];
                }
            }
            return bankAccount;
        }
    }
}
