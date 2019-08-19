using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductsApp.Models;
using System.Web.Http.Cors;

namespace ProductsApp.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProductsController : ApiController
    {
        Products[] products = new Products[]
        {
            new Products { ID = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Products { ID = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Products { ID = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };

        public IEnumerable<Products> GetAllProducts()
        {
            return products;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.ID == id);
            if (product == null)
            {
                return NotFound();
            }
            else
                return Ok(product);
        }
    }

}
