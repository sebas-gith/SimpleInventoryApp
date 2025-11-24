using Microsoft.AspNetCore.Mvc;
using InventoryAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 1200.50m, Stock = 10 },
            new Product { Id = 2, Name = "Mouse", Price = 25.00m, Stock = 50 }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return Ok(products);
        }

        [HttpPost]
        public ActionResult<Product> CreateProduct(Product newProduct)
        {
            newProduct.Id = products.Count > 0 ? products.Max(p => p.Id) + 1 : 1;
            
            products.Add(newProduct);
            return CreatedAtAction(nameof(GetProducts), new { id = newProduct.Id }, newProduct);
        }
    }
}