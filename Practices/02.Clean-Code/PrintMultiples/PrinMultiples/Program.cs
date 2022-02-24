using System;

namespace PrinMultiples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Del 1 al 100");
            for (int x=1;x<=100;x++){
               
                if(x%15==0){
                    Console.WriteLine("Numero: "+x+" M-3-5");
                }
                else if(x%5==0){
                     Console.WriteLine("Numero: "+x+" M-5");
                }
                else if(x%3==0){
                    Console.WriteLine("Numero: "+x+" M-3");
                }
                else{
                     Console.WriteLine("Numero: "+x);
                }
            }
        }
    }
}
