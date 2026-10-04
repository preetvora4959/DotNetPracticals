using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Practical6_ProductCatalog.Models;

namespace Practical6_ProductCatalog.Controllers
{
    public class ProductController : Controller
    {
        private List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Nova Laptop",
                    Category = "Computers",
                    Price = 64999,
                    Description = "Powerful laptop for study and daily work."
                },
                new Product
                {
                    Id = 2,
                    Name = "Pixel Smartphone",
                    Category = "Mobiles",
                    Price = 28999,
                    Description = "Modern smartphone with a bright display."
                },
                new Product
                {
                    Id = 3,
                    Name = "AirBeat Headphones",
                    Category = "Audio",
                    Price = 3499,
                    Description = "Wireless headphones with clear sound."
                },
                new Product
                {
                    Id = 4,
                    Name = "FitPro Smart Watch",
                    Category = "Wearables",
                    Price = 4999,
                    Description = "Smart watch for fitness and everyday use."
                },
                new Product
                {
                    Id = 5,
                    Name = "Speed Gaming Mouse",
                    Category = "Accessories",
                    Price = 1799,
                    Description = "Responsive gaming mouse for smooth control."
                },
                new Product
                {
                    Id = 6,
                    Name = "Boom Bluetooth Speaker",
                    Category = "Audio",
                    Price = 2699,
                    Description = "Portable speaker with powerful audio."
                }
            };
        }

        public ActionResult Index()
        {
            return View(GetProducts());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            Product product = GetProducts().FirstOrDefault(p => p.Id == id.Value);

            if (product == null)
            {
                return RedirectToAction("Index");
            }

            return View(product);
        }
    }
}