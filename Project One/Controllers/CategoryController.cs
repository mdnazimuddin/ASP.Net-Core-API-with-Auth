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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            var result = _categoryRepository.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _categoryRepository.Get(id);
            return Ok(result);
        }

        [HttpPost]
       public IActionResult Create([FromBody]Category category)
        {
            var result = _categoryRepository.Create(category);
            return Ok(result);
        }

        [HttpPost("{id}")]
        public IActionResult Update(int id,Category category)
        {
            var result = _categoryRepository.Update(id, category);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _categoryRepository.Delete(id);
            return Ok(result);
        }
    }
}
