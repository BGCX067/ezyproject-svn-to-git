using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMVCDemo.Models;

namespace MyMVCDemo.Controllers {
    public class StudentEnrollController : Controller {
        //
        // GET: /StudentEnroll/

        public ActionResult Index() {
            //need to use db to retrive the student
            var student = new Student {
                Id = 1,
                FirstName = "demo -1 ",
                LastName = " foo",
                Age = 24
            };

            var courses = GetCourses();

            var departments = GetDepartments();

            StudentEnrollmentViewModel viewModel = new StudentEnrollmentViewModel();
            viewModel.Student = student;          
            viewModel.DepartmentList = new SelectList(departments,"Id","DepartmentName");
            viewModel.CourseList = new SelectList(courses, "Id", "CourseName",student.Courses);

            return View(viewModel);
        }

        private static List<Department> GetDepartments() {
            var departments = new List<Department>(){
                new Department{Id = 1, DepartmentName = "D1"},
                new Department{Id = 2, DepartmentName = "D2"},
                new Department{Id = 3, DepartmentName = "D3"},
                new Department{Id =4,DepartmentName = "D4"}
            };
            return departments;
        }

        private static List<Course> GetCourses() {
            //get course list
            var courses = new List<Course>() {
                new Course{ Id = 1, CourseName = "A1", IdDepartment=3, Level = CourseLevel.Lvl1},
                new Course{Id = 2, CourseName = "A2", IdDepartment = 2, Level = CourseLevel.Lvl2},
                new Course{Id = 3, CourseName = "A3", IdDepartment = 1,Level = CourseLevel.Lvl1}

            };
            return courses;
        }

        [HttpPost]
        public ActionResult Index(StudentEnrollmentViewModel viewModel) {


            //get course list
            var courses = GetCourses();

            var departments = GetDepartments();
            viewModel.DepartmentList = new SelectList(departments, "Id", "DepartmentName");
            viewModel.CourseList = new SelectList(courses, "Id", "CourseName", viewModel.SelectCourse);
            return View(viewModel);
        }

    }
}
