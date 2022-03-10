
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

namespace CompressString
{
    public class Program
    {

        static int MAXIMO_CARACTERES = 255;
        public static void Main()
        {
            Compress("aabcccccaaa");
            // aabcccccaaa => a2b1c5a3
            //Compress("XXXoooxxxOOO");
            // XXXoooxxxOOO => X3o3x3O3
            //Compress("abbcca");
            // abbcca => abbcca
            //Compress("aabbcc");
            // aabbcc => aabbcc
            //Compress("");
            // Error: the string must not be null or empty
            //Compress("X".PadRight(256, 'X'));
            // Error: The length of the string must be less than 255 characters.
            //Compress("a1b2c5a3");
            // Error: Only alphabetic characters [A-Z,a-z] are allowed
        }

        private static void Compress(string input)
        {
            Char[] listaDeCaracteres = input.ToCharArray();


            int posicionInicialDelCaracter = 0;
            int contadorDePalabraRepetidas = 0;


            String cadenaAuxiliar = "";
            String cadenaComprimida = "";

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

            if (esAlfabetico(input))
            {
                Console.Write("Only alphabetic characters [A-Z,a-z] are allowed.");
                return;            }


            foreach (Char caracter in listaDeCaracteres)
            {


                if (posicionInicialDelCaracter < listaDeCaracteres.Length)
                {


                    if (listaDeCaracteres[posicionInicialDelCaracter].Equals(caracter))
                    {
                        contadorDePalabraRepetidas = contadorDePalabraRepetidas + 1;
                        //Console.Write(listaDeCaracteres[posicionInicialDelCaracter] + "\n");
                        // Console.Write(caracter + contadorDePalabraRepetidas.ToString() + "\n");
                        cadenaAuxiliar = caracter.ToString();
                        //  Console.Write(listaDeCaracteres[posicionInicialDelCaracter]);


                        //  Console.Write(contadorDePalabraRepetidas);

                    }
                    else
                    {

                        cadenaAuxiliar = cadenaAuxiliar + contadorDePalabraRepetidas.ToString();
                        cadenaAuxiliar = "";
                        //cadenaAuxiliar = caracter.ToString() + contadorDePalabraRepetidas.ToString();
                        contadorDePalabraRepetidas = 0;
                        Console.Write(contadorDePalabraRepetidas + "\n");

                    }
                    cadenaComprimida += cadenaAuxiliar;
                    posicionInicialDelCaracter = posicionInicialDelCaracter + 1;
                }








            }

            Console.Write(cadenaComprimida);
        }

        public static bool esAlfabetico(string input)
        {
            string cadenaEnMinuscula = input.ToLower();
            foreach (var caracter in cadenaEnMinuscula)
            {
                if (!Char.IsLetter(caracter))
                {
                    return false;
                }
            }
        }

    }
}


/* Char[] listaDeCaracteres = input.ToCharArray();


           int posicionInicialDelCaracter = 0;
           int contadorDePalabraRepetidas = 0;

           String cadenaComprimida = "";
                               Console.Write(contadorDePalabraRepetidas[0]);

           foreach (Char caracter in listaDeCaracteres)
           {

               if (caracter == listaDeCaracteres[posicionInicialDelCaracter])
               {
                   contadorDePalabraRepetidas += 1;
               }
               else
               {
                   cadenaComprimida = caracter.ToString() + contadorDePalabraRepetidas.ToString();
                   contadorDePalabraRepetidas = 0;
                               Console.Write(contadorDePalabraRepetidas);


               }

               posicionInicialDelCaracter += 1;


           }

           Console.Write(cadenaComprimida); */