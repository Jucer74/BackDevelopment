using System;
using System.Collections.Generic;
using System.Text;

class PrimeNumbers{

    private static int finalNumber;
    private static readonly int INIT_LOOP_PRIME=5;
    private static readonly int INIT_LOOP_PRIME_INCREASE=6;
    private static readonly int MIN_PRIME_2=2;
    private static readonly int MIN_PRIME_3=3;

    private static void DataReader(){
        Console.WriteLine("Welcome to prime numbers calculator");
        bool salir;
        do{
            Console.WriteLine("enter the final number for calculation");
            salir = int.TryParse(Console.ReadLine(), out int finalNumberOut);
            finalNumber =finalNumberOut;
        } while(!salir);
    }

    private static bool IsDivisibleFor(int numberToTest, int divisor){
        return numberToTest%divisor==0;
    }

    private static bool IsPrimeNumber(int numberToTest){

        if (numberToTest <= 1)
        {
            return false;
        }

        if (numberToTest == MIN_PRIME_2 || numberToTest == MIN_PRIME_3)
        {
            return true;
        }

        if (numberToTest % MIN_PRIME_2 == 0 || numberToTest % MIN_PRIME_3 == 0)
        {
            return false;
        }
        for(int i=INIT_LOOP_PRIME;i*i<=numberToTest;i+=INIT_LOOP_PRIME_INCREASE){
            if(IsDivisibleFor(numberToTest,i) || IsDivisibleFor(numberToTest,i+2)){
                return false;
            }
        }
        return true;
    }
    
    private static String GetPrimeNumberList(){
            StringBuilder primeNumbers = new();
            for(int i=0; i<=finalNumber;i++) {
                if(IsPrimeNumber(i)){
                    primeNumbers.Append(i.ToString()+",");
                }
            }
        return primeNumbers.ToString().Remove(primeNumbers.Length-1);
    }

    private static void CalculatePrimeNumbers(){
        string exitInput;
        do{
            //LEEMOS LOS DATOS DE ENTRADA
            DataReader();
            //HACEMOS EL CÁLCULO
            string primeNumbers = GetPrimeNumberList();
            //MOSTRAMOS LA SALIDA
            DataWriter(primeNumbers);
            do{
                Console.WriteLine("Do you want calculate again? Y/N");
                exitInput = Console.ReadLine()!;
            } while(!(exitInput=="Y" || exitInput=="N"));
            
        } while(exitInput=="Y");
        Console.WriteLine("Good bye");
    }

    private static void DataWriter(string data){
        Console.WriteLine(data);
    }


    public static void Main (string[] args){
        CalculatePrimeNumbers();
    }

}