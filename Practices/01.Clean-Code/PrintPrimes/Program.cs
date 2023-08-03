// Main
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
            Console.Write(i);
            if(i + 2 <= limit + 2)
            {
                Console.Write(",");
            }            
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