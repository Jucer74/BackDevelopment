using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    public class CheckingAccount: BankAccount
    { 

        public void OverDraftAmount(string accountType)
        {
            char valueInputYesOrNot;
            double saveNewBalanceValues = 0.0;
            List<Item> Bankaccount = new List<Item>();


            if (accountType == "2")
            {
                Console.WriteLine("Do you need a overdraft on your checking account? y or n");
                valueInputYesOrNot = Convert.ToChar(Console.ReadLine());

                if(valueInputYesOrNot == 'y' || valueInputYesOrNot == 'Y')
                {
                    for(int i = 0; i < Bankaccount.Count; i++)
                    {
                        
                        saveNewBalanceValues = Bankaccount[i].Balance += overDraftAmount; ;
                        break;
                    }
                    Console.WriteLine("Your balance is: " + saveNewBalanceValues);
                }
            }
        }
      
    }
}
