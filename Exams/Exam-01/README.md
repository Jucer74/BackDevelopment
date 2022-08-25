# Evaluación Teórica (40%)
Responda las preguntas del siguiente Enlace:

[https://forms.gle/5U2iFVRoyVXRbo828](https://forms.gle/5U2iFVRoyVXRbo828 "Evaluacion Teorica")

# Ejercicio (60%)
Implemente un programa que permita validar si una cadena es una fecha valida, segun su formato y un separador determinado

## Formatos Permitidos
* dmy
* mdy
* ymd

## Separdores Permitidos
* '', Caracter vacio (\0)<br>
* '.', el punto<br>  
* '/', el Slash<br>
* '-', el guion<br>
* '_', el underscore<br> 
* ',', la comna<br>

El separador por defecto sera el sLASH ( / ), en caso de no pasarlo como parametro.

## Casos de Prueba

**CheckDate("", "dmy")** => The input can not be null or empty<br>
**CheckDate(null, "dmy")** => The input can not be null or empty <br>
**CheckDate("01/01/2001", "qwe")**=> qwe is nos a valid format date, only (dmy, mdy, ymd) are allowed<br>
**CheckDate("01/01/2001", "dmy", '!')** => ! is nos a valid separator, only (' ',  '.' ,  '/' , '-',  '_',  ',') are allowed<br>
**CheckDate("qwertyuiop", "dmy")** => The input: qwertyuiop is not a Valid Date<br>
**CheckDate("10/10/10", "dmy")** => The input: 10/10/10 is not a valid date<br>
**CheckDate("01,01,20001", "dmy")** => The input 01,01,20001 is not a valid date<br>
**CheckDate("112001", "dmy", '\0')** => The input 112001 is not a valid date<br>
**CheckDate("1012001", "dmy", '\0')** => The input 1012001 is not a valid date<br>
**CheckDate("0112001", "mdy", '\0')** => The input 0112001 is not a valid date<br>
**CheckDate("01012001", "dmy", '\0')** => The input 01012001 is not a valid date<br>
**CheckDate("08/10/1974", "dmy")** => The input: 08/10/1974 is a Valid Date<br>
**CheckDate("07-27-1996", "mdy", '-')** => The input: 27-07-1996 is a Valid Date<br>
**CheckDate("1976.04.10", "mdy", '.')** => The input: 1976.04.10 is a Valid Date<br>
**CheckDate("4.10.1976", "mdy", '.')** => The input: 4.10.1976 is a Valid Date<br>
**CheckDate("30,02,1976", "dmy", ',')** => The input: 30,02,1976 is not a Valid Date<br>
**CheckDate("31/01/1986", "mdy", '/')** => The input: 31/01/1986 is not a Valid Date<br>

## Reglas
- Las partes de la fecha deben ser numeros 
- Si el separador es vacio ('') la longitud de la fecha debe ser de 8 digitos
- La longitud maxima de la fecha es de 10 digitos con separador
- La longitud minima de la fecha es de 8 digitos con separador
- El año debe ser un numero entre 1900 y 9999
- El mes debe ser un numero entre 1 y 12
- El valor maximo del dia correspondera al maximo segun el mes ;
   - 30 para Abril, Junio, Septiembre y Noviembre
   - 28 para Febrero ( o 29 si e año es bisiesto)
   - 31 para los demas meses (Enero, Marzo, Mayo, Julio, Agosto, Octubre, Diciembre)
    
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
