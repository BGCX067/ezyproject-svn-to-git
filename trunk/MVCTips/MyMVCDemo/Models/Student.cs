using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMVCDemo.Models {
    public class Student {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public int Age { get; set; }

        public string FullName {
            get {
                return FirstName + " " + LastName;
            }
        }
        public List<Course> Courses { get; set; }

        
    }
}