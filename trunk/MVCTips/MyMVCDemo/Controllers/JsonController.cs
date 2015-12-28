using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;

namespace MyMVCDemo.Controllers
{
    public class JsonController : Controller
    {
        //
        // GET: /Json/

        public ActionResult Index()
        {
            
            Student1 student = new Student1();
            return View(student);
        }

        public ActionResult GetStudents()
        {
            List<Student1> students = GetData();
            return Json(students, JsonRequestBehavior.AllowGet);            
        }

        private List<Student1> GetData()
        {
            List<Student1> students = new List<Student1>
            {
                new Student1{ Id=1, FirstName="vincent", LastName ="yang", Age=30, Courses = new List<Course1>{
                    new Course1 { Id=1, CourseName="Programming fundamental", Level="100"},
                    new Course1 { Id=2, CourseName="Programming fundamental - 2", Level="200"},
                    new Course1 { Id=3, CourseName="Business development - 1", Level="100"}
                }},
                new Student1{ Id=2, FirstName="John", LastName ="Smith", Age=20, Courses = new List<Course1>{
                    new Course1 { Id=1, CourseName="Programming fundamental", Level="100"},
                    new Course1 { Id=2, CourseName="Programming fundamental - 2", Level="200"},
                    new Course1 { Id=3, CourseName="Business development - 1", Level="100"}
                }},
                new Student1{ Id=3, FirstName="Sheryl", LastName ="Wang", Age=35, Courses = new List<Course1>{
                    new Course1 { Id=2, CourseName="Programming fundamental - 2", Level="200"},
                    new Course1 { Id=3, CourseName="Business development - 1", Level="100"}
                }}

            };

            return students;

        }

        public ActionResult SaveStudent(string studenData)
        {
            //return Json(students, JsonRequestBehavior.AllowGet);            
            JsonSerializer serializer = new JsonSerializer();

            StringReader sr = new StringReader(studenData);
            Newtonsoft.Json.JsonTextReader reader = new JsonTextReader(sr);

            List<Student1> jsonRequest = (List<Student1>)serializer.Deserialize(reader, typeof(List<Student1>));
            return View("Index");
        }


        [HttpPost]
        public ActionResult SaveStudentWithAjax(List<Student1> students)
        {
            return View();
        }
    }

    public class Student1 {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public List<Course1> Courses { get; set; }
    }

    public class Course1 {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string Level { get; set; }
    }
}
