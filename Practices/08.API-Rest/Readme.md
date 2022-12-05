# API Rest
Una API es la forma en como se pueden integrar dos o mas aplicaciones y su uso en Web se conoce como WebApi, que se base en estilo Arquitectonico denominado REST, que a su vez utiliza los siguientes verbos como base para efectuar las operaciones.

- **GET**: para Obtener datos, similar al **SELECT** de la base de datos
- **POST**: para enviar informacion o ejecutar un comando, es similar a un **INSERT** de la base de datos
- **PUT**: para actualizar informacion, es similar a un **UPDATE** de base de datos
- **DELETE**: para eliminar informacion y es similar al mismo comando **DELETE** de la base de datos.

REST (Representational State Transfer) se base principalmente en el protocolo HTTP, por lo cual se hace necesario el uso de HTTP Status Codes para complementar la infromacion retornada por las peticiones hechas a la API.

Estos son algunos de los Status Codes mas utilizados

| **StatusCode** | **Descripcion**        | **Notas**                                                                                                                                                         |
|----------------|------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 200            | OK                     | La peticion fue procesada satisfactoriamente                                                                                                                      |
| 400            | Bad request            | Normalmente, este código significa que la solicitud contiene secuencias o caracteres no válidos, o que la solicitud va en contra de la configuración de seguridad |
| 404            | Not found.             | Devuelto cuando un recurso no existe en el servidor                                                                                                               |
| 500            | Internal server error. | Este código de estado puede ocurrir por muchas razones del lado del servidor.                                                                                     |

Ve las lista completa [aqui](https://docs.microsoft.com/en-us/troubleshoot/developer/webapps/iis/www-administration-management/http-status-code)

# Rest API Workshop
Desarrolle una API, llamada **NetBank.Api**, y cree un controlador (**CreditCardController**) para validar si una tarjeta de credito es valida y a que franquicia o Red emisora pertenece.

## API-Contract

**GET** : /api/v1/CreditCard/{creditcardNumber}

Tipos de Respuestas:

**ValidationSuccess**
Ok - Status Code: 200
Si el Numero de la tarjeta es correcto y se identifica la red emisora

```json
{
	"issuingNetwork" : "Visa",
	"Valid" : true
}
```

**ValidationFails**
Ok - Status Code: 200
Si el Numero de la tarjeta NO es correcto (por digito o por longitud) pero SI se identifica la red emisora

```json
{
	"issuingNetwork" : "Visa",
	"Valid" : false
}
```

**BadRequest**
BadRequest - Status Code: 400
Si lo que se recibe como numero de tarjeta no es un conjunto de numeros

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

Para Obtener y validar la Franquicia o Red Emisora puede utilizar la siguiente tabla:

| Franquicia o Red Emisora    | Inicia con ( o en el rango )                             | Longitud (Num. de Digitos)  |
|-----------------------------|----------------------------------------------------------|-----------------------------|
| American Express            | 34, 37                                                   | 15                          |
| Diners Club                 | 300, 301, 302, 303, 304, 305                             | 14                          |
| Diners Club - International | 36                                                       | 14                          |
| Discover                    | 6011, 622126-622925, 644, 645, 646, 647, 648, 649, 65    | 16-19                       |
| InstaPayment                | 637, 638, 639                                            | 16                          |
| JCB                         | 3528-3589                                                | 16-19                       |
| Maestro                     | 5018, 5020, 5038, 5893, 6304, 6759, 6761, 6762, 6763     | 16-19                       |
| MasterCard                  | 51, 52, 53, 54, 55, 222100 to 272099                     | 16                          |
| Visa                        | 4                                                        | 16-19                       |
| Visa Electron               | 4026, 417500, 4508, 4844, 4913, 4917                     | 16                          |


Para validar una tarjeta utlice el algoritmo de [Luhn](https://en.wikipedia.org/wiki/Luhn_algorithm)
  
Para realizar pruebas utilice el siguiente [Generador](https://www.freeformatter.com/credit-card-number-generator-validator.html)

# Proyecto
Use el Proyecto **NetBank.Api** como punto inicial, y adicione los componentes necesarios para implementar la solucion.

## Condiciones
- Distribuya la logica en los componentes necesarios para completar la aplicacion, usando servicios y utilidades para ser utlizadas 

## Calificacion
- No tiene Errores Ni Warnings = (0.5)
- No tiene Codigo Innecesario = (0.5)
- Funciona y Cumple con el Objetivo = (1.5)
- El codigo Es Entendible = (1.0)
- Cumple con el Codigo Limpio = (1.5)

## Guias y Practicas de Clean Code
Los Nombres de las variables y Funciones: 

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
- Son pequeñas y su logica esta bien separada?
- Las Funciones hacen una sola cosa?
- Tieen Logica de Retorno directo y correcto o hay If para retornar
- No Existen Multiples If anidados o SI hay instrucciones Switch

# Proceso
Genere su rama utilizando la siguiente nomenclatura:
- 3 primeras letras de su primer nombre
- 3 primeras letras de primer apellido
- 3 primeras letras de su segundo apellido.

**Ejemplo:**</br>
Si el nombre es Julio Cesar Robles Uribe , el Nombre de su rama seria **julroburi**

