using System;

namespace SomerenModel
{
    public class Student
    {
        public int Id { get; set; }     // database id
        public int Number { get; set; } // Student number
        public string FirstName { get; set; } // First Name
        public string LastName { get; set; } // last name
        public int PhoneNumber { get; set; } // Phone number
        public int Age { get; set; } // Age
        public string Class {  get; set; } // Class
        public int Room {  get; set; } // Room
    }
}