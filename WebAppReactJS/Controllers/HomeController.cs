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
            return Json(Products.Where(p=> p.Active == true), JsonRequestBehavior.AllowGet);
                  
        }


        private void AddProducts()
        {
            //Products.RemoveAt(1);
            //System.Threading.Thread.Sleep(5000);

            if (Products.Count(p => p.Id == 1) == 0)
                Products.Add(new Product { Id = 1, Name = "Google Wifi system", Price = 299, Active = true });


            if (Products.Count(p => p.Id == 2) == 0)
                Products.Add(new Product { Id = 2, Name = "All-New Fire HD 8 Tablet", Price = 89.99M, Active = true });

            if (Products.Count(p => p.Id == 3) == 0)
                Products.Add(new Product { Id = 3, Name = "D-Link Wireless AC1900", Price = 109.76M, Active = true });


            if (Products.Count(p => p.Id == 3) == 0)
            {
                Products.Add(new Product { Id = 3, Name = "D-Link Wireless AC1900", Price = 109.76M, Active = true });
                return;
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
    }
}