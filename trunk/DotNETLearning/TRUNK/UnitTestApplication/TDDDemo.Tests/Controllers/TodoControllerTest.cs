namespace TDDDemo.Tests.Controllers {
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TDDDemo.Controllers;
    using TDDDemo.Models;

    [TestClass]
    public class TodoControllerTest {
        [TestInitialize]
        public void Init() {
            Todo.ThingsToBeDone = new List<Todo>() {
                new Todo{ Title = "Get Milk",Completed = true},
                new Todo{ Title = "Bring Home Bacon", Completed = false}
            };
        }

        [TestMethod]                
        public void Should_Display_List_Of_Todo_Items() {

            var viewResult = (new TodoController()).Index() as ViewResult;
            Assert.AreEqual(Todo.ThingsToBeDone, viewResult.ViewData.Model);
        }

        [TestMethod]
        public void Should_Load_Create_View() {
            var viewResult = (ViewResult)new TodoController().Create();
            Assert.AreEqual(string.Empty, viewResult.ViewName);
        }

        [TestMethod]
        public void Should_Add_Todo_Item() {
            var todo = new Todo { Title = "Learn more about ASP.NET MVC Controllers" };
            var redirectToRouteResult = (RedirectToRouteResult)new TodoController().Create(todo);
            Assert.AreEqual("Index", redirectToRouteResult.RouteValues["action"]);
        }

    }
}
