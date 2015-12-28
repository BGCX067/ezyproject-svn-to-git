using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace MyMVCDemo.Controllers
{
    public class AjaxFormDemoController : Controller
    {
        //
        // GET: /AjaxFormDemo/

        public ActionResult Index()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult Index(Student1 student) {
            if (ModelState.IsValid) {
                return View(student);
            }
            else {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return View(student);
            }
           
        }            

    }

 
}
