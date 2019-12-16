using System;
using System.Collections.Generic;
using System.Text;

namespace DayMe.Models
{
    class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
        public int Gender { get; set; }
        public int Sexuality { get; set; }

        public User(string name, string email, int age, int gender, int sexuality, int phoneNumber = 0, string description = null)
        {
            this.Name = name;
            this.Email = email;
            this.Age = age;
            this.Gender = gender;
            this.Sexuality = sexuality;
            this.PhoneNumber = phoneNumber;
            this.Description = description;
        }
    }
}
