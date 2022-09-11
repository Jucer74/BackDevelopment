/// <summary>
/// Implemente un método para realizar la compresión básica de cadenas
/// utilizando el recuento de caracteres repetidos.
/// Por ejemplo:
/// - la cadena aabcccccaaa se convertiría en a2b1c5a3.
/// Si la cadena "comprimida" no fuera más pequeña que la cadena original,
/// su método debería devolver la cadena original.
/// </summary>
namespace ComprimirCadena.App
{
   using System;
   using System.Text;
   using System.Text.RegularExpressions;

   public class Program
   {
      public static void Main()
      {
         Compress("aabcccccaaa");
         // aabcccccaaa -> a2b1c5a3
         Compress("abbcca");
         // abbcca -> abbcca
         Compress("XXXoooxxxOOO");
         // XXXoooxxxOOO -> X3o3x3O3
         Compress("");
         // Error: Error: la cadena longitud de la cadena debe ser mayor que cero y menor que 256 caracteres
         Compress("X".PadRight(256, 'X'));
         // Error: Error: la cadena longitud de la cadena debe ser mayor que cero y menor que 256 caracteres
         Compress("a1b2c5a3");
         // Error: la cadena solo puede contener letras [A-Z,a-z]

      }

      private static void Compress(string input)
      {
      }
   }
}