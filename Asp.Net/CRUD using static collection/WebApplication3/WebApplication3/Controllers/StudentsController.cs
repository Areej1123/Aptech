using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class StudentsController : Controller
    {
        public static List<Student> students = new List<Student>() {
            new Student{Id=101,Name="ali",Phone="0320-9865321",Email="Ali@gmail.com",Password="123",Address="street14"},
            new Student{Id=102,Name="Annus",Phone="0320-9865321",Email="Ali@gmail.com",Password="123",Address="street14"},
            new Student{Id=103,Name="Basit",Phone="0320-9865321",Email="Ali@gmail.com",Password="123",Address="street14"},
            new Student{Id=104,Name="Raffay",Phone="0320-9865321",Email="Ali@gmail.com",Password="123",Address="street14"},
            new Student{Id=105,Name="Areej",Phone="0320-9865321",Email="Ali@gmail.com",Password="123",Address="street14"},
            new Student{Id=106,Name="Ameen",Phone="0320-9865321",Email="Ali@gmail.com",Password="123",Address="street14"},
            new Student{Id=107,Name="Ameer",Phone="0320-9865321",Email="Ali@gmail.com",Password="123",Address="street14"},
            new Student{Id=108,Name="Ateeb",Phone="0320-9865321",Email="Ali@gmail.com",Password="123",Address="street14"},
            new Student{Id=109,Name="Mudassir",Phone="0320-9865321",Email="Ali@gmail.com",Password="123",Address="street14"},
            new Student{Id=110,Name="Mustufa",Phone="0320-9865321",Email="Ali@gmail.com",Password="123",Address="street14"}

        };
        public static int id = 111;
        // GET: Students
        public ActionResult Index()
        {
            ViewBag.students = students;
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student std)
        {
            std.Id = id++;
            students.Add(std);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var std = students.FirstOrDefault(x=>x.Id==id);
            return View(std);
        }

        public ActionResult Update(int id)
        {
            var std = students.FirstOrDefault(x => x.Id == id);
            return View(std);
        }
        [HttpPost]
        public ActionResult Update(Student std)
        {
            // update student

            var obj = students.FirstOrDefault(x => x.Id == std.Id);
            obj.Name = std.Name;
            obj.Phone = std.Phone;
            obj.Email = std.Email;
            obj.Password = std.Password;
            obj.Address = std.Address;
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var std = students.FirstOrDefault(x => x.Id == id);
            return View(std);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var std = students.FirstOrDefault(x => x.Id == id);
            students.Remove(std);
            return RedirectToAction("index");
        }
    }
}