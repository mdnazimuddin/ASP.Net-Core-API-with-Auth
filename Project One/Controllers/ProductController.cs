using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_One.Interface;
using Project_One.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_One.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            var result = _productRepository.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _productRepository.Get(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Product product)
        {
            var result = _productRepository.Create(product);
            return Ok(result);
        }

        [HttpPost("{id}")]
        public IActionResult Update(int id, Product product)
        {
            var result = _productRepository.Update(id, product);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _productRepository.Delete(id);
            return Ok(result);
        }
    }
}
