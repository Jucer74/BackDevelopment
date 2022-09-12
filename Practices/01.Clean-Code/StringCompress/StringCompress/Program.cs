/**
* Implement a method to perform basic string compression using the counts
* of repeated characters. For example, the string aabcccccaaa would become
* a2b1c5a3. If the "compressed" string would not become smaller than the
* original string, your method should return the original string.
*/

using System;
using System.Text;

public class Program
{
    public static void Main()
    {


        string exampleString = Compress("aabcccccaaa");
        Console.WriteLine(exampleString);
        // aabcccccaaa => a2b1c5a3
        exampleString = Compress("abbcca");
        Console.WriteLine(exampleString);
        // abbcca => abbcca
        exampleString = Compress("aabbcc");
        Console.WriteLine(exampleString);
        // aabbcc => aabbcc
        exampleString = Compress("");
        Console.WriteLine(exampleString);
        // Error: Empty String
    }

    public static string Compress(string inputString)
    {
        if (inputString == null || inputString == "")
        {
            return "Error: Empty String";
        }

        StringBuilder stringBuild = new StringBuilder();
        char previousCharInString = inputString[0];
        int characterCount = 1;

        for (int i = 1; i < inputString.Length; i++)
        {
            if (inputString[i] == previousCharInString)
            {
                characterCount++;
            }
            else
            {
                stringBuild.Append(previousCharInString);
                stringBuild.Append(characterCount);
                previousCharInString = inputString[i];
                characterCount = 1;
            }
        }

        stringBuild.Append(previousCharInString);
        stringBuild.Append(characterCount);
        string result = stringBuild.ToString();

        if (result.Length >= inputString.Length)
        {
            return inputString;
        }
        return result;
    }
}