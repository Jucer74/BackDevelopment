public class BankAccount
        {
            public int AccountNumber {get;set;}
            public string PlaceMolder {get;set;}
            public double BalanceAmount {get;set;}
            public bool AccountType {get;set;}

            public void Deposit(double amount)
            {
                BalanceAmount += amount;
            }

            public bool Withdrawal(double amount)
            {
                if(AccountType == true){
                    if(BalanceAmount>= amount){
                        BalanceAmount -= amount;
                        return true;
                    }
                    else{
                        return false;
                    }
                }
                else{
                    double test = BalanceAmount;
                    //check that the subtraction does not exceed 1 million
                    test -= amount;

                    if(test <=-1000001){
                        return false;
                    }
                    else{
                        BalanceAmount -= amount;
                        return true;
                    }
                }
            }
        }