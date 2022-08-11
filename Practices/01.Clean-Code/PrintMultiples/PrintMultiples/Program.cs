/*
 * Write a program (C#) that prints the numbers from 1 to 100. 
 * But for multiples of three print “M-3” instead of the number and 
 * for the multiples of five print “M-5”. 
 * For numbers which are multiples of both three and five print “M-3-5”
 * */
using System;

namespace PrintMultiples
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++)
            {

                if(i % 3 == 0 & i % 5 == 0)
                {
                    Console.Write("M-3-5");
                }
                else if(i % 3 == 0)

                {
                    Console.Write("M-3");
                }
                else if (i % 5 == 0)
                {
                    Console.Write("M-5");
                }
                else
                {
                    Console.Write(i);
                }

            }

        }
    }
}
