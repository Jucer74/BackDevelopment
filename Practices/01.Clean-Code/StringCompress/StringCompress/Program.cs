namespace Comprimir.App
{
   using System.Text.RegularExpressions;
   using System;
   using System.Text;
   public class Program
   {
     #region Constants
        const int  lengthInputMax = 256;
        const string LettersContains = "[A-Z,a-z]";

        #endregion
  public static void Main()
      {
         Compress("aabcccccaaa");
         Compress("abbcca");
         Compress("XXXoooxxxOOO");
         Compress("");\u\110139680
         Compress("X".PadRight(256, 'X'));
         Compress("a1b2c5a3");
         Compress("a");

         Console.WriteLine("Por favor Ingrese la cadena correspondiente = ");
         string stringToCompress = Console.ReadLine();
         Compress(stringToCompress);

        }

      private static void Compress(string input)
      {
            if (string.IsNullOrEmpty(input) || input.Length >= lengthInputMax)
            {
                Console.WriteLine("Error: la longitud de la cadena debe ser mayor que cero y menor que {0} caracteres", lengthInputMax);
                return;
            }
            if (!StringContainsLetters(input)){
                Console.WriteLine("Error: la cadena solo puede contener letras {0}", LettersContains);
                return;
            }

            var stringCompress = CompressString(input);
            if (lengthCompressedStringGreaterThanInitialString(stringCompress, input)){
                stringCompress = input;
            }
            
            Console.WriteLine("{0} => {1}",input,stringCompress);
      }


      private static string CompressString(string initialString){
            StringBuilder newStringCompress = new StringBuilder();

            int charCounter = 0;
            char initialCharacter = initialString[0];

            foreach (var currentCharacter in initialString){
                if (!AreEquals(initialCharacter, currentCharacter)){
                    newStringCompress.Append($"{initialCharacter}{charCounter}");

                    charCounter = 0;
                    initialCharacter = currentCharacter;
                }
                charCounter++;
            }
            newStringCompress.Append($"{initialCharacter}{charCounter}");
            return newStringCompress.ToString();
      }

      private static bool lengthCompressedStringGreaterThanInitialString(string stringCompress, string initialString){
           return stringCompress.Length > initialString.Length;
      }

        private static bool StringContainsLetters(string input){
           return Regex.IsMatch(input, LettersContains);
      }

        private static bool AreEquals(char initialCharacter, char currentCharacter){
            return initialCharacter.Equals(currentCharacter);
        }
    }
}