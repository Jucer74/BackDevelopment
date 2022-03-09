# Evaluación Teórica (40%)
Responda las preguntas del siguiente Enlace:

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
RECUERDE SUBIR SU SOLUCIÓN A SU RAMA DEL REPOSITORIO.