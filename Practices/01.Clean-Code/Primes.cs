// See https://aka.ms/new-console-template for more information
//Imprimir los numeros primos menores a un numero n
using System;

public class Program
{
    private const int NUMBER = 10;
    private const int FIRST_PRIME = 2;

    public static void Main()
    {

        for (int count = FIRST_PRIME; count <= NUMBER; count++)
        {       
            if (PrimeCheck(count))
            {
                Console.Write(count);
                if (count < NUMBER)
                {
                    Console.Write(", ");
                }
            }
        }
    }

    public static bool PrimeCheck(int currentCount)
    {
        for(int i=FIRST_PRIME; i< currentCount; i++)
        {
            if(IsMultipleOf(currentCount, i))
            {
                return false;
            }
        }
        return true;
    }

    public static bool IsMultipleOf(int number, int multipleBase)
    {
        return number % multipleBase == 0;
    }

}

