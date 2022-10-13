# Evaluación Teórica (40%)
Responda las preguntas del siguiente Enlace:

[Examen](https://forms.gle/NSrS5Xy1EnRRM3Pr5)

# Ejercicio (60%)
Utilizando los conocimientos adquiridos en clase, desarrolle el siguiente ejercicio.

# Contexto
**NetBank** es una empresa reguladora de tarjetas de credito a la cual todos los bancos le reportan las tarjetas robadas.

# Ejercicio
Implemente una applicacion que permita :

1. Obtener la lista de todas las tarjetas
2. Obtener la lista de las tarjetas por la red emisora
3. Obtener los datos de la tarjeta por su numero
4. Reactivar una tarjeta, marcandola como recuperada (Recovered)
5. Validar si el Numero de una tarjeta es valido por su codigo de verificacion.

## Reglas
Revise este [link](https://www.freeformatter.com/credit-card-number-generator-validator.html) par determinar lsa condiciones sobre los tipos de tarjetas.

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

[Algoritmo de Luhn en C#](https://github.com/marcrabadan/blog/tree/main/luhn/LuhnAlgorithm)
    
# Requisitos
1. Escriba el codigo teniendo en cuenta los conceptos de Clean Code
2. Utilice como base el codigo de la solución del proyecto **CheckDate**

# Observaciones
RECUERDE SUBIR SU SOLUCIÓN A SU RAMA DE ESTE REPOSITORIO.

# Nota (0.0)
- No tiene Errores Ni Warnings            = (0.5) 
- No tiene Codigo Innecesario             = (0.5)
- Funciona y Cumple con el Objetivo       = (1.5) 
- El codigo Es Entendible                 = (1.0)
- Cumple con el Codigo Limpio             = (1.5) 

## Guis y Practicas de Clean Code
  Los Nombres de las variables y Funciones: (0.1/ cada una)
  - Revelan la intencion, es decir se sabe que hacen o que almacenan? = OK
  - Los Nombres son claros o son confusos?                            = OK
  - Son Pronunciables                                                 = OK
  - Son buscables (Numero Magicos o No hay Constantes)?               = OK
  - tiene notaciones innecesarias IntCodigo, strData) ?               = OK
  - Usan Sustantivos para Clases y Verbos para Metodos?               = OK
  - Una sola palabra por concepto?                                    = OK
  - No usan combinaciones o juegos de palabras?                       = OK
  - No tiene contexto adicional o superfluo?                          = OK
  - Usan Datos del dominio, del negocio, problema o solucion ?        = OK
  - Cumplen con el Estandar de Pascal y Camel Case?                   = OK
  Las Funciones                                                         
  - Son pequeñas y su logica esta bien separada?                      = OK
  - Las Funciones hacen una sola cosa?                                = OK
  - Tieen Logica de Retorno directo y correcto o hay If para retornar = OK
  - No Existen Multiples If anidados o SI hay instrucciones Switch    = OK
