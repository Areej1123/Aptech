using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Model;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AptechDbContext _context;

        public StudentsController(AptechDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Student>> GetStudents()
        {
            var lst=_context.Students.ToList();
            return lst;
        }

        [HttpPost]
        public ActionResult<dynamic> AddStudent(Student std)
        {

            var emailExist = _context.Students.Any(x=>x.Email==std.Email);
            if (emailExist)
                return new {Response="Email already Exist"};

            _context.Students.Add(std);
            int res=_context.SaveChanges();

            if (res <= 0)
                return new { Response = "Record not saved" };

            return std;
       
        }

        [HttpDelete("{id:int}")]
        public ActionResult<dynamic> Delete(int id)
        {
            var isExist = _context.Students.Any(x => x.StudentId==id);
            if (!isExist)
                return new { Response = "Record not found" };

            var std = _context.Students.FirstOrDefault(x => x.StudentId == id);
            _context.Students.Remove(std);
            int res = _context.SaveChanges();

            if (res <= 0)
                return new { Response = "Record not deleted" };

            return new { Response = "Record deleted", Data = id }; ;

        }
        [HttpPut]
        public ActionResult<dynamic> updateStudent(Student std)
        {

            var obj = _context.Students.FirstOrDefault(x=>x.StudentId==std.StudentId);
            if(obj is null)
                return new { Response = "Record not deleted" };

            obj.Name = std.Name;
            obj.Phone = std.Phone;
            obj.Email = std.Email;

            int res = _context.SaveChanges();

            if (res <= 0)
                return new { Response = "Record not updated" };

            return new { Response = "Record updated", Data = obj }; 


        }



    }
}
