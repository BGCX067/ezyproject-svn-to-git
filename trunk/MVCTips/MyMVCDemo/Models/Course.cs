using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMVCDemo.Models {
    public class Course {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public int IdDepartment { get; set; }

        public CourseLevel Level { get; set; }
    }

    public enum CourseLevel{
        Lvl1 = 1,
        Lvl2 = 2
    }
}