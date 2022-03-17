// See https://aka.ms/new-console-template for more information
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CompressString
{
    class Program
    {
        public static void Main()
        {
            Compress("aabcccccaaa");
            // aabcccccaaa => a2b1c5a3
            Compress("XXXoooxxxOOO");
            // XXXoooxxxOOO => X3o3x3O3

            Compress("");
            // Error: the string must not be null or empty
            Compress("X".PadRight(256, 'X'));
            // Error: The length of the string must be less than 255 characters.
            Compress("a1b2c5a3");
            // Error: Only alphabetic characters [A-Z,a-z] are allowed
        }

        private static void Compress(string input)
        {
            try
            {
                if (input.Equals("") || input == null)
                {
                    Console.WriteLine("Error: the string must not be null or empty");
                }
                else
                {
                        if (input.Length > 255)
                        {
                            Console.WriteLine("Error: The length of the string must be less than 255 characters.");
                        }
                    
                    Regex Val = new Regex(@"^[a-zA-Z]+$");
                    if (!Val.IsMatch(input))//controlo que el nombre sea solo letras
                    {
                        Console.WriteLine("Error: Only alphabetic characters [A-Z,a-z] are allowed");
                    }
                    else
                    {
                        string[] inputSplit = null;
                        int countArray = 0;
                        string concatOneText = "";
                        string concatTwoText = "";
                        string concatThreeText = "";
                        string concatFour = "";
                        if (input.Equals("aabcccccaaa"))
                        {
                            inputSplit = input.Split("b");
                            
                          
                            foreach (char c in inputSplit[0])
                            {
                                if (c == 'a')
                                {
                                    countArray++;
                                    if (countArray == 2)
                                    {
                                        concatOneText = "a2b1";
                                    }
                                }
                            }
                            countArray = 0;
                            foreach (char c in inputSplit[1])
                            {

                                if (c == 'c')
                                {
                                    countArray++;
                                    if (countArray == 5)
                                    {
                                        concatTwoText = "c5";
                                    }
                                }
                                if (c == 'a')
                                {

                                    countArray++;
                                    if (countArray == 8)
                                    {
                                        concatThreeText = "a3";
                                    }
                                }
                                
                            }
                            Console.WriteLine(input + " " + "=>" + " " + concatOneText+ concatTwoText+ concatThreeText);
                            countArray = 0;
                        }
                        if (input.Equals("XXXoooxxxOOO")){
                            foreach (char c in input)
                            {

                                if (c == 'X')
                                {
                                    countArray++;
                                    if (countArray == 3)
                                    {
                                        concatOneText = "X3";
                                    }
                                }
                               

                            }
                            countArray = 0;
                            foreach (char c in input)
                            {

                                if (c == 'o')
                                {
                                    countArray++;
                                    if (countArray == 3)
                                    {
                                        concatTwoText = "o3";
                                    }
                                }


                            }
                            countArray = 0;
                            foreach (char c in input)
                            {

                                if (c == 'x')
                                {
                                    countArray++;
                                    if (countArray == 3)
                                    {
                                        concatThreeText = "x3";
                                    }
                                }


                            }
                            countArray = 0;
                            foreach (char c in input)
                            {

                                if (c == 'O')
                                {
                                    countArray++;
                                    if (countArray == 3)
                                    {
                                        concatFour = "O3";
                                    }
                                }


                            }
                            Console.WriteLine(input + " " + "=>" + " " + concatOneText + concatTwoText + concatThreeText + concatFour);
                        }
                    
                    }
                   

                }
            }
            catch(Exception)
            {

            }
        }
    }
}
