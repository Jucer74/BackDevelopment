// imprimir numeros del 1 al 100 pero escribir M-3 multiplos de 3, M-5 numeros de 5 y M-3-5 multiplos de ambos
using System;

namespace PrimtMultiples
{
    internal class Name
    {
        static void Main(string[] args)
        {
            countNumbers();
        }

        private static void countNumbers()
        {
            for (int currentNumber = 1; currentNumber <= 100; currentNumber++)
            {
                if (isMultipleOf(currentNumber, 3) || isMultipleOf(currentNumber, 5) || 
                (isMultipleOf(currentNumber, 3) && isMultipleOf(currentNumber, 5)))
                {   
                    if (isMultipleOf(currentNumber, 3) && isMultipleOf(currentNumber, 5))
                    {
                        Console.Write("M-3-5");   
                    }else
                    {
                        if (isMultipleOf(currentNumber, 3))
                        {
                            Console.Write("M-3");   
                        }
                        if (isMultipleOf(currentNumber, 5))
                        {
                            Console.Write("M-5");   
                        }
                    }
                }
                else
                {
                    Console.Write(currentNumber);
                }
                if (currentNumber<100)
                {   
                    Console.Write(", ");
                }
            }

        }
        // encontrar multiplos de 
        private static bool isMultipleOf(int currentNumber, int baseNumber)
        {
            return currentNumber % baseNumber == 0;
        }



    }

}

