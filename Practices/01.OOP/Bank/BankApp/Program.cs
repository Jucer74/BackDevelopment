using System;
using System.Text;


namespace BankApp
{

 internal class Program
  {
   
static void Main(string[] args)
    {
     Console.WriteLine("Bienvenido A ZothBank");
     Console.WriteLine("----------------------------------------");
     System.Threading.Thread.Sleep(1500);
      Console.WriteLine("-Por favor, escoga una de las siguientes opciones-");
     System.Threading.Thread.Sleep(1000);
     Console.WriteLine("----------------------------------------");
     Console.WriteLine("1-Create Account-------------------------");
     Console.WriteLine("2-Get Balance Account--------------------");
     Console.WriteLine("3-Deposit Account------------------------");
     Console.WriteLine("4-Withdrawal Account---------------------");
     Console.WriteLine("5-Exit-----------------------------------");  
     Console.WriteLine("----------------------------------------"); 
     int useroption = Convert.ToInt32(Console.ReadLine());
    switch (useroption) 
    {
        case 1:
        break;
        case 2:
        break;
        case 3:
        break;
        case 4:
        break;
        case 5:
        break;
    }
    System.Threading.Thread.Sleep(1000);
    Console.WriteLine("-Gracias por usar ZothBank!-"); 



    }
  }
}