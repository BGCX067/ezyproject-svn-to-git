using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyMVCDemo.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public int Gender { get; set; }
        public GenderEnum GenderList { get; set; }
    }

    public enum GenderEnum
    {
        Male = 1 ,
        Female = 2
    }
}