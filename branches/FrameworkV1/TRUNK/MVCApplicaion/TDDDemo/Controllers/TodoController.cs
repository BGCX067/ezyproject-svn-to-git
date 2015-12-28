namespace TDDDemo.Controllers {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;
    using TDDDemo.Models;

    public class TodoController : Controller {
        public ActionResult Index() {
            ViewData.Model = Todo.ThingsToBeDone;
            return View();
        }

        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Todo todo) {
            try {
                Todo.ThingsToBeDone.Add(todo);
                return RedirectToAction("Index");
            }
            catch (Exception) {
                return View();
            }
        }
    }
}
