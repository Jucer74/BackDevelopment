//Develop a method for basic compresion of strings using repeated characters count.
//For example, the string aabcccccaaa will become a2b2c5a3
//If the compressed string were not to be smaller than the original string, the method shall return the original string.
using System.Text;

public class CharCompressor
{
    public static void Main()
    {
        bool loop = true;
        do
        {
            Console.WriteLine("Write a line of text to compress: ");
            string lineToCompress = Console.ReadLine();

            if (LineFilter(lineToCompress))//Check if conditions are met for compression
            {   //Compress string, compare to original input and finally console print.   
                PrintString( CompareOriginalAndCompressed(lineToCompress, CompressString(lineToCompress)) );
                loop = false;
            }
        } while (loop == true);
    }

    public static bool LineFilter(string lineToCompress)
    {
        int minCharacters = 0;
        int maxCharacters = 255;
        bool acceptInput = true;

        if (lineToCompress.Length == minCharacters || lineToCompress.Length > maxCharacters)
        {
            Console.WriteLine("Error!!!: String's length must be between " + minCharacters + " and " + maxCharacters);
            acceptInput = false;
        }
        else if (!lineToCompress.All(Char.IsLetter)) //Part of the System.Linq reference
        { 
            Console.WriteLine("Error!!!: String must only contain letters");
            acceptInput = false;
        }

        return acceptInput;
    }

    public static string CompressString(string lineToCompress)
    {
        StringBuilder sbCompressedString = new StringBuilder(); //Part of the System.Text reference
        int letterInstances = 0;
        char initialLetter = lineToCompress[0];

        foreach (char currentLetter in lineToCompress)
        {
            if (!currentLetter.Equals(initialLetter))
            {
                sbCompressedString.Append($"{initialLetter}{letterInstances}");
                initialLetter = currentLetter;
                letterInstances = 0; //Reset Counter
            }
            letterInstances++;
        }
        sbCompressedString.Append($"{initialLetter}{letterInstances}"); //Once foreach is done, add the last char

        return sbCompressedString.ToString();
    }

    public static string CompareOriginalAndCompressed(string originalString, string compressedString)
    {   //if shorter, output the compressed version. Otherwise output string recieved by user
        if (compressedString.Length > originalString.Length)
        {
            compressedString = originalString;
        }
        return compressedString;
    }

    public static void PrintString(string finalLine)
    {
        Console.WriteLine("Your compressed line is: "+finalLine);
    }
}