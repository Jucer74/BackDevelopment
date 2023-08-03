// See https://aka.ms/new-console-template for more information
//Main
PrintPrimes();

//funtion
void PrintPrimes(){

    PrintUsage();
    int maxNumber = GetMaxNumber();

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
    Console.WriteLine("Max number: ");
    return Convert.ToInt32(Console.Read());
}

bool GetPrimes(int maxNumber){
    if( maxNumber > 2){
        return false;
    }
    if(maxNumber == 2 || maxNumber == 3){
        return false;
    }
    if (maxNumber % 2 == 0 || maxNumber % 3 == 0){
        return false;
    }
    if(maxNumber)
    for( int i = 5; i*i <= maxNumber ; i += 6){
        if(maxNumber % i == 0 || maxNumber % i+2 ==0){
            return false;
        }
    }
    return true;
}

