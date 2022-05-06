using System;
using System.Text;
namespace PrintPrimes
{
  internal class Program
  {
    static void Main(string[] args) {
/*
     Console.WriteLine("");
     for(int i = 1; i<= 13; i++){
     Console.WriteLine(i+ ",");
    */

           PrintPrimes(13);
            // 2,3,5,7,11,13
            Console.WriteLine("\n");
            PrintPrimes(10);
            // 2,3,5,7
            Console.WriteLine("\n");
            PrintPrimes(0);
            // Error: Invalid Number
            Console.WriteLine("\n");
            PrintPrimes(1);
            // Error: 1 Is not Prime
            Console.WriteLine("\n");

        }

        private static void PrintPrimes(int NumeroParaRecorrer)
        {    
            // recorres todos los valores hasta el máximo a Recorrer
            for (int NumeroaValidar = 0; NumeroaValidar <= NumeroParaRecorrer; NumeroaValidar++)
            {
                if (NumeroParaRecorrer <= 0){
                    Console.Write("El Numero es invalido \n");

                }

                if(NumeroParaRecorrer <= 1){

                  Console.WriteLine("Error, el número 1 no es primo \n");
                }
                else
                {

                    if (NumeroaValidar % 2 != 0)//el numero no es primo
                    {
                    
                        Console.Write(NumeroaValidar + "  \n ");
                    }
    }
  }
  }
  }
  }


  


  