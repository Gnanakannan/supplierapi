using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using supplierapi.Models;
using supplierapi.Services;

namespace supplierapi.Controllers
{
    public class ProductAdminController : Controller
    {
        private readonly ILogger<ProductAdminController> _logger;
        private readonly ProductService _productService;

        public ProductAdminController(ILogger<ProductAdminController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public ActionResult<List<Product>> GetAll() =>
            _productService.Get();


        //[HttpGet("{id:length(24)}", Name = "Get")]
        public ActionResult<Product> Get(string id)
        {
            var product = _productService.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        public ActionResult<Product> GetByProductCode(string productCode)
        {
            var product = _productService.GetByProductCode(productCode);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost]
        public ActionResult<Product> Create(Product product)
        {
            _productService.Create(product);

            return CreatedAtRoute("GetProduct", new { id = product.Id.ToString() }, product);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Product productIn)
        {
            var product = _productService.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            _productService.Update(id, productIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var product = _productService.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            _productService.Remove(product.Id);

            return NoContent();
        }

        public IActionResult Index()
        {
            return View();
        }        
    }
}
