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


	private static string Compress(string str)
	{
		if(str == null || str == "")
		{
			return "Error: Empty String";
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