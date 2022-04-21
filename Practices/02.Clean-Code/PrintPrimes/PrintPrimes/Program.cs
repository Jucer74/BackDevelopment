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
      // Error: Invalid Number
      PrintPrimes(1);
      // Error: 1 Is not Prime

    }

    private static void PrintPrimes(int number)
    {
      int num=0,divisible=0;

      while(num<=number)
      {
        for(int i=1; i<=number;i++){

          if(num%i==0){
            divisible++;
          }

          
        }
        if(divisible==2){
          Console.WriteLine(num + ", ");
        }


        divisible=0;
        num++;

      }


        if(number==0){
          Console.WriteLine("Error : Invalid Number");
        }

         if(number==1){
          Console.WriteLine("Error : 1 Is not Prime");
        }

      //Console.WriteLine(i + " , ");
    }
  }
}
