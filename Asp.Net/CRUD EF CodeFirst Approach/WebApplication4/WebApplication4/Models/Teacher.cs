using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string Phone{ get; set; }
        [Index(IsUnique = true), StringLength(20)]
        public string Email{ get; set; }
        public string Password{ get; set; }
        public List<Student> Students { get; set; }
    }
}