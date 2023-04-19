# Evaluación Teórica (40%)
Responda las preguntas del siguiente Enlace:

[Examen]()

# Ejercicio (60%)
Implemente la aplicacion para Soportar operaciones sobre Cuentas Bancarias, Teniendo en cuenta el siguiente diagrama de Clases:

![Diagrama](https://github.com/Jucer74/BackDevelopment/blob/main/Exams/Exam-02/Images/Calss-Diagram.png)

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

- ExistsAccount(accountNumber: string) : bool
  Valida que una cuenta exista en la lista de cuentas

## Aplicacion 
La aplicacion debe mostrar un Menu con las siguientes opciones:

 1- Create Account
 2- Get Balance Account
 3- Deposit Account
 4- Withdrawal Account
 0- Exit

En cada Opcion se piden los datos y se validan que sean datos corectos, ya sea de contenido, de tipo o de longitud, antes de proceder a ejecutar la accion

## Acciones
Las siguientes Sopn ejemplos de las posibles acciones sobre las cuentas

### Cuenta Ahorros

**Crear Cuenta**
```
Create Account
--------------
AccounTypepe (1-Saving , 2-Checking):  1
Account Number: 1111111111
Account Owner: Julio Robles
Balance Amount : 100000

Account Created

Press any key to continue...
```

**Obtener Balance**
```
Get Balance
-----------
Account Number: 1111111111
Acount Type = Saving
Placeholder= Julio Robles
Balance Amount= 100000

Press any key to continue...
```

**Depositar Valor**
Depositar 200000 debe Aumetar el Saldo a 300000

```
Deposit Amount
--------------
Account Number: 1111111111
Amount : 200000

Deposit Success

Press any key to continue...
```

**Obtener Balance**
```
Get Balance
-----------
Account Number: 1111111111
Acount Type = Saving
Placeholder= Julio Robles
Balance Amount= 300000

Press any key to continue...
```

**Retirar Valor**
Retirar 50000 debe decrementa el Saldo a 250000

```
Withdrawal Amount
----------------
Account Number: 1111111111
Amount : 50000

Withdrawal Success

Press any key to continue...
```

**Obtener VBalance**
```
Get Balance
-----------
Account Number: 1111111111
Acount Type = Saving
Placeholder= Julio Robles
Balance Amount= 250000

Press any key to continue...
```


### Cuenta Corriente

**Crear Cuenta**
```
Create Account
--------------
AccounTypepe (1-Saving , 2-Checking):  2
Account Number: 2222222222
Account Owner: Pilar Lopez
Balance Amount : 500000

Account Created

Press any key to continue...
```

**Obtener Balance**
El saldo Inicial debe sumar 1500000, para Incluir el valor de 1000000 que es el Minimo valor de sobregiro
```
Get Balance
-----------
Account Number: 2222222222
Acount Type = Checking
Placeholder= Pilar Lopez
Balance Amount= 1500000
Overdraft Amount= 0

Press any key to continue...
```

**Depositar Valor**
Se depositan 200000 pra aumenatr el saldo Inicial
```
Deposit Amount
--------------
Account Number: 2222222222
Amount : 200000

Deposit Success

Press any key to continue...
```

**Obtener Balance**
El valor del saldo debe aumentar a 1700000
```
Get Balance
-----------
Account Number: 2222222222
Acount Type = Checking
Placeholder= Pilar Lopez
Balance Amount= 1700000
Overdraft Amount= 0

Press any key to continue...
```


**Retirar Valor**
Se retiran 800000, con lo que debe bajar el saldo a 900000
```
Withdrawal Amount
----------------
Account Number: 2222222222
Amount : 800000

Withdrawal Success

Press any key to continue...
```

**Obtener Balance**
Como el retiro sobrepasa el valor inicial, debe mostrar un sobregiro de 100000

```
Get Balance
-----------
Account Number: 2222222222
Acount Type = Checking
Placeholder= Pilar Lopez
Balance Amount= 900000
Overdraft Amount= 100000

Press any key to continue...
```

## Validsaciones de Cuenta

**Cuenta ya Existe**
```
Create Account
--------------
AccounTypepe (1-Saving , 2-Checking):  1
Account Number: 1111111111
Account Owner: Juan Jaramillo
Balance Amount : 1000000
Account : 1111111111 already exists

Press any key to continue...
```

**Cuenta NO Existe**
Esto debe validarlo an el balance, en el deposito y el retiro.

```
Get Balance
-----------
Account Number: 5555555555
Account : 5555555555 doesn't exist

Press any key to continue...
```

## Validationes de Datos, Tipos y Longitudes

**Numero de Cuenta**
Debe validar que sea solo digitos y que la longitud debe ser exacta de 10 digitos
```
Get Balance
-----------
Account Number: ABCDEFGHIJ
Account number must have 10 digits
Account Number: 12345678901
Account number must have 10 digits
Account Number: 123456789
Account number must have 10 digits
Account Number:
```

**Propietario de la Cuenta**
Debe Validar que no sea Vacio y que la longitud No sea mayor a 50 Caracteres
```
Create Account
--------------
AccounTypepe (1-Saving , 2-Checking):  1
Account Number: 1234567890
Account Owner:
Account Owner is required and max length is 50 characters
Account Owner: ABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJ1
Account Owner is required and max length is 50 characters
Account Owner:

```

**Monto o Valor**
No pude ser vacio y debe ser superior a cero. (Aplica para cualquier Monto en cualquier operacion)
```
Create Account
--------------
AccounTypepe (1-Saving , 2-Checking):  1
Account Number: 1234567890
Account Owner:
Account Owner is required and max length is 50 characters
Account Owner: ABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJ1
Account Owner is required and max length is 50 characters
Account Owner: Camilo Rios
Balance Amount :
Amount is required and must be numeric and greater than zero.
Balance Amount : 0
Amount is required and must be numeric and greater than zero.
Balance Amount :
```

Si todas las valudaciones estan bien ejecuta el proceso
```
Create Account
--------------
AccounTypepe (1-Saving , 2-Checking):  1
Account Number: 1234567890
Account Owner:
Account Owner is required and max length is 50 characters
Account Owner: ABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJ1
Account Owner is required and max length is 50 characters
Account Owner: Camilo Rios
Balance Amount :
Amount is required and must be numeric and greater than zero.
Balance Amount : 0
Amount is required and must be numeric and greater than zero.
Balance Amount : 100000

Account Created

Press any key to continue...
```

### Validaciones de Fondos

**Fondos Insuficientes**
Debe Validar siempre contra el valor del saldo. En este caso tenemos la cuenta de ahorros con un saldo de 250000 y trateresmos de retirar 300000 y debe mostrar un mensaje de fondos insuficientes
```
Get Balance
-----------
Account Number: 1111111111
Acount Type = Saving
Placeholder= Julio Robles
Balance Amount= 250000

Press any key to continue...

Withdrawal Amount
----------------
Account Number: 1111111111
Amount : 300000

Insufficient funds

Press any key to continue...
```

Si la cuenta es Corriente, tenemos un saldo de 900000, con un sobregiro de 100000 y Trateremos de retirar 1000000.
```
Get Balance
-----------
Account Number: 2222222222
Acount Type = Checking
Placeholder= Pilar Lopez
Balance Amount= 900000
Overdraft Amount= 100000

Press any key to continue...

Withdrawal Amount
----------------
Account Number: 2222222222
Amount : 1000000

Insufficient funds

Press any key to continue...
```

# Nota
RECUERDE SUBIR SU SOLUCIÓN A SU RAMA DE ESTE REPOSITORIO.

# Notas
Estos seran los criterios de calificacion de todo el aplicativo:

- No tiene Errores Ni Warnings (0.5)      = 
- No tiene Codigo Innecesario  (0.5)      = 
- Funciona y Cumple con el Objetivo (1.0) =
  - Adiciona la Cuenta
    - Valida que el Tipo de cuenta sea solo 1 o 2
    - Valida que el Numero de la cuenta sean solo Digitos y no letras ni espacios, ni caracteres 
    - Valida que la cuenta sea exactametne de 10 digitos
    - Valida que el Nombre del propietario de la cuenta sea diferente de vacio y con longitud menor a 50 caracteres
    - Valida que la creacion de la Cuenta ejecute correctamente el FactoryMethiod y asigne una cuenta correcta
  - Obtiene el Saldo Correctamente
  - Deposita un valor corectamente (Incrementa el Saldo)
  - Retira un valor correctamente (Decrementa el Saldo)
  - Valida que la Cuenta Exista 
  - Valida que el Monto a depositar sea mayor a cero
  - Valida que el Monto a retirar sea mayor a cero
  - Valida que al momento de retirara se tenga fondos suficientes
  - Valida el retiro con el Valor de sobregiro
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
