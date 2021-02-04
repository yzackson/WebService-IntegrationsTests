using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationDemo2.Models
{
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string RegistrationNumber { get; set; }
        public string token { get; set; }
        public string code { get; set; }
    }
}