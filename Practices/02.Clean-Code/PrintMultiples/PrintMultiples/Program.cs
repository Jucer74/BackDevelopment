using System;

namespace PrintverificarMultiplos
{
    class Program
    {
        static  void Main(string[] args)
        {
            
                for(int numero=1; numero<=100; numero++)
                {
                
                    if(verificarMultiplos(numero) == 0)
                    {
                     Console.Write("{0}," , numero);
                    }

                    if(verificarMultiplos(numero)  == 3)
                    {
                    Console.Write("M-3,");
                    }

                    if(verificarMultiplos(numero) == 5)
                    {
                    Console.Write("M-5,");
                    }

                    if(verificarMultiplos(numero) == 1)
                    {
                    Console.Write("M-3-5,");
                    }
               }
          }
           
     
           
        public static int verificarMultiplos(int cifra)
        {
            if(cifra % 3 ==0)
            {  
                if(cifra % 5 ==0)
                {
                    return 1;
                }
                return 3;     
            }

            if(cifra % 5 ==0)
            {
                return 5;
            }

             /* if(cifra % 3 == 0 && cifra % 5 == 0)
            {
                return 1;
            }  */

            return 0;
        }
    }
}

