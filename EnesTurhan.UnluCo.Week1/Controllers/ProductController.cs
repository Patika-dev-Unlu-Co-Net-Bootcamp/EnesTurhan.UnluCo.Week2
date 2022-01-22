using EnesTurhan.UnluCo.Week1.Entities;
using EnesTurhan.UnluCo.Week1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnesTurhan.UnluCo.Week1.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly SmtpMailService _smtpMailService;
        private readonly GoogleService _googleService;
        private readonly AddressService _adressService;
        public ProductController(SmtpMailService smtpMailService, GoogleService googleService,AddressService addressService)
        {
            _smtpMailService = smtpMailService;
            _googleService = googleService;
            _adressService = addressService;


        }
        private static List<Product> productList = new()
        {
            new Product(1,"kola",5,55),
            new Product(2,"ayran",6,56),
            new Product(3,"meyvesuyu",7,23),
            new Product(4,"soda",8,40)

        };
     
        [HttpGet]
        public List<Product> GetProducts()
        {
            var list = productList.OrderBy(x => x.Id).ToList();
            return list;

        }
        [HttpGet("{id}")]
        public IActionResult GetProductsById(int id)
        {
            
            var product = productList.Where(x => x.Id == id).SingleOrDefault();

            if (product == null)
            {
                return BadRequest();
            }
            return Ok(product);

        }
        //[HttpGet]
        //public Book GetBookByIdWithQuery([FromQuery]int id)
        //{
        //    var book = bookList.Where(x => x.Id == id).SingleOrDefault();

        //    return book;

        //}
     
        [HttpPost]
        public IActionResult AddProduct([FromBody] Product newProduct)
        {
            var product = productList.SingleOrDefault(x => x.Name == newProduct.Name);


            if (product is not null)
            {
                return BadRequest();

            }
           
            productList.Add(newProduct);
            return Ok();

        }
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            var product = productList.SingleOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            product.Id = updatedProduct.Id != default ? updatedProduct.Id : product.Id;
            product.Name = updatedProduct.Name != default ? updatedProduct.Name : product.Name;
              //  product.IsPromotion = updatedProduct.IsPromotion != default ? updatedProduct.IsPromotion : product.IsPromotion;
    

            return Ok();


        }
        [HttpPatch("{id}")]
        public IActionResult UpdateProductWithPatch(int id, [FromBody] Product updatedProduct)
        {
            var product = productList.SingleOrDefault(x => x.Id == id);
            if (product == null)
            {
                return BadRequest();
            }

            product.Name = updatedProduct.Name != default ? updatedProduct.Name : product.Name;

            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var product = productList.Where(x => x.Id == id).FirstOrDefault();

            if (product == null)
                return BadRequest();



            productList.Remove(product);
            return Ok();
        }
    }
}
