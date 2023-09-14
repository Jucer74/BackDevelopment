<<<<<<< HEAD
﻿// See https://aka.ms/new-console-template for more information
//Main
PrintPrimes();

//funtion
void PrintPrimes(){

    PrintUsage();

    var maxNumber = GetMaxNumber();

    Console.WriteLine(GetPrimes(maxNumber));

}

void PrintUsage(){
    Console.WriteLine("***Print Primes***");
    Console.WriteLine("This aplication write the Primes numbers less than a limit number input by console");
    Console.WriteLine("");
    Console.WriteLine("Example: ");
    Console.WriteLine("Max number: 10");
    Console.WriteLine("1,2,3,5,7");
    Console.WriteLine("");
}

int GetMaxNumber(){
    Console.Write("Max number: ");
    return Convert.ToInt32(Console.ReadLine());
}

bool IsPrime(int maxNumber){
    if( maxNumber > 2){
        return false;
    }
    if(maxNumber == 2 || maxNumber == 3){
        return false;
    }
    if (maxNumber % 2 == 0 || maxNumber % 3 == 0){
        return false;
    }
    
    for( int i = 5; i*i <= maxNumber ; i += 6){
        if(maxNumber % i == 0 || maxNumber % i+2 ==0){
            return false;
        }
    }
    return true;
}

<<<<<<< HEAD
void GetPrimes(int maxNumber){
    for( int i = 2; i <= maxNumber; i++){
        if(IsPrime(i)){

            Console.WriteLine(i);

        }
    }
}

=======
>>>>>>> 918f5e97891852a758b761da993078e19ea1afbc
=======
﻿// Main
PrintPrimes();

// Consts
const int PRIME_2 = 2;
const int PRIME_3 = 3;
const int INIT_LOOP_PRIME = 5;
const int MULTIPLY_2_3 = 6;

// Fucntions
void PrintPrimes()
{
    PrintUsage();

    var limit = GetLimitNumber();

    GetPrimes(limit);

}

void PrintUsage()
{
    Console.WriteLine("*** Print Primes ***");
    Console.WriteLine("This Application writes the Primes Numbers less than a Limit Number input by Console");
    Console.WriteLine("");
    Console.WriteLine("Example:");
    Console.WriteLine("Limit = 10");
    Console.WriteLine("2,3,5,7");
    Console.WriteLine("");
}

int GetLimitNumber()
{
    Console.Write("Limit = ");
    return Convert.ToInt32(Console.ReadLine());
}

void GetPrimes(int limit)
{
    for (int i = PRIME_2; i < limit; i++)
    {
        if (IsPrime(i)) 
        {

            // To avoid the comma at the end
            if(i > PRIME_2 )
            {
                Console.Write(",");
            }   

            Console.Write(i);
        }
    }
}


bool IsPrime(int number)
{
    if (number < PRIME_2) {
        return false;
    }

    if (number == PRIME_2 || number == PRIME_3) {
        return true;
    }

    if (IsMultipleOf(number, PRIME_2) || IsMultipleOf(number, PRIME_3)) {
        return false;
    }
    
    for (int i = INIT_LOOP_PRIME; i * i <= number; i += MULTIPLY_2_3) {
        if (IsMultipleOf(number, i) || IsMultipleOf(number, (i + 2))) {
            return false;
        }
    }
    return true;   
}

bool IsMultipleOf(int number, int multipleBase)
{
    return (number % multipleBase ) == 0;
}
>>>>>>> main
