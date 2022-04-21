 Diseñar las clases para Soportar Cuentas Bancarias
 BankAcount
 - AccountNumber
 - PlaceHolder (Titular)
 - BalanceAmount
 - AccountType = 1) Saving , 2) Checking
 
 - SavingAccount : BankAccount
 - CheckingAccount: : BankAccount
    - OverdraftAmount
 
 Metodhos
 - Deposit
 - withdrawal => CheckingAccount => Valor de Sobregiro (1000.000)
 - balance
 
 Bank
 - CreateAccount => List<BankAcount> AcountList
    - AccoutnNumber
    - PlaceHolder
    - AccountType
    - OverdraftAmount
    - BalanceAmount
 
 - GetBalance 
   -AccountNumber
   
 - DepositAccount
    - AccountNumber
    - Amount
    
 - WithdrawalAccount
    - AccountNumber
    - Amount => CcheckingAmount => hasta el valor del Sobregiro
 
 
 Console Application
 
 - Create Acount
 - Get Balance Account
 - Deposit Account
 - Withdrawal Account
 - Exit
 