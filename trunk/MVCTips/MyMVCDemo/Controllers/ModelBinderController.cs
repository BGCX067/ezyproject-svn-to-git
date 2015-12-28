using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMVCDemo.Models;

namespace MyMVCDemo.Controllers
{
    public class ModelBinderController : Controller
    {
        //
        // GET: /ModelBinder/

        public ActionResult Index()
        {

            List<Product> Products = new List<Product> {
                    new Product{ Id = 1, Name = "test", Price=15m, Qty=2},
                    new Product{ Id = 2, Name = "test2", Price=15m, Qty=45}                    
                };
            
            Basket basket = new Basket {
                Products = Products,
                Total = Products.CalculateTotal()
            };

            ViewData["basket"] = basket;
            ViewBag.basket = basket;
            return View();
        }

        [HttpPost]
        public ActionResult Index(Basket basket) {

            //if (ModelState.IsValid)
                //ModelState.Clear();
            var data = basket;
            basket.Total = basket.Products.CalculateTotal();
            ViewBag.basket = basket;
            return View(basket);
        }

        //[HttpPost]
        //public ActionResult Index(string selectedTagIds)
        //{
        //    return View();
        //}

    }

    public static class Extensions {
        public static decimal CalculateTotal(this IEnumerable<Product> products){
            decimal total = 0;

            products.ToList().ForEach(x => { total += x.Price * x.Qty; });

            return total;
        }
    }
}
