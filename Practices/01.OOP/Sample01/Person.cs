using System;
namespace OPP
{
    public class Person
    {
        private string name;
        private int age;
        private string id;


        public string Name
        {
            get; set;
        }

         public string Age
        {
            get; set;
        }

        public string Id 
        {
            get; set;
        }
        public void CreatePerson()
        {
            Console.WriteLine("What is your name");
            name = Name;
        }

        public void ShowPerson ()
        {
            
        }
    }
}
