namespace Sample01
{
    using System;

    public class Person
    {
        [Required]
        public string firstName { get; set; }

        public string lastName { get; set; }

        public int id { get; set; }

        public char gender { get; set; }

        public int phoneNumber { get; set; }

        public string placeOfBirth { get; set; }

        public DateTime dateOfBirth { get; set; }

