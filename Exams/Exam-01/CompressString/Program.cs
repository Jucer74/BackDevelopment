
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

          int MAXIMO_CARACTERES = 255;
          static void Main()
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

          static async void Compress(string input)
        {

            // Variables
            Char[] listaDeCaracteres = input.ToCharArray();
            var comprension = new StringBuilder();
            int posicionInicialCaracter = 0;

            // Validaciones 
            if (String.IsNullOrEmpty(input))
            {
                Console.Write("the string must not be null or empty");
                return;
            }

            if (input.Length > MAXIMO_CARACTERES)
            {
                Console.Write("The length of the string must be less than 255 characters.");
                return;
            }

            if (!esAlfabetico(input))
            {
                Console.Write("Only alphabetic characters [A-Z,a-z] are allowed.");

                return;
            }


            // Proceso de comprension de cadena
            while (posicionInicialCaracter < input.Length)
            {
                char c = input[posicionInicialCaracter];
                int posicionSiguienteCaracter = posicionInicialCaracter + 1;
                while (posicionSiguienteCaracter < input.Length && input[posicionSiguienteCaracter] == c)
                {
                    posicionSiguienteCaracter++;
                }

                comprension.Append(c).Append(posicionSiguienteCaracter - posicionInicialCaracter);
                posicionInicialCaracter = posicionSiguienteCaracter;
            }

            // Si la comprension es mayor que la cadena original retorna la cadena original
            if (comprension.Length > input.Length)
            {
                Console.WriteLine(input);
                return;
            }
            else
            {
                Console.WriteLine(comprension.ToString());

            }



        }

          static bool esAlfabetico(string input)
        {
            string cadenaEnMinuscula = input.ToLower();
            foreach (var caracter in cadenaEnMinuscula)
            {
                if (!Char.IsLetter(caracter))
                {
                    return false;
                }
            }

            return true;

        }
    }
  }
}
 
