# Evaluación Teórica (40%)
Responda las preguntas del siguiente Enlace:

[Examen]()

# Ejercicio (60%)
Implemente la aplicacion para Soportar operaciones sobre Cuentas Bancarias, Teniendo en cuenta el siguiente diagrama de Clases:

## Cuenta Bancaria
Define las propiedades principales de la cuenta asi:

## IBankAcount 
**Propiedades**
 + AccountNumber  : string  => Numero de la Cuenta, Solo Digitos y longitud exacta de 10 digitos
 + AccountOwner   : string   => Nombre del Titular de la cuenta y longitud menor o igual a 50 caracteres
 + BalanceAmount  : decimal  => Valor Numerico mayor a cero
 + AccountType    : AccountType => Tipo de cuenta (Ahorros o Corriente) de tipo enum AccountType
                  1) Saving , 2) Checking

**Metodos**
 + Deposit(amount: decimal) : void
   Incrementa el valor del BalanceAmount con el valor pasado por parametro
 + Withdrawal (amount: decimal) : void
   Decrementa el valor del BalanceAmount, restando el valor pasado  por parametro
 
 ## Tipos de Cuentas Bancarias (Ahorros/Corriente)
 Heredan de **IBankAccount** he implementan los metodos correspondientes
 + SavingAccount : IBankAccount
   Implementa las propiedades y Metodos de la Interface IBankAccount para manejar los datos de la cuenta de Ahorros

 + CheckingAccount : IBankAccount
    + OverdraftAmount: decimal => Valor de Sobregiro 

   Implemente las propiedades y metodos de la interface IBankAccount para manejar los datos de la cuenta corriente, adicionando la propiedad de OverdraftAmount (Valor de sobregiro), cuyo valor minimo por defecto seria de un millon (MIN_OVERDRAFT_AMOUNT=1.000.000), por lo que al momento de crear una cuenta corriente el valor del saldo (BalanceAmount) será igual al valor de la cuenta mas el valor minimo de siobregiro.

 **Bank**
  - AcountList: List<IBankAcount> => Lista con todas las cuentas que se estan manejando por la aplicacion
## Metodos 

+ CreateAccount (accountNumber: IBankAccount) : static Void
  Adiciona una nueva cuenta a la lista general de Cuentas, validando que no exista, en cuyo caso muestra un menaje de que la cuenta ya existe

+ GetBalance(accountNumber: string): static void
  Obtiene el balance o saldo actual de la cuenta, validando primero que la cuenta exista, en cuyo caso de no existir , se muestra un mensaje de error

+ DepositAccount(accountNumber: string, amount: decimal) 
  Valida que la cuenta exista y adiciona el valor depositado al saldo de la cuenta. pero en caso de no existir la cuenta, se muestra un mensaje de que la cuenta no existe.
    
+ WithdrawalAccount(accountNumber: string, amount: decimal)
  Valida que la cuenta exista y descuenta el valor del balance de la cuenta, teniendo presente que en caso tal de que la cuenta sea de tipo Corriente, el valor a retirar no debe soportar el valor de sobregiro, en caso de no tnener fondos.

## Aplicacion 
La aplicacion debe mostrar un Menu con las siguientes opciones:

 1- Create Account
 2- Get Balance Account
 3- Deposit Account
 4- Withdrawal Account
 0- Exit

En cada Opcion se piden los datos y se validan que sean datos corectos, ya sea de contenido, de tipo o de longitud, antes de proceder a ejecutar la accion
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
  - tiene notaciones innecesarias (IntCodigo, strData) ?               
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
