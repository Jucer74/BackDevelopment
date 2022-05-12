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

```json
{
	"issuingNetwork" : "Visa",
	"Valid" : true
}
```

**BadRequest**

BadRequest - Status Code: 400

```json
{
	"issuingNetwork" : "Bad REquest",
	"Valid" : false
}
```

**Not Found**
NotFoud -  Status Code: 404

```json
{
	"issuingNetwork" : "Not Found",
	"Valid" : false
}
```

**Inernal Server Error**
InernalServerError - Status code: 500

```json
{
	"issuingNetwork" : "Internal Server Eror",
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
| MasterCard                  | 51, 52, 53, 54, 55, 222100-272099                        | 16                          |
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpGet]
        public IActionResult Get()
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


![](https://github.com/Jucer74/BackDevelopment/blob/main/Practices/08.API-Rest/Img/NetBank.Api-01.png)

