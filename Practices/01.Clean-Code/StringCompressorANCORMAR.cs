//Develop a method for basic compresion of strings using repeated characters count.
//For example, the string aabcccccaaa will become a2b2c5a3
//If the compressed string were not to be smaller than the original string, the method shall return the original string.
using System;
using System.Linq;

public class CharCompressor
{
    public static void Main()
    {
		bool loop = true;
		string lineToCompress = null;
		do{
			lineToCompress =""; //clear String in case the user is inputing the string again so it doesn't concatenate
			Console.WriteLine("Write a line of text to compress: ");
			lineToCompress = Console.ReadLine();

			if(LineFilter(lineToCompress)){ //Check if conditions are met for compression
				string compressedString = CompressString(lineToCompress);//If so, compress it
				string finalString = CompareOriginalAndCompressed(lineToCompress, compressedString); //Compare original and compressed string
				PrintStringCompressed(finalString); //if shorter, output the compressed version. Otherwise output string recieved in input m 
				loop=false; //Exit while loop;
			}
		}while(loop==true);
    }
	
	public static bool LineFilter(string line)
	{
		int minCharacters=0;
		int maxCharacters=255;
		
		if(line.Length==minCharacters || line.Length>maxCharacters){
			Console.WriteLine("Error!!!: String's length must be between "+minCharacters+" and "+maxCharacters);
			return false;
		}else if(!line.All(Char.IsLetter)){
			Console.WriteLine("Error!!!: String must only contain letters");
			return false;
		}else{
			return true;
		}
	}
	
	public static string CompressString(string obtainedString)
	{
		string compressedChain= null;
		int letterInstances=1; //Initiate as 1 so the loop can count naturally instead of from 0
		
		for (int i = 0; i<obtainedString.Length-1; i++){ //-1 to prevent an index out of bounds
			if(obtainedString[i]==obtainedString[i+1]){ //if previous letter is the same as the next one
				letterInstances+=1;
			}
			if(obtainedString[i]!=obtainedString[i+1]){ //if previous letter is different from the next one
				compressedChain+=string.Concat(obtainedString[i], letterInstances);
				letterInstances=1; //Reset counter
			}
			if(i==obtainedString.Length-2){ //when index reaches the last char in the string
				compressedChain+=string.Concat(obtainedString[i+1], letterInstances);
			}
        }		
		return compressedChain;
	}
	
	public static string CompareOriginalAndCompressed(string originalString, string compressedString)
	{
		if(compressedString.Length < originalString.Length){
			return compressedString;
		}else{
			return originalString;
		}
	}
	
	public static void PrintStringCompressed(string finalLine)
	{
		Console.WriteLine(finalLine);
	}
}