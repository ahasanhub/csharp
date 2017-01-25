using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5.Models;

namespace MVC5.Controllers
{
    public class StudentController : Controller
    {
        static List<Student> list = new List<Student> { new Student { StudetntId = 1, Name = "Ahasan", Age = 32 }, new Student { StudetntId = 2, Name = "Zayn", Age = 3 } };
        // GET: Student
        public ActionResult Index()
        {
            return View(list);
        }

        public ActionResult Create()
        {
            Student student=new Student();
            return View(student);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            return RedirectToAction("Index");
        }
       
        public ActionResult Edit(int id)
        {
            var student = list.FirstOrDefault(s => s.StudetntId == id);
           return View(student);
        }
       [HttpPost]
        public ActionResult Edit(Student student)
        {
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var student = list.FirstOrDefault(s => s.StudetntId == id);
            return View(student);
        }

        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}