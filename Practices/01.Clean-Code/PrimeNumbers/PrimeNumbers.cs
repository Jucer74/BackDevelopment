using System;
using System.Collections.Generic;

class PrimeNumbers{

    private static int initialNumber;
    private static int finalNumber;
    private static int[] pivoteNumbers={3,5};

    private static void dataReader(){
        Console.WriteLine("Welcome to prime numbers calculator");
        Console.WriteLine("you must enter the range of numbers to find the prime number");
        bool salir=true;
        do{
            Console.WriteLine("enter the initial number for calculation");
            int initialNumberOut;
            salir=int.TryParse(Console.ReadLine(), out initialNumberOut);
            initialNumber=initialNumberOut;
        } while(!salir);
        do{
            Console.WriteLine("enter the final number for calculation");
            int finalNumberOut;
            salir = int.TryParse(Console.ReadLine(),out finalNumberOut);
            finalNumber=finalNumberOut;
        } while(!salir);
    }

    private static bool isPrimeNumber(int numberToTest){
        int divisors = 0;
        for(int i = 1; i<=(numberToTest/2); i++){
            if(numberToTest%i==0){
                divisors++;
            }
        }
        return divisors==1;
    }

    private static bool isMultipleOf(int numberToTest, int pivoteNumber) {
        return numberToTest%pivoteNumber==0;
    }
    
    private static List<string> getPrimeNumberList(){
        List<string> primeNumbers=new List<String>();
            for(int i=initialNumber; i<=finalNumber;i++) {
                if(isPrimeNumber(i)){
                    string primeNumberToAppend="M";
                    foreach (int pivoteNumber in pivoteNumbers){ 
                        if(isMultipleOf(i, pivoteNumber)){
                           primeNumberToAppend+="-"+pivoteNumber;
                        }
                    }
                    if(primeNumberToAppend=="M"){
                        primeNumberToAppend=i.ToString();
                    }
                    primeNumbers.Add(primeNumberToAppend);
                }
            }
        return primeNumbers;
    }

    private void calculatePrimeNumbers(){
        string exitInput="";
        do{
            //LEEMOS LOS DATOS DE ENTRADA
            dataReader();
            //HACEMOS EL CÁLCULO
            List<string> primeNumbers = getPrimeNumberList();
            //MOSTRAMOS LA SALIDA
            dataWriter(primeNumbers);
            
            do{
                Console.WriteLine("Do you want calculate again? Y/N");
                exitInput = Console.ReadLine();
            } while(!(exitInput=="Y" || exitInput=="N"));
            
        } while(exitInput=="Y");
        Console.WriteLine("Good bye");
    }

    private static void dataWriter(List<string> data){
        string dataToShow="";
        for(int i=0;i<data.Count;i++){
            dataToShow+= i<data.Count-1 ? data[i]+"," : data[i];
        }
        Console.WriteLine(dataToShow);
    }


    public static void Main (string[] args){
        PrimeNumbers primeNumbers=new PrimeNumbers();
        primeNumbers.calculatePrimeNumbers();
    }

}