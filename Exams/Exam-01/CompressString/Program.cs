
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
using System.Text;

namespace CompressString
{
  public class Program
  {

    private const int MAX_LENGTH = 255;

    public static void Main()
    {
      Compress("aabcccccaaa");
      // aabcccccaaa => a2b1c5a3
      Compress("XXXoooxxxOOO");
      // XXXoooxxxOOO => X3o3x3O3
      Compress("abbcca");
      // abbcca => abbcca
      Compress("aabbcc");
      // aabbcc => aabbcc
      Compress("");
      // Error: the string must not be null or empty
      Compress("X".PadRight(256, 'X'));
      // Error: The length of the string must be less than 255 characters.
      Compress("a1b2c5a3");
      // Error: Only alphabetic characters [A-Z,a-z] are allowed
    }

    private static void Compress(string input)
    {
      if (string.IsNullOrEmpty(input))
      {
        Console.WriteLine("Error: the string must not be null or empty");
        return;
      }

      if (input.Length > MAX_LENGTH)
      {
        Console.WriteLine("Error: The length of the string must be less than 255 characters.");
        return;
      }

      if(!IsAlpabethic(input))
      {
        Console.WriteLine("Error: Only alphabetic characters [A-Z,a-z] are allowed");
        return;        
      }

      string stringCompressed = ZipString(input);

      if(stringCompressed.Length >= input.Length)
      {
        stringCompressed = input;
      }

      Console.WriteLine("{0} => {1}",input, stringCompressed);
    }

    public static bool IsAlpabethic(string input)
    {
      string lowerString = input.ToLower();
      foreach (var character  in lowerString)
      {
        if(!Char.IsLetter(character))
        {
          return false;
        }        
      }

      return true;
    }

    public static string ZipString(string input)
    {
      // String length
      int strLen = input.Length;
      // String buffer to return 
      StringBuilder dest = new StringBuilder();
      // counter by character (reset over if the character chnager)
      int counterByCharacter = 0;
      // Current Character
      char currentCharacter = input[0];

      // Loop to iterate over string
      for (int i = 0; i < strLen; i++)
      {
        // Valid Change character
        if (currentCharacter != input[i])
        {
            dest.Append(string.Format("{0}{1}", currentCharacter, counterByCharacter));

            // change initial to valid next char
            counterByCharacter = 0;
            currentCharacter = input[i];
        }

        // Increment Counter by Character
        counterByCharacter++;
      }

      // Valid last character
      dest.Append(string.Format("{0}{1}", currentCharacter, counterByCharacter));

      return dest.ToString();
    }
  }
}