/// <summary>
/// Implemente un método para realizar la compresión básica de cadenas utilizando el recuento de caracteres repetidos.
/// Criterios de Aceptación:
/// - la cadena aabcccccaaa se convertiría en a2b1c5a3.
/// - Si la longitud de la cadena "comprimida" es mayor la longitud de la cadena original, su método debería devolver la cadena original.
/// - La cadena no puede ser nula o vacia
/// - La longitud de la cadena debe ser menor o igual a 255 caracteres
/// - La cadena solo debe permitir caracteres alfabeticos ([A-Z,a-z])
/// - Los caracteres se diferencian por mayusculas o minusculas (Case Sensitive)
/// </summary>

using System;

namespace Parcial01
{
   public class Program
   {
      public static void Main(string[] args)
      {
        
        //Console.WriteLine(Compress(""));
        // Error: the string must not be null or empty
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
      }

      static string Compress(string input)
      {
        int StringSize = input.Length;
            string CompressionResult = "";
            int MAX_LENGTH = 100;
            char CompareChar = input[0];
            int Repetitions = 0;

            if (input.Length>MAX_LENGTH){
                Console.WriteLine("Error: The length of the string must be less than 255 characters.");
            }

            if (!IsAlpabethic(input)){
                Console.WriteLine("Error: Only alphabetic characters [A-Z,a-z] are allowed");
            }
            else{
                for (int Position = 0; Position < StringSize; Position++){
                if (CompareChar == input[Position]){
                    Repetitions += 1;
                }
                else{ 
                    CompressionResult += CompareChar;
                    CompressionResult += Repetitions.ToString();
                    if ( Position + 1 < StringSize){
                        CompareChar = input[Position];
                    }
                    else{
                        break;
                    }
                    Repetitions = 1;

                   }
                }
            }

            CompressionResult += CompareChar;
            CompressionResult += Repetitions.ToString();

            if(CompressionResult.Length<StringSize){
                return CompressionResult;
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
      }

   }