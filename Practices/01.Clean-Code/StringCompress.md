# Proyecto-03: Comprimir Cadenas
Implemente un método para realizar la compresión básica de cadenas utilizando el recuento de caracteres repetidos. Por ejemplo, la cadena aabcccccaaa se convertiría en a2b1c5a3. Si la cadena "comprimida" no fuera más pequeña que la cadena original, su método debería devolver la cadena original.

# Ejemplos
input=aabbcccccaaaa , ouput=a2b1c5a3 <br>
input=qwwweeerrtyyyy, output=q1w3e3r2t1y4 <br>
input=abcd, output = abcd <br>
input=a, output=a <br>
input=mmnnllpptt, output=mmnnllpptt <br>
input=OOOoooXXXxxxx, output=O3o3X3x3 <br>

    
# Requisitos
1. Escriba el codigo teniendo en cuenta los conceptos de :
	- Programación Orientada a Objetos (OOP)
	- Clean Code
	- Refactoring 
	- Complejidad ciclomatica
	- Patrones y buenas practicas de programacion
	- Codigo Testeable
2. Utilice como base el codigo de la solución del proyecto

# Condiciones
1. El cadena de entrada debe ser ingresado por teclado
2. La cadena de entrada solo permite letras [A-Za-z]
3. La longitud de la cadena debe ser mayor a cero y menor a 256 caracteres
4. Los caracteres se diferencian por mayusculas o minusculas (Case Sensitive)
5. la firma de la funcion principal no debe cambiar (PrintStringCompressed)


## Ejemplo de ejecución

### Ejecución corecta: Cadena Comprimida

    Comprimir cadena
    ================
    Ingrese la cadena= aaabbbcccccddd
    Resultado= a3b3c5d3

### Ejecución corecta: Cadena sin comprimir

    Comprimir cadena
    ================
    Ingrese la cadena= aabbccdd
    Resultado= aabbccdd

### Entrada Incorrecta: Cadena vacia 

    Comprimir cadena
    ================
    Ingrese la cadena=
    Error!!!: La longitud de la cadena ingresada debe ser mayor a cero y menor que 256



### Entrada Incorrecta: Cadena vacia 

    Comprimir cadena
    ================
    Ingrese la cadena=aaaaaaaaa....aaaaa (mas de 256 caracteres)
    Error!!!: La longitud de la cadena ingresada debe ser mayor a cero y menor que 256

### Entrada Incorrecta: Cadena con carcteres no validos 

    Comprimir cadena
    ================
    Ingrese la cadena= a1b1c1
    Error!!!: La cadena ingresada solo debe contener letras [A-Z,a-z] 
