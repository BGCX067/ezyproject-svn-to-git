using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMVCDemo.Models
{
    public class Product {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }

    }

    public class Basket {
        public List<Product> Products { get; set; }
        public decimal Total { get; set; }

        public decimal ComputeTotal {
            get {
                decimal total = 0;
                Products.ForEach(x => { total = x.Qty * x.Price; });

                return total;
            }
        }
    }
}