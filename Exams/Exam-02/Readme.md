# Examen Tecnico
Implemente una API para soportar la creacion de cuentas bancarias, simulando las operaciones de un cajero automatico.

Para ello Utilice como base el proyecto **MoneyBankAPI** e implemente el codigo necesario para completar las funcionalidades.

# Base de Datos
Utilizando el motor de Base de datos MySQL, ejecute los scripts de creacion de base de datos, creacion de usuario, creacion de tabla y el de insercion de datos para preparar el ambiente inicial de su proyecto.

## Scripts
- 01_Create_Database.sql
- 02_Create_User.sql
- 03_TAB_Accounts.sql
- 04_INS_Acounts.sql

# Modelos
Basandose en la tabla de Account cree el Modelo Necesario para realizar las acciones basicas de adminitracion de los datos (CRUD)

```csharp
public class Account
{
    public  int Id { get; set; }
    public char AccountType { get; set; } = 'A';
    public DateTime CreationDate { get; set; } = DateTime.Now;
    public string AccountNumber { get; set; } = null!;
    public string OwnerName { get; set; } = null!;
    public decimal BalanceAmount { get; set; }
    public decimal OverdraftAmount { get; set; }
}
```
Tenga en cuenta complementarlo con las Anotaciones Necesarias para manejar los conceptos de :
- Llave ([Key])
- Requeridos (ej. El campo Nombre del Propietario es Requerido) ([Required])
- Longitud (ej. El campo Numero de La Cuenta tiene una longitud maxima de 10 caracteres) ([MaxLength])
- Valores (ej. El campo Numero de la Cuenta Solo Acepta Numeros) ([RegularExpression("\d{10}")])
- Monedas (ej, El campo Balance debe ser en formato Moneda (0.00)) ([RegularExpression("^\d+.?\d{0,2}$")])
- Lista de Datos (ej. El campo Tipo de Cuenta solo permite (A o C)) ([RegularExpression("[AC]")])
- Tipos ([DataType(DataType.Date)])

Para mas informacion consulte [aqui](https://www.bytehide.com/blog/data-annotations-in-csharp)

# Object Relational Mapping (ORM) - Entity Framework
Adicione los Paquetes (Nugets) necesarios para acceder a la base de datos:

- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.Tools
- MySql.EntityFrameworkCore (asegurese de que sea esta y no otra)

# Contexto
Adicione el Contexto de la Aplicacion para enlazar el modelo a la base de datos banadose en la clase **AppDbContext**

```csharp
public class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Account> Accounts { get; set; }
}
```

Recuerde agregar el contexto de la base de datos al Scope de la aplicacion en la clse **Program**


```csharp
var builder = WebApplication.CreateBuilder(args);

// Add DBContext
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("CnnStr")!));
```

# Controlador
Agregue el controlador **AccountsController** de tipo **API**, adicionando Acciones de Entity Framework, utilizando el Modelo de **Account** y el contexto de **AppDbContext**.


**Nota:** (Asegurese seleccionar **API** en lugar de MVC)

# EndPoints
Al seleccionar el Controlador con acciones que usan Entity Framework se crean las acciones principales de CRUD para las cuentas, en este punto ya es posible probrar estas acciones y confirmar su correcta ejecucion.

## GetAccounts
### Metodo
GET /api/Accounts

### Request
Sin Contenido

### Response
Arreglo con los datos de las cuentas

```json
[
  {
    "id": 0,
    "accountType": "C",
    "creationDate": "2023-10-04",
    "accountNumber": "6",
    "ownerName": "string",
    "balanceAmount": 0,
    "overdraftAmount": 0
  }
]  
```

## GetAccount
### Metodo
GET /api/Accounts/{id}

### Request
Se envia el **Id** 

### Response
```csharp
{
  "id": 1,
  "accountType": "C",
  "creationDate": "2023-06-30T00:00:00",
  "accountNumber": "3016892501",
  "ownerName": "Yurley Orejuela Ramirez",
  "balanceAmount": 1500000,
  "overdraftAmount": 0
}
```

## PostAccount
### Metodo
POST /api/Accounts

### Request
```csharp
{
  "id": 0,
  "accountType": "A",
  "creationDate": "2023-10-04",
  "accountNumber": "6087523149",
  "ownerName": "John Doe",
  "balanceAmount": 1000000,
  "overdraftAmount": 0
}
```

### Response
```csharp
{
  "id": 4,
  "accountType": "A",
  "creationDate": "2023-10-04",
  "accountNumber": "6087523149",
  "ownerName": "John Doe",
  "balanceAmount": 1000000,
  "overdraftAmount": 0
}
```

## PutAccount
### Metodo
PUT /api/Accounts/{id}

### Request
Se envia el **Id** y el body con el contenido a modificar.

```csharp
{
  "id": 4,
  "accountType": "A",
  "creationDate": "2023-10-04",
  "accountNumber": "6087523149",
  "ownerName": "John Alexander Doe",
  "balanceAmount": 1000000,
  "overdraftAmount": 0
}
```
### Response
Sin contenido

## DeleteAccount
### Metodo
DELETE /api/Accounts/{id}

### Request
Se envia el **Id**

### Response
Sin contenido


# Acciones de Cajero
Para cubrir las transcciones propias del cajero se deben implementar los endPoints para Deposito y Retiro, utilizando el Modelo **Transaction** para enviar los datos.

```csharp
public class Transaction
{
    public int Id { get; set; }
    public string AccountNumber { get; set; } = null!;
    public decimal ValueAmount { get; set; }
}
```

## Deposito

### Metodo
PUT /api/Accounts/{id}/Deposit

### Request
```json
{
  "id": 0,
  "accountNumber": "2427744115",
  "valueAmount": 0
}
```
### Response
Sin Contenido

## Retiro

### Metodo
PUT /api/Accounts/{id}/Withdrawal

### Request
```json
{
  "id": 0,
  "accountNumber": "2427744115",
  "valueAmount": 0
}
```

### Response
Sin Contenido


# Consideraciones
- Al Crear la Cuenta debe validar los campos requeridos, tipos y longitudes ademas que debe validar que el Balance debe ser Mayor a Cero para aperturar la Cuenta, de lo contrario debe retornar un **BadRequest**, Con el Mensaje: "El Balance debe ser mayor a cero".
- Al Momento de Crear la cuenta Tambien debe validar que el Numero de la Cuenta NO Existe, sino debe generar un **BadRequest** con el Mensaje "La Cuenta [##########] ya Existe".
- Para las demas operaciones debe validar que la cuenta existe, sino debe retornar un **BadRequest** con el MNensaje "La Cuenta [##########] No Existe"
- El Valor Maximo de Sobregiro (MAX_OVERDRAFT) es de $1,000,000.00 (Un Millon)
- Al Crear una Cuenta de Ahorros el Valor del Balance es igual al valor inicial de la apertura
- Al Crear una cuenta Corriente, El valor del Balance inicial, es igual al Valor Ingresado mas el Valor Maximo de sobregiro, Por ejemplo si apertura una cuenta con un valor de $500,000.00 al crear la cuenta esta se crea sumandole el Monto Maximo de sobregiro, quedando entonces con un Valor Inicial de $1,500,000.00
- Al Realizar un Deposito y la cuenta es de Ahorros, el Valor del Balance se incrementa en el valor Depositado
- Al realizar un Deposito y la cuenta es Corriente, el Valor del Balance es igual al Valor valor actal mas el valor depositado y si el sobregiro es mayor a cero y el balance actualizado es menor que el MAX_OVERDRAFT, entonce el valor del sobregiro se actualiza con la diferencia del MAX_OVERDRAFT y el BAlance actualizado.
- Debe retornar un **BadRequest** con el Mensaje de "Fondos Insificientes" si al momento de retirar el valor de Retiro es superior al Valor actual del Balance

# Ejemplos
A continuacion mostraremos algunos ejemplos de la Logica de Deposito y Retiro para los tipos de cuentas.

## Cuenta de Ahorros / Deposito

Balance Actual = $200,000.00
Sobregiro= $0.00

Deposito =  $500,000.00

Nuevo Balance = $700,000.00
Sobregiro = $0.00

#### Regla
```csharp
Balance += Deposit
```


### Cuenta de Ahorros / Retiro

Balance Actual = $700,000.00
Sobregiro= $0.00

Retiro =  $300,000.00

Nuevo Balance = $400,000.00
Sobregiro = $0.00

#### Regla
```csharp
if (Withdrawal <= Balance) 
{
    Balance -= Withdrawal
}
else 
{
    "Fondos Insuficientes"
}
```


### Cuenta Corriente / Deposito

Balance Actual = $300,000.00
Sobregiro= $700,000.00

Deposito =  $500,000.00

Nuevo Balance = $800,000.00
Sobregiro = $200,000.00


#### Regla

```csharp
Balance += Deposit

if ( Overdraft > 0 && Balance < MAX_OVERDRAFT)
{
    OverDraft = MAX_OVERDRAFT - Balance
}
else 
{
    OverDraft = 0
}
```

### Cuenta Corriente / Retiro

Balance Actual = $800,000.00
Sobregiro= $200,000.00

Retiro =  $500,000.00

Nuevo Balance = $300,000.00
Sobregiro = $200,000.00

#### Reglas

```csharp
if (Withdrawal <= Balance) 
{
    Balance -= Withdrawal

    if( Overdraft > 0 && Balance < MAX_OVERDRAFT)
    {
        OverDraft = MAX_OVERDRAFT - Balance
    }
}
else 
{
    "Fondos Insuficientes"
}
```


# Condiciones
- Codigo debe quedar Cero errores y Cero Warnings
- Debe Implementar utilizando Clean Code y Beunas practicas de programacion
- Debe Adjuntar su archivo de Pruebas con las Operaciones Basicas

