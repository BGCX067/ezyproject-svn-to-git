using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMVCDemo.Controllers
{
    public class AjaxController : Controller
    {
        //
        // GET: /Ajax/

        public ActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            string data3 = Session["id"].ToString();
            
            //data1 only can be read once
            string data1 = TempData["id"].ToString();
            return View();
        }

        [HttpPost]
        public ActionResult AjaxPost(int id)
        {
            ViewData["id"] = id;
            TempData["id"] = id;
            Session["id"] = id;
            return PartialView("_AjaxData");
        }

    }
}
