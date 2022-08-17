/**
* Implement a method to perform basic string compression using the counts
* of repeated characters. For example, the string aabcccccaaa would become
* a2b1c5a3. If the "compressed" string would not become smaller than the
* original string, your method should return the original string.
*/

using System;

public class Program
{
	public static void Main()
	{
		Compress("aabcccccaaa");
		// aabcccccaaa => a2b1c5a3
		Compress("abbcca");
		// abbcca => abbcca
		Compress("aabbcc");
		// aabbcc => aabbcc
		Compress("");
		// Error: Empty String
	}


	private static void Compress(string input)
	{
	}
}