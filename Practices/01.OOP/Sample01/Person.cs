namespace Sample01
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Person
    {
        public string name { get; set; }
        public string lastName { get; set; }
        public int id { get; set; }
        public string address { get; set; }
        public int phoneNumber { get; set; }
        public int age { get; set; }
        public int DateOfBirth { get; set; }
    }
}