using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public string Phone{ get; set; }
        public string Email{ get; set; }
        public string Password{ get; set; }
        public string Address { get; set; }
    }
}