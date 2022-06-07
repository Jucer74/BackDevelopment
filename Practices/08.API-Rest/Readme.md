# API Rest
Una API es la forma en como se pueden integrar dos o mas aplicaciones y que uso en Web se conoce como WebApi, que se base en estilo Arquitectonico denominado REST, que asu vez utiliza los siguientes verbos como base para efectuar las operaciones.

- **GET**: para Obtener datos, similar al **SELECT** de la base de datos
- **POST**: para enviar informacion o ejecutar un comando, es similar a un **INSERT** de la base de datos
- **PUT**: para actualizar informacion, es similar a un **UPDATE** de base de datos
- **DELETE**: para eliminar informacion y es similar al mismo comando **DELETE** de la base de datos.

REST (Representational State Transfer) se base principalmente en el protocolo HTTP, por lo cual se hace necesario el uso de HTTP Status Codes para complementar la infromacion retornada por las peticiones hechas a la PAI.

Estos son algunos de los Status Codes mas utilizados

| **StatusCode** | **Descripcion**        | **Notas**                                                                                                                                                         |
|----------------|------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 200            | OK                     | La peticion fue procesada satisfactoriamente                                                                                                                      |
| 400            | Bad request            | Normalmente, este código significa que la solicitud contiene secuencias o caracteres no válidos, o que la solicitud va en contra de la configuración de seguridad |
| 404            | Not found.             | Devuelto cuando un recurso no existe en el servidor                                                                                                               |
| 500            | Internal server error. | Este código de estado puede ocurrir por muchas razones del lado del servidor.                                                                                     |

Ve las lita completa [aqui](https://docs.microsoft.com/en-us/troubleshoot/developer/webapps/iis/www-administration-management/http-status-code)

## Patron MVC (Modelo-Vista-Controlador)
La construcción de una APi se base en el mismo esquema planteado por el patron MVC.

![](https://github.com/Jucer74/BackDevelopment/blob/main/Practices/08.API-Rest/Img/MVC.png)

En el Patron MVC existen tres elementos clave:

- **El Controller**: Que es el que se encarga de recibir las peticiones o request  para procesarlos.
- **El Modelo**: es la representacion logica de los datos de la base de datos
- **La Vista**: Es la forma en como se le retornan los datos al cliente  

PAra una API, el punto principal es que no se retornan Vistas, sino que se retornan objetos de tipo **ActionResult**, que contiene la information y el Status code de la operacion.


# Practica
Desarrolle una API, llamada **NetBank.Api**, y cree un controlador para validar si uan tarjeta de credito es valida y a que franquicia o Red emisora pertenece.

## API-Contract

** GET** : /api/v1/CreditCard/{creditcardNumber}

Response Types:

**ValidationSuccess**
Ok - Status Code: 200
Si el Numero de la tarjeta es correcto y se identifica la red emisora

```json
{
	"issuingNetwork" : "Visa",
	"Valid" : true
}
```

**BadRequest**

BadRequest - Status Code: 400
Si lo que se recibe como numero de tarjeta no es un conjuntode numeros

```json
{
	"issuingNetwork" : "Bad Request",
	"Valid" : false
}
```

**Not Found**
NotFoud -  Status Code: 404
Si no es posible encontrar la red Emisora
```json
{
	"issuingNetwork" : "Not Found",
	"Valid" : false
}
```

**Inernal Server Error**
InernalServerError - Status code: 500
si se presenta un error Inesperado y no controlado

```json
{
	"issuingNetwork" : "Internal Server Error",
	"Valid" : false
}
```

Para Obtener y validar la Red Emisore puede utilizar la siguiente tabla:

| Credit Card Issuer          | Starts With ( IIN Range )                                | Length ( Number of digits ) |
|-----------------------------|----------------------------------------------------------|-----------------------------|
| American Express            | 34, 37                                                   | 15                          |
| Diners Club - Carte Blanche | 300, 301, 302, 303, 304, 305                             | 14                          |
| Diners Club - International | 36                                                       | 14                          |
| Diners Club - USA & Canada  | 54                                                       | 16                          |
| Discover                    | 6011, 622126 to 622925, 644, 645, 646, 647, 648, 649, 65 | 16-19                       |
| InstaPayment                | 637, 638, 639                                            | 16                          |
| JCB                         | 3528 to 3589                                             | 16-19                       |
| Maestro                     | 5018, 5020, 5038, 5893, 6304, 6759, 6761, 6762, 6763     | 16-19                       |
| MasterCard                  | 51, 52, 53, 54, 55, 222100 to 272099                     | 16                          |
| Visa                        | 4                                                        | 13-16-19                    |
| Visa Electron               | 4026, 417500, 4508, 4844, 4913, 4917                     | 16                          |



Para validar una tarjeta utlice el agoritmo de [Luhn](https://github.com/marcrabadan/blog/tree/main/luhn/LuhnAlgorithm)
  

# Implementemos
Dentro del Directorio de practica de esta seccion y en una terminal o ventana de comandos ejecute la siguiente sentencia:

```csharp
dotnet new webapi --framework "Net5.0" --name "NetBank.Api"
```

Luego abra este folder en Visual Studio Code y realice los siguientes cambios:

1. A nivel del folder de Controladores, agregue un nuevo controlador llamao **CreditCardController.cs**
2. Copie el contenido del archivo base, llamado **WeatherForecastController** , dentro del archivo CreditCardController
3. Cambie la referencia a la clase **WeatherForecastController** y reemplacela por **CreditCardController**

Al final tendria un contenido como el siguietne, dentro del archivo **CreditCardController**. Tenga presente que no se cambia el archivo **WeatherForecastController**, solo se copia y en el nuevo archivo, se hacen las modificaciones asi:


```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NetBank.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreditCardController : ControllerBase
    {
        private readonly ILogger<CreditCardController> _logger;

        public CreditCardController(ILogger<CreditCardController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{creditcardNumber}")]
        public IActionResult Get(string creditcardNumber)
        {
           return Ok();
        }
    }
}
```

## Ejecutemos
Dentro de una Terminal de Visual Studio Code y parado dentro del dierctorio que contiene esta API, ejecute los siguietes comandos:

**Restore**
```ps
dotnet restore
```
Asegurese que el coamndo haya sido ejecutado sin errores

**Build**
```ps
dotnet nuild
```
Asegurese que el resultado de este sean siempre cero errores y cero warnings

```
Build succeeded.
    0 Warning(s)
    0 Error(s)
```
**Run**
```ps
dotnet run
``` 
Al momento de correr la API obtenemos :
```
Building...
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: D:\Documents\Dropbox\Personal\Cursos\Backend Development\Repository\Practices\08.API-Rest\NetBank.Api
```

Identifique el la API esta ejecutandose dentro del **localhost** en el puerto **5001**, por lo cual podemos hacer click sobre el link de resultado o copiar esta direccion y abrirla en un browser.

luego en el browser, modifique la url para incluir el llamado a **swagger** asi:

```
https://localhost:5001/swagger/index.html
```

En este punto debe tener algo como esto:


![](https://github.com/Jucer74/BackDevelopment/blob/main/Practices/08.API-Rest/Img/NetBank.Api-01.jpg)

# Implementemos la logica 
Cree una carpeta de llamada **Utilities** y adicione un archivo llamado **CreditCardValidator.cs** para agregar la validacion,
craendo un metodo estatico así:

```csharp
using System;
using System.Text;
namespace NetBank.Api.Utilities
{
   public static class CreditCardValidator
   {
      private const int MAX_VALUE_DIGIT = 9;
      private const int MIN_LENGTH = 13;
      private const int MAX_LENGTH = 19;
      private static int sum = 0;
      private static int digit = 0;
      private static int addend = 0;
      private static bool timesTwo = false;

      public static bool IsValid(string creditCardNumber)
      {
         var digitsOnly = GetDigits(creditCardNumber);

         if (digitsOnly.Length > MAX_LENGTH || digitsOnly.Length < MIN_LENGTH) return false;

         for (var i = digitsOnly.Length - 1; i >= 0; i--)
         {
            digit = int.Parse(digitsOnly.ToString(i, 1));
            if (timesTwo)
            {
               addend = digit * 2;
               if (addend > MAX_VALUE_DIGIT)
                  addend -= MAX_VALUE_DIGIT;
            }
            else
               addend = digit;

            sum += addend;

            timesTwo = !timesTwo;
         }
         return (sum % 10) == 0;
      }

      private static StringBuilder GetDigits(string creditCardNumber)
      {
         var digitsOnly = new StringBuilder();
         foreach (var character in creditCardNumber)
         {
            if (char.IsDigit(character))
               digitsOnly.Append(character);
         }
         return digitsOnly;
      }      
   }
}
```

## Adicionemos los datos de las Tarjetas
Cree un archivo llamado **IssuingNetworkData.json** en el raiz de los archivos y adicione la siguiente informacion

```json
[
   {
      "IssuingNetworkName": "American Express",
      "StartsWithNumbers": [ 34, 37],
      "InRange": null
   },
   {
      "IssuingNetworkName": "Diners Club - Carte Blanche",
      "StartsWithNumbers": [ 300, 301, 302, 303, 304, 305],
      "InRange": null
   },
   {
      "IssuingNetworkName": "Diners Club - International",
      "StartsWithNumbers": [ 36],
      "InRange": null
   },
   {
      "IssuingNetworkName": "Diners Club - USA & Canada",
      "StartsWithNumbers": [ 34],
      "InRange": null
   },
   {
      "IssuingNetworkName": "Discover",
      "StartsWithNumbers": [ 6011, 644, 645, 646, 647, 648, 649, 65],
      "InRange": {
         "MinValue": 622126,
         "MaxValue": 622925
      }
   },
   {
      "IssuingNetworkName": "InstaPayment",
      "StartsWithNumbers": [ 637, 638, 639],
      "InRange": null
   },
   {
      "IssuingNetworkName": "JCB",
      "StartsWithNumbers": [],
      "InRange": {
         "MinValue": 3528 ,
         "MaxValue": 3589
      }   
   },
   {
      "IssuingNetworkName": "Maestro",
      "StartsWithNumbers": [ 5018, 5020, 5038, 5893, 6304, 6759, 6761, 6762, 6763],
      "InRange": null
   },
   {
      "IssuingNetworkName": "MasterCard",
      "StartsWithNumbers": [51, 52, 53, 54, 55],
      "InRange": {
         "MinValue": 222100 ,
         "MaxValue": 272099
      }   
   },
   {
      "IssuingNetworkName": "Visa",
      "StartsWithNumbers": [4],
      "InRange": null
   },    
   {
      "IssuingNetworkName": "Visa Electron",
      "StartsWithNumbers": [ 4026, 417500, 4508, 4844, 4913, 4917],
      "InRange": null
   }
]
```


## Adicionemos los Modelos
Cree una nueva carpeta llamada **Models** y adicione alli los siguientes archivos: <br>

**CreditCardResult.cs** para crear la estructura de respuesta segun las validaciones así:

```csharp
using System;

namespace NetBank.Api.Models
{
   public class CreditCardResult
   {
      public string IssuingNetwork { get; set; }
      public bool Valid { get; set; }
   }
}
```

**RangeNumber.cs** para los rangos de numeros permitidos en algunas tarjetas
```csharp
using System;

namespace NetBank.Api.Models
{

   public class RangeNumber
   {
      public int MinValue { get; set; }
      public int MaxValue { get; set; }

   }
}
```

**IssuingNetworkData.cs** para cargar los datos de las tarjetas
```csharp
using System;
using System.Collections.Generic;

namespace NetBank.Api.Models
{

   public class IssuingNetworkData
   {
      public string IssuingNetworkName { get; set; }
      public List<int> StartsWithNumbers { get; set; }
      public RangeNumber InRange {get; set;}
   }
}
```

## Adicionemos Structuras y definiciones
Cree una carpeta llamda **Define** y adiciones un archivo Llamado **CreditCardDefine.cs** para agregar los tipos de resultados de la validacion así:

```csharp
using System;

namespace NetBank.Api.Define
{
   public enum ValidationResultType 
   {
      Ok,
      BadRequest,
      NotFound,
      InternalServerEror
   }
}
```

## Adicionemos los servicios
Crre una nueva carpeta llamada **Services** y adicione alli un nuevo archivo llamado **CrediCardServices.cs**, para que implementemos la logica de Validacion así:

```csharp
using System;
using System.Text.RegularExpressions;
using System.Text.Json;
using NetBank.Api.Models;
using NetBank.Api.Define;
using System.IO;
using System.Collections.Generic;
using NetBank.Api.Utilities;

namespace NetBank.Api.Services
{
   public class CreditCardService
   {
      private const string NUMBER_REGEX = "^[0-9]*$";
      private List<IssuingNetworkData> IssuingNetworkDataList = LoadIssuingNetworkData();
      
      public CreditCardResult Result { get; set; }


      public ValidationResultType Validate(string creditCardNumber)
      {
         if (!IsNumber(creditCardNumber))
         {
            Result = BadRequetResult();
            return ValidationResultType.BadRequest;
         }

         string issuingNetwork = GetIssuingNetworkName(creditCardNumber);

         if(issuingNetwork is null)
         {
            Result = NotFoundResult();
            return ValidationResultType.NotFound;
         }

         Result = new CreditCardResult( issuingNetwork, CreditCardValidator.IsValid(creditCardNumber));
         return ValidationResultType.Ok;

      }

      private static List<IssuingNetworkData> LoadIssuingNetworkData()
      {
         StreamReader r = new StreamReader("IssuingNetworkData.json");
         string jsonString = r.ReadToEnd();
         return JsonSerializer.Deserialize<List<IssuingNetworkData>>(jsonString);
      }

      private static bool IsNumber(string creditCardNumber)
      {
		  if(string.IsNullOrEmpty(creditCardNumber))
			  return false;
		  
         return new Regex(NUMBER_REGEX).IsMatch(creditCardNumber);
      }	

      private string GetIssuingNetworkName(string creditCardNumber)
      {
         string issuingNetworkName = null;

         foreach (var issuingNetworkItem in IssuingNetworkDataList)
         {
            if(IsValidStartsWithNumbers(issuingNetworkItem.StartsWithNumbers, creditCardNumber))
               return issuingNetworkItem.IssuingNetworkName;

            if(IsValidInRange(issuingNetworkItem.InRange, creditCardNumber))
               return issuingNetworkItem.IssuingNetworkName;
         }

         return issuingNetworkName;
      }

      private bool IsValidInRange(RangeNumber inRange, string creditCardNumber)
      {
         if (inRange is null)
            return false;
         
         string startsWithNumberToValid = string.Empty;
         int startsWithNumberItemLength = 0;

         for (int i = inRange.MinValue; i <= inRange.MaxValue; i++)
         {
            startsWithNumberToValid = i.ToString();
            startsWithNumberItemLength = startsWithNumberToValid.Length;

            if(creditCardNumber.Substring(0, startsWithNumberItemLength).Equals(startsWithNumberToValid))
               return true;
         }
         return false;
      }

      private bool IsValidStartsWithNumbers(List<int> startsWithNumbers, string creditCardNumber)
      {
         if(startsWithNumbers.Count == 0)
            return false;

         string startsWithNumberToValid = string.Empty;
         int startsWithNumberItemLength = 0;

         foreach (var startsWithNumberItem in startsWithNumbers)
         {
            startsWithNumberToValid = startsWithNumberItem.ToString();
            startsWithNumberItemLength = startsWithNumberToValid.Length;

            if(creditCardNumber.Substring(0, startsWithNumberItemLength).Equals(startsWithNumberToValid))
               return true;
         }

         return false;
      }

      private CreditCardResult BadRequetResult()
      {
         return new CreditCardResult("Bad Request", false);
      }

      private CreditCardResult NotFoundResult()
      {
         return new CreditCardResult("Not Found", false);
      }

   }
}
```



## Agregar los Servicios al Scope
Agregar la siguiente Linea a nivel del StartUp en la API y adicionar la referencia a lo servicios en la seccion de los Using. <br>

Adiconar la libreria
```csharp
using NetBank.Api.Services;
```
<br>
Adicionar el servicio al scope

```csharp
public void ConfigureServices(IServiceCollection services)
{

      services.AddControllers();
      services.AddSwaggerGen(c =>
      {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "NetBank.Api", Version = "v1" });
      });

      // Adicionar el Servicio al Scope
      services.AddScoped<CreditCardService>();
}
```

## Actualicemos el Controller
A nivel del controlador realice los cambios para realizar el llamdo de los servicios así:

```csharp
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetBank.Api.Define;
using NetBank.Api.Models;
using NetBank.Api.Services;

namespace NetBank.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreditCardController : ControllerBase
    {
        private readonly ILogger<CreditCardController> _logger;
        private readonly CreditCardService _creditCardService;
        public CreditCardController(CreditCardService creditCardService, ILogger<CreditCardController> logger)
        {
            _logger = logger;
            _creditCardService = creditCardService;
        }

        [HttpGet("{creditcardNumber}")]
        public IActionResult Get(string creditcardNumber)
        {
            var validateResult = _creditCardService.Validate(creditcardNumber);
            var result = _creditCardService.Result;

            switch (validateResult)
            {
                case ValidationResultType.Ok:
                    return Ok(result);     
                case ValidationResultType.BadRequest:
                    return BadRequest(result);     
                case ValidationResultType.NotFound:
                    return NotFound(result);     
                default:
                    return StatusCode(StatusCodes.Status500InternalServerError, new CreditCardResult("Internal Server Error", false));
            }
        }
    }
}

```
