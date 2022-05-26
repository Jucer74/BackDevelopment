namespace Bank{

    using System;
    using System.Collections.Generic;

     public class AccountData: IAccountData
    {   
        public static List<AccountDto> AccountsInBank = new List<AccountDto>();
        public static Account AccountTwo = new Account();

        AccountDto account;
      
        public AccountData(){
          account =  new AccountDto();
          account.AccountNumber = 123456L;
          account.AccountType = "saving";
          account.BalanceAmount= 120.500;
          account.OverdraftAmount= 0.0;
          account.PlaceHolder = "david";
          AccountData.AccountsInBank.Add(account);
        }

        public AccountDto GetAccount(long AccountNumber){

            AccountDto returnAccount = new AccountDto();

            foreach (AccountDto getAccount in AccountsInBank)
            {
                  if(getAccount.AccountNumber == AccountNumber){
                    returnAccount = getAccount;
                    break;
                }
            }
      
            return returnAccount;
        }

        public void CreateAccount(AccountDto accountDto){
               
                if(accountDto == null){
                    Console.WriteLine("Error: Invalid data, is null o void.");
                    return;
                }

                if(verifyAccountIsExist(accountDto.AccountNumber)){
                    Console.WriteLine("Error: account  is exist.");
                    return;
                }   
 
                 AccountsInBank.Add(accountDto);
                 Console.WriteLine("Complete form: Account created.");
                 AccountTwo.ShowDetails(accountDto);

        }

        private bool verifyAccountIsExist(long AccountNumber){

            AccountDto account = GetAccount(AccountNumber);
            if(account.AccountNumber != 0){ // 0 ninguno encontrado
                 return true;
            }
            return false;
        }

        public void DepositAccount(long AccountNumber, decimal Amount){

        }

        private bool withDrawalAccount(long AccountNumber){
             
             //  hasta el valor del Sobregiro
             if(AccountNumber < 1000000){
                 return true;
             }

             return false;
        
        }

        public void GetBalance(AccountDto accountDto){
 

              if(accountDto.AccountNumber == 0){
                   Console.WriteLine("Account not found.");
                  return;
              }

              AccountTwo.ShowDetails(accountDto);
        }

      

    }
}

