using System;

namespace CompressString
{
   public class Program
   {
      public static void Main(string[] args)
      {
        
            Console.WriteLine(Compress("aabcccccaaa"));
            // aabcccccaaa => a2b1c5a3
            Console.WriteLine(Compress("XXXoooxxxOOO"));
            // XXXoooxxxOOO => X3o3x3O3
            Console.WriteLine(Compress("abbcca"));
            // abbcca => abbcca
            Console.WriteLine(Compress("aabbcc"));
            // aabbcc => aabbcc
            //Compress("");
            // Error: the string must not be null or empty
            //Console.WriteLine(Compress("X".PadRight(256, 'X')));
            // Error: The length of the string must be less than 255 characters.
            Console.WriteLine(Compress("a1b2c5a3"));
            // Error: Only alphabetic characters [A-Z,a-z] are allowed
        }

        static string Compress(string input)
        {

            int chainSize = input.Length;
            string stringCompressed = "";
            int MAX_LENGTH = 100;
            char charComparison = input[0];
            int count = 0;


            /* if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Error: The length of the string must be less than 255 characters.");
            } */
            if (input.Length>MAX_LENGTH){
                Console.WriteLine("Error: The length of the string must be less than 255 characters.");
            }

            else if (!IsAlpabethic(input)){
                Console.WriteLine("Error: Only alphabetic characters [A-Z,a-z] are allowed");
            }

            else{
                for (int pointer = 0; pointer < chainSize; pointer++){
                    if (charComparison == input[pointer]){
                        count += 1;
                    }
                    else{
                        stringCompressed += charComparison;
                        stringCompressed += count.ToString();
                        if ( pointer + 1 < chainSize){
                            charComparison = input[pointer];
                        }
                        else{
                            break;
                        }
                        count = 1;
                    }
                }
            }

        stringCompressed += charComparison;
        stringCompressed += count.ToString();

        if(stringCompressed.Length<chainSize){
            Console.Write(input+ " => ");
            return stringCompressed;
        }
        else{
            Console.Write(input+ " => ");
            return input;
        }

    }

        public static bool IsAlpabethic(string input){
            string lowerString = input.ToLower();
            foreach (var character in lowerString){
                if(!Char.IsLetter(character)){
                    return false;
                }
            }
            return true;
        }

    }

}
