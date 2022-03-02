using System;

namespace PrinMultiples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("|"+"~~~~~~~~~~~~~~~~~~~~"+"|"+"~~~~~~~~~~~~~~~"+"|");
            Console.WriteLine("|"+"Numeros Del 1 al 100"+"|"+"Multiplos 3 o 5"+"|");
            Console.WriteLine("|"+"~~~~~~~~~~~~~~~~~~~~"+"|"+"~~~~~~~~~~~~~~~"+"|");

            PrinMultiples(100);
        }
    
        private static void PrinMultiples(int MaxNumber){
            for (int Number=1;Number<=MaxNumber;Number++){
                
                    if(Number%15==0){
                        Console.WriteLine("Numero: "+Number+"|"+" M-3-5"+"|");
                    }
                    else if(Number%5==0){
                        Console.WriteLine("Numero: "+Number+"|"+" M-5"+"|");
                    }
                    else if(Number%3==0){
                        Console.WriteLine("Numero: "+Number+"|"+" M-3"+"|");
                    }
                    else{
                        Console.WriteLine("Numero: "+Number+"|");
                    }
            }
        }
    }
}
