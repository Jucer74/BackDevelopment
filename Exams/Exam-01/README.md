# Evaluación Teórica (40%)
Responda las preguntas del siguiente Enlace:

[Examen](https://forms.gle/EjjvZniwsb6iXCgE7)

# Evaluación Práctica (60%)

**Mayor Ordenado**
Un número “ordenado” es un entero en base 10, sin cero a la izquierda, tiene todos sus dígitos ordenados en orden ascendente. 

Estos son algunos Numeros Ordenados: 9, 234, 888, 1578  y 113399. 
Y estos son algunos números que no cumplen esta propiedad: 30, 432, 596 y 88881.
 
Se requiere un algoritmo que, dado un número N, encuentre el mayor número “Ordenado” presente menor a N, 
**utilizando operaciones matematicas**.


# Ejemplos
Dados el Numero **N**, deberiamos obtener el Mayor Ordenado (**MO**) 

**N**=8, **MO**=8<br>
**N**=20, **MO**=19<br>
**N**=132, **MO**=129<br>
**N**=1000, **MO**=999<br>
**N**=1974, **MO**=1899<br>
**N**=1000000, **MO**=999999<br>


# Requisitos
1. Escriba el codigo teniendo en cuenta los conceptos de :
	- Programación Orientada a Objetos (OOP)
	- Clean Code
	- Refactoring 
	- Complejidad ciclomatica
	- Patrones y buenas practicas de programacion
	- Codigo Testeable
2. Utilice como base el codigo pasado en este directorio

# Condiciones
1. El Numero N debe ser mayor o igual a 1 y menor o igual a 1000000
2. El Numero N debe ser ingresado por teclado y validado como numero entero
3. la firma de la funcion principal no debe cambiar (PrintGreaterNumberSorted)
4. La salida debe ser por consola en el formato: N -> MO

# Ejemplos de la Ejecucion

PrintMajorSortedNumber(3);
3 -> 2

PrintMajorSortedNumber(10);
10 -> 9

PrintMajorSortedNumber(20);
20 -> 19

PrintMajorSortedNumber(132);
132 -> 129

PrintMajorSortedNumber(1000);
1000 -> 999

PrintMajorSortedNumber(0);
Error: The Input Number [0] must be between 1 and 1,000,000

PrintMajorSortedNumber(1000001);
Error: The Input Number [1000001] must be between 1 and 1,000,000
