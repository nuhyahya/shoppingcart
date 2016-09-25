using System;
using System.Web.Mvc;
using LanguageFeatures.Models;
using System.Collections.Generic;
using System.Text;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Navigate to a URL to show an example";
        }
        public ViewResult AutoProperty()
        {
            //create a new Product
            Product myProduct = new Product();

            //set the property value
            myProduct.Name = "Kayak";

            //get the property
            string productName = myProduct.Name;

            //generate the view
            return View("Result", (object)String.Format("Product name: {0}", productName));
        }
        public ViewResult CreateProduct()
        {
            Product myProduct = new Product
            {
                ProductID = 100,
                Category = "Watersports",
                Description = "A boat for one person",
                Name = "Kayak",
                Price = 275M
            };
            return View("Result", (object)String.Format("Category: {0}", myProduct.Category));
        }
        public ViewResult CreateCollection()
        {
            string[] stringArray = { "Apple", "orange", "plum" };

            List<int> intList = new List<int> { 10, 20, 30, 40 };

            Dictionary<string, int> myDict = new Dictionary<string, int> { { "Apple", 10}, {"orange", 20}, {"plum", 30 }
            };

            return View("Result", (object)stringArray[1]);
        }
        public ViewResult UseExtension()
        {
            //create and populate shpping cart
            ShoppingCart cart = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product {Name = "Kayak", Price = 275M },
                    new Product {Name = "Lifejacket", Price = 48.95M },
                    new Product {Name = "Soccer ball", Price = 19.50M },
                    new Product {Name = "Corner flag", Price = 34.95M }
                }
            };

            //get the total value of the products in the cart
            decimal cartTotal = cart.TotalPrices();

            return View("Result", (object)String.Format("Total: {0:c}", cartTotal));
        }
        public ViewResult UseExtensionEnumerable()
        {

            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product> {
                    new Product {Name = "Kayak", Price = 275M},
                    new Product {Name = "Lifejacket", Price = 48.95M},
                    new Product {Name = "Soccer ball", Price = 19.50M},
                    new Product {Name = "Corner flag", Price = 34.95M}
                }
            };

            // create and populate an array of Product objects
            Product[] productArray = {
                new Product {Name = "Kayak", Price = 275M},
                new Product {Name = "Lifejacket", Price = 48.95M},
                new Product {Name = "Soccer ball", Price = 19.50M},
                new Product {Name = "Corner flag", Price = 34.95M}
            };

            // get the total value of the products in the cart
            decimal cartTotal = products.TotalPrices();
            decimal arrayTotal = products.TotalPrices();

            return View("Result",
                (object)String.Format("Cart Total: {0}, Array Total: {1}",
                    cartTotal, arrayTotal));
        }

        public ViewResult UseFilterExtensionMethod()
        {
            //create and populate ShoppingCart
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product
                    {
                        Name = "Kayak",Category = "Watersports", Price = 275M
                    },
                    new Product
                    {
                        Name = "Lifejacket", Category = "Watersports", Price = 48.95M
                    },
                    new Product
                    {
                        Name = "Corner flag", Category = "Soccer", Price = 19.50M
                    },
                    new Product
                    {
                        Name = "Soccer ball", Category = "Soccer", Price = 34.95M
                    },
                }
            };

            decimal total = 0;

            foreach(Product Prod in products.Filter(prod => prod.Category == "Soccer" || prod.Price > 20))
            {
                total += Prod.Price;
            }
            return View("Result", (object)String.Format("Total: {0}", total));
        }
        
        public ViewResult CreateAnonArray()
        {
            var oddsAndEnds = new[]
            {
                new {Name = "MVC", Category = "Pattern"},
                new {Name = "Hat", Category = "Clothing"},
                new {Name = "Apple", Category = "Fruit"},
            };

            StringBuilder result = new StringBuilder();
            foreach (var item in oddsAndEnds)
            {
                result.Append(item.Name).Append(" ");
            }

            return View("Result", (object)result.ToString());
        }
    }
}