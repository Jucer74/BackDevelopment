﻿
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
using System.IO;
using System.Text;

namespace CompressString
{
   public class Program
   {
      public static void Main()
      {
        Compress("aabcccccaaa");
        //aabcccccaaa => a2b1c5a3
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
      //   int numberOfCharacter= 0;
      //   string currentCompress = "";
          for (int currentCharacter = 0; currentCharacter <= input.Length; currentCharacter++)
          {
            throw new NotImplementedException();
          }
          Console.WriteLine(input + " => "+ input.Length);
        
      }
      
   }
}