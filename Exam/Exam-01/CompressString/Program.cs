using System;

namespace CompressString
{
   public class Program
   {
      public static void Main(string[] args)
      {
        Console.Clear();
        
        Console.WriteLine(Compress("aabcccccaaa"));
        // aabcccccaaa => a2b1c5a3
        Console.WriteLine(Compress("XXXoooxxxOOO"));
        // XXXoooxxxOOO => X3o3x3O3
        Console.WriteLine(Compress("abbcca"));
        // abbcca => abbcca
        Console.WriteLine(Compress("aabbcc"));
        // aabbcc => aabbcc
        Console.WriteLine(Compress("X".PadRight(256, 'X')));
        // Error: The length of the string must be less than 255 characters.
        Console.WriteLine(Compress("a1b2c5a3"));
        // Error: Only alphabetic characters [A-Z,a-z] are allowed
        Console.WriteLine(Compress(""));
        // Error: the string must not be null or empty
      }

      static string Compress(string input)
      {
        int TamañoCadena = input.Length;
            string ResultadoComprension = "";
            int MAX_LENGTH = 15;
            char CompararLetra = input[0];
            int Repeticiones = 0;

            


            if (input.Length>MAX_LENGTH){
                Console.WriteLine("Error: The length of the string must be less than 255 characters.");
            }

            if (!IsAlpabethic(input)){
                Console.WriteLine("Error: Only alphabetic characters [A-Z,a-z] are allowed");
            }
            else{
                
                for (int Posicion = 0; Posicion < TamañoCadena; Posicion++){
                if (CompararLetra == input[Posicion]){
                    Repeticiones += 1;
                }
                else{
                    
                    ResultadoComprension += CompararLetra;
                    
                    ResultadoComprension += Repeticiones.ToString();
                    if ( Posicion + 1 < TamañoCadena){
                        CompararLetra = input[Posicion];
                    }
                    else{
                        break;
                    }
                    Repeticiones = 1;

                   }
                }
            ResultadoComprension += CompararLetra;
            Console.WriteLine(""+input+"=>");
            ResultadoComprension += Repeticiones.ToString();

            }

            if (ResultadoComprension==""){
                Console.WriteLine("Error: the string must not be null or empty");
            }

            if(ResultadoComprension.Length<TamañoCadena){
                return ResultadoComprension;
            }
            else{
                return input;
            }


        }
        public static bool IsAlpabethic(string input){
          string lowerString = input.ToLower();
          foreach (var character in lowerString)
          {
              if(!Char.IsLetter(character)){
                  return false;
              }
          }
          return true;
         }
        /* public static bool IsNullOrEmpy(string input){
            string s="";
            return"is null or empy";
        } */
      }

   }
