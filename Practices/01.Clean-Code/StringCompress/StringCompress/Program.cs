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

		//string exampleString = null;
		//string result = Compress(exampleString);
		//Console.WriteLine(result);

		//string exampleString = "";
		//string result = Compress(exampleString);
		//Console.WriteLine(result);

        //string exampleString = "aabbcc";
        //string result = Compress(exampleString);
        //Console.WriteLine(result);

        //string exampleString = "abbcca";
        //string result = Compress(exampleString);
        //Console.WriteLine(result);

        string exampleString = "aabcccccaaa";
        string result = Compress(exampleString);
        Console.WriteLine(result);

        //Compress("aabcccccaaa");
        // aabcccccaaa => a2b1c5a3
        //Compress("abbcca");
        // abbcca => abbcca
        //Compress("aabbcc");
        // aabbcc => aabbcc
        //Compress("");
        // Error: Empty String
    }


	private static  string Compress(string str)
	{
		if(str == null || str == "")
		{
			return str;
		}

		StringBuilder stringBuild = new StringBuilder();
		char prevChar = str[0];
		int stringCount = 1;

		for(int i = 1; i<str.Length; i++){
			if(str[i] == prevChar)
			{
				stringCount++;
			}
			else
			{
				stringBuild.Append(prevChar);
				stringBuild.Append(stringCount);
				prevChar= str[i];
				stringCount = 1;
			}
		}

		stringBuild.Append(prevChar);
        stringBuild.Append(stringCount);
		string result = stringBuild.ToString();

		if (result.Length >= str.Length)
		{
			return str;
		}
		return result;
    }
}