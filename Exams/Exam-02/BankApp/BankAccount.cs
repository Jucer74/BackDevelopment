
namespace BankApp{
using System;
public class BankAccount
        {
            public int AccountNumber {get;set;}
            public string PlaceHolder {get;set;}
            public double BalanceAmount {get;set;}
            public bool AccountType {get;set;}

            public void Deposit(double Amount)
            {
                BalanceAmount = BalanceAmount + Amount;
            }

            public bool Withdrawal(double Amount)
            {
                if(AccountType == true){
                    if(BalanceAmount>= Amount){
                        BalanceAmount = BalanceAmount - Amount;
                        return true;
                    }
                    else{
                        return false;
                    }
                }
                else{
                    double check = BalanceAmount;
                    check = check - Amount;

                    if(check <=-1000001){
                        return false;
                    }
                    else{
                        BalanceAmount = BalanceAmount - Amount;
                        return true;
                    }
                }
            }
        }

}