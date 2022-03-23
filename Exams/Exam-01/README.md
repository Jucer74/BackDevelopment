# Evaluación Teórica (40%)
Responda las preguntas del siguiente Enlace:

[https://forms.gle/5U2iFVRoyVXRbo828](https://forms.gle/5U2iFVRoyVXRbo828 "Evaluacion Teorica")

# Ejercicio (60%)
Implemente un método para realizar la compresión básica de cadenas utilizando el recuento de caracteres repetidos. 

**Por ejemplo**, la cadena **aabcccccaaa**, se convertiría en **a2b1c5a3**. 

Si la longitud de la cadena "comprimida" es mayor que la longitud de cadena original, su método debería devolver la cadena original.

# Ejemplos
input=aabbcccccaaaa => ouput=a2b1c5a3 <br>
input=qwwweeerrtyyyy => output=q1w3e3r2t1y4 <br>
input=abcd => output = abcd <br>
input=a => output=a <br>
input=mmnnllpptt =>  output=mmnnllpptt <br>
input=OOOoooXXXxxxx => output=O3o3X3x3 <br>

    
# Requisitos
1. Escriba el codigo teniendo en cuenta los conceptos de :
	- Programación Orientada a Objetos (OOP)
	- Clean Code
2. Utilice como base el codigo de la solución del proyecto **CompressString**

# Condiciones
1. Si la longitud de la cadena "comprimida" es mayor la longitud de la cadena original, su método debería devolver la cadena original.
2. La cadena no puede ser nula o vacia
3. La longitud de la cadena debe ser menor o igual a 255 caracteres
4. La cadena solo debe permitir caracteres alfabeticos ([A-Z,a-z])
4. Los caracteres se diferencian por mayusculas o minusculas (Case Sensitive)
 


## Ejemplo de ejecución

```text
aabcccccaaa => a2b1c5a3
XXXoooxxxOOO => X3o3x3O3
abbcca => abbcca
aabbcc => aabbcc
Error: the string must not be null or empty
Error: The length of the string must be less than 255 characters.
Error: Only alphabetic characters [A-Z,a-z] are allowed
```

# Nota
RECUERDE SUBIR SU SOLUCIÓN A SU RAMA DE ESTE REPOSITORIO.

# Notas (0.0)
- No tiene Errores Ni Warnings (0.5)      = 
- No tiene Codigo Innecesario  (0.5)      = 
- Funciona y Cumple con el Objetivo (1.5) = 
- El codigo Es Entendible (1.0)           = 
- Cumple con el Codigo Limpio (1.5)       = 
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
