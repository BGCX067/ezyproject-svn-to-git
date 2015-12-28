using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMVCDemo.Models;
using MvcSiteMapProvider.Filters;
using MvcSiteMapProvider;

namespace MyMVCDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["message"] = "test";
            return View("Error");
        }
       
        public ActionResult About()
        {
            //ViewData["SomeKey"] = "This will be the title"; 
           return View();
        }

        public ActionResult TestEnum()
        {
            Person p = new Person();
            p.Gender = 2;
            return View(p);
        }

        private bool NthDayOfMonth(DateTime date, DayOfWeek dow, int n)
        {
            int d = date.Day;
            return date.DayOfWeek == dow && (d / 7 == n || (d / 7 == (n - 1) && d % 7 > 0));
        }

        [HttpPost]
        public ActionResult TestMethod(FormCollection formCollection)
        {

            return View();
        }

        public ActionResult Test() {
            
            string test = "abc";
            return View((object)test);
        }
    }
}
