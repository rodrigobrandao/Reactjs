using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppReactJS.Models;

namespace WebAppReactJS.Controllers
{
    public class HomeController : Controller
    {
        public static IList<Product> Products { get; set; }

        public HomeController()
        {
            if (Products != null) return;

            Products = new List<Product>();
            Products.Add(new Product { Id = 1, Name = "Google Wifi system", Price = 299, Active = true });
            Products.Add(new Product { Id = 2, Name = "All-New Fire HD 8 Tablet", Price = 89.99M, Active = true });
            Products.Add(new Product { Id = 3, Name = "D-Link Wireless AC1900", Price = 109.76M, Active = true });
            Products.Add(new Product { Id = 4, Name = "Sades SA920 Wired Stereo", Price = 28.44M, Active = true });
            Products.Add(new Product { Id = 5, Name = "Logitech Wireless Touch Keyboard", Price = 27.99M, Active = true });
            Products.Add(new Product { Id = 6, Name = "Kingston Digital 120GB SSDNow V300 SATA", Price = 47.49M, Active = true });
        }

        public ActionResult Index()
        {
            Products = null;
            return View();
        }

        public ActionResult Product(int id)
        {
            Product product = Products.First(p => p.Id == id);

            ViewBag.Message = $" You clicked on product {product.Id} - {product.Name}, price is $ {product.Price} ";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public JsonResult GetProducts()
        {
            AddProducts();
            return Json(Products.Where(p => p.Active == true), JsonRequestBehavior.AllowGet);

        }

        private void AddProducts()
        {
            //System.Threading.Thread.Sleep(5000);

            if (Products.Count() == 0)
            {
                Products.Add(new Product { Id = 1, Name = "Google Wifi system", Price = 299, Active = true });
                Products.Add(new Product { Id = 2, Name = "All-New Fire HD 8 Tablet", Price = 89.99M, Active = true });
                Products.Add(new Product { Id = 3, Name = "D-Link Wireless AC1900", Price = 109.76M, Active = true });
            }
                        
            if (Products.Count(p => p.Id == 4) == 0)
            {
                Products.Add(new Product { Id = 4, Name = "Sades SA920 Wired Stereo", Price = 28.44M, Active = true });
                return;
            }

            if (Products.Count(p => p.Id == 5) == 0)
            {
                Products.Add(new Product { Id = 5, Name = "Logitech Wireless Touch Keyboard", Price = 27.99M, Active = true });
                return;
            }

            if (Products.Count(p => p.Id == 6) == 0)
            {
                Products.Add(new Product { Id = 6, Name = "Kingston Digital 120GB SSDNow V300 SATA", Price = 47.49M, Active = true });
                return;
            }

            if (Products.Count(p => p.Id == 7) == 0)
            {
                Products.Add(new Product { Id = 7, Name = "All-New Echo Dot (2nd Generation)", Price = 49.99M, Active = true });
                return;
            }

            if (Products.Count(p => p.Id == 8) == 0)
            {
                Products.Add(new Product { Id = 8, Name = "Amazon Tap - Alexa-Enabled Portable", Price = 129.99M, Active = true });
                return;
            }

            if (Products.Count(p => p.Id == 9) == 0)
            {
                Products.Add(new Product { Id = 9, Name = "Charmin Dash Button", Price = 4.99M, Active = true });
                return;
            }

            if (Products.Count(p => p.Id == 10) == 0)
            {
                Products.Add(new Product { Id = 10, Name = "Purina Beyond Dash Button", Price = 6.23M, Active = true });
                return;
            }
            else
            {
                //change price
                Products.First(p => p.Id == 10).Price = 9.99M;
            }
        }

        [HttpGet]
        public JsonResult GetOrders()
        {
            List<Order> orders = new List<Order>();

            Order order = new Order { Id = 1, Number = "000001", State = OrderState.Cart, Date = DateTime.Now.AddDays(-10), CustomerAddress = "" };
            order.Add(new Item { OrderId = order.Id, ItemId = 1, Product = new Product { Id = 10, Name = "Google Wifi system", Price = 30.83M }  });
            order.Add(new Item { OrderId = order.Id, ItemId = 2, Product = new Product { Id = 20, Name = "Purina Beyond Dash Button", Price = 31.13M } });
            order.Add(new Item { OrderId = order.Id, ItemId = 3, Product = new Product { Id = 30, Name = "Charmin Dash Button", Price = 98.99M } });
            orders.Add(order);

            Order order2 = new Order { Id = 2, Number = "000002", State = OrderState.Complete, Date = DateTime.Now.AddDays(-20), CustomerAddress = "" };
            order2.Add(new Item { OrderId = order2.Id, ItemId = 1, Product = new Product { Id = 40, Name = "All-New Echo Dot", Price = 242.10M } });
            orders.Add(order2);

            Order order3 = new Order { Id = 3, Number = "000003", State = OrderState.Confirm, Date = DateTime.Now.AddDays(-5), CustomerAddress = "" };
            order3.Add(new Item { OrderId = order3.Id, ItemId = 1, Product = new Product { Id = 50, Name = "All-New Fire HD 8 Tablet", Price = 89.99M } });
            orders.Add(order3);

            return Json(orders, JsonRequestBehavior.AllowGet);
        }
    }
}