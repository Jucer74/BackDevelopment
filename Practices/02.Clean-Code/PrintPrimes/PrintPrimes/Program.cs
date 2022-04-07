using System;

namespace PrintPrimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintPrimes(13);
            // 2,3,5,7,11,13
            PrintPrimes(10);
            // 2,3,5,7
            PrintPrimes(0);
            // Error: Invalid numero
            PrintPrimes(1);
            // Error: 1 Is not Prime

        }
        static void PrintPrimes(int numero)
        {

            Console.WriteLine(ObtenerPrimes(numero));

        }

        public static string ObtenerPrimes(int numero)
        {

          
            string imprimerPrimo = "";

            if (numero == 0)
            {
                Console.WriteLine("Error : Invalid numero");
            }

            if (numero == 1)
            {
                Console.WriteLine("Error : 1 Is not Prime");
            }

            for (int i = 1; i <= numero; i++)
            {

                if (EsPrimo(numero))
                {

                    imprimerPrimo += i.ToString() + ",";
                }
            }
            return imprimerPrimo;
        }

        static bool EsPrimo(int numero)
        {

            {
                for (int numeroPrimo = 2; numeroPrimo < numero; numeroPrimo++)
                {
                    if ((numero % numeroPrimo) == 0)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

    }
}



