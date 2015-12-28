using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMVCDemo.Models {
    public class StudentEnrollmentViewModel {
        public Student Student { get; set; }

        public List<int> SelectCourse { get; set; }
        
        // All Departments
        public SelectList DepartmentList { get; set; }
        //All courses
        public SelectList CourseList { get; set; }
    }
}