﻿/// <summary>
/// Un número “ordenado” es un entero en base 10, sin cero a la izquierda, tiene todos sus dígitos ordenados en orden ascendente. 
/// Ejemplos: 9, 234, 888, 1578 y 113399 son algunos números que cumplen esta propiedad
/// A diferencia de 30, 432, 596 and 88881 que NO cumplmen con la condicion de estar ordenados
/// 
/// Se requiere un algoritmo que, dado un número N, encuentre el mayor número “Ordenado” presente menor a N, 
/// utilizando operaciones matematicas.
///
/// Ejemplo: 
/// N=3, Último número “ordenado”: 2.
/// N=20, Último número “ordenado”: 19.
/// N=132, Último número “ordenado”: 129.
/// N=1000, Último número “ordenado”: 999.
/// 
/// Límites:
/// 1 ≤ N ≤ 1000000
/// </summary>
using System;

public class Program
{

    public static void Main()
    {
        PrintMajorSortedNumber(3);
        // 3 -> 2
        PrintMajorSortedNumber(10);
        // 10 -> 9
        PrintMajorSortedNumber(20);
        // 20 -> 19
        PrintMajorSortedNumber(132);
        // 132 -> 129
        PrintMajorSortedNumber(1000);
        // 1000 -> 999
        PrintMajorSortedNumber(0);
        // Error: The Input Number [0] must be between 1 and 1,000,000
        PrintMajorSortedNumber(1000001);
        // Error: The Input Number [1000001] must be between 1 and 1,000,000
    }

    private static void PrintMajorSortedNumber(int inputNumber)
    {
        // TODO: Complete the code
    }
}