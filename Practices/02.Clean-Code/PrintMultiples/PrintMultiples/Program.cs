using System;
					
public class Program
{
	public static void Main()
	{
			for(int number = 1; number < 101; number++){
				
				if(number % 3 == 0)
				{
					Console.WriteLine("M-3"+ "("+number+")\n");
				}
				else if(number % 5 == 0)
				{
					Console.WriteLine("M-5"+ "("+number+")\n");
				}
				else if(number % 15 == 0)
				{
					Console.WriteLine("M-3-5"+ "("+number+")\n");
				}
				else
				{
                     Console.WriteLine(number + "\n");
                }				
			}
	}
}
