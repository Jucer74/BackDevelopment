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

# Implementemos
Dentro del Directorio de practica de esta seccion y en una ventana terminal o ventna de comandos ejecute la siguiente sentencia:

```csharp
dotnet new webapi --framework "Net5.0" --name "NetBank.Api"
```