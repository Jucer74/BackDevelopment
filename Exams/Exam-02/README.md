# Evaluación Teórica (40%)
Responda las preguntas del siguiente Enlace:

[Examen](https://forms.gle/c4AFHvDamm32JPEe8)

# Ejercicio (60%)
Implemente la aplicacion para Soportar operaciones sobre Cuentas Bancarias
 
## Ceunta Bancaria

 **BankAcount**
 - AccountNumber
 - PlaceHolder (Titular)
 - BalanceAmount
 - AccountType = 1) Saving , 2) Checking
 
 - SavingAccount : BankAccount
 - CheckingAccount: : BankAccount
    - OverdraftAmount
 
## Metodos
 - Deposit
 - withdrawal => CheckingAccount => Valor de Sobregiro (1000.000)
 - balance
 
 **Bank**
 - CreateAccount => List<BankAcount> AcountList
    - AccoutnNumber
    - PlaceHolder
    - AccountType
    - OverdraftAmount
    - BalanceAmount

## Metodos 
 - GetBalance 
   -AccountNumber
   
 - DepositAccount
    - AccountNumber
    - Amount
    
 - WithdrawalAccount
    - AccountNumber
    - Amount => CcheckingAmount => hasta el valor del Sobregiro
 

## Aplicacion 
 1- Create Acount
 2- Get Balance Account
 3- Deposit Account
 4- Withdrawal Account
 0- Exit

# Nota
RECUERDE SUBIR SU SOLUCIÓN A SU RAMA DE ESTE REPOSITORIO.

# Notas
- No tiene Errores Ni Warnings (0.5)      = 
- No tiene Codigo Innecesario  (0.5)      = 
- Funciona y Cumple con el Objetivo (1.0) =
- Cuple los Principios SOLID (0.5)        = 
- El codigo Es Entendible (1.0)           = 
- Cumple con el Codigo Limpio (1.5)       = 
  Los Nombres de las variables y Funciones: (0.1/ cada una)
  - Revelan la intencion, es decir se sabe que hacen o que almacenan?
  - Los Nombres son claros o son confusos?                            
  - Son Pronunciables                                                 
  - Son buscables (Numero Magicos o No hay Constantes)?               
  - tiene notaciones innecesarias IntCodigo, strData) ?               
  - Usan Sustantivos para Clases y Verbos para Metodos?               
  - Una sola palabra por concepto?                                    
  - No usan combinaciones o juegos de palabras?                       
  - No tiene contexto adicional o superfluo?                          
  - Usan Datos del dominio, del negocio, problema o solucion ?        
  - Cumplen con el Estandar de Pascal y Camel Case?                   
  Las Funciones                                                         
  - Son pequeñas y su logica esta bien separada?                      
  - Las Funciones hacen una sola cosa?                                
  - Tieen Logica de Retorno directo y correcto o hay If para retornar 
  - No Existen Multiples If anidados o SI hay instrucciones Switch    
