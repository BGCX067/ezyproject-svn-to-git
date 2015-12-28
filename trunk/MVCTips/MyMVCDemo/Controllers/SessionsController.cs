using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMVCDemo.Models;

namespace MyMVCDemo.Controllers
{
    public class SessionsController : Controller
    {
        private SessionRepository _repository;

        public SessionsController() : this(new SessionRepository()) { }

        public SessionsController(SessionRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            var sessions = _repository.FindAll();

            //for ajax requests, we simply need to render the partial
            if (Request.IsAjaxRequest())
                return PartialView("_sessionList2", sessions);
                //return View("_sessionList", sessions);

            return View(sessions);
        }

        [HttpPost]
        public ActionResult Add(Session session)
        {
            if (ModelState.IsValid)
            {
                _repository.SaveSession(session);

                if (Request.IsAjaxRequest())
                    return Index();

                return RedirectToAction("index");
            }
            return View(session);
        }

        [HttpPost]
        public ActionResult Remove(Guid session_id)
        {
            _repository.RemoveSession(session_id);
            //var sessions = _repository.FindAll();
            //if (Request.IsAjaxRequest())
            //    return PartialView("_sessionList2", sessions);
            //return RedirectToAction("index");
            return PartialView("_sessionList2");
        }

    }
}
