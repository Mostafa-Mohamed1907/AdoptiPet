using AdoptiPet.DTO;
using AdoptiPet.Models;
using AdoptiPet.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AdoptiPet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = mapper.Map<List<CategoryDTO>>(categoryRepository.GetCategories());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(categories);
        }
        [HttpGet("{categoryId}")]
        public IActionResult GetPetById(int categoryId)
        {
            var category = mapper.Map<CategoryDTO>(categoryRepository.GetById(categoryId));
            if (!categoryRepository.CategoryExist(categoryId))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(category);
        }

        [HttpGet("Pet/{categoryId}")]
        public IActionResult GetPetByCategory(int categoryId)
        {
            var Pets = mapper.Map<List<PetDTO>>(categoryRepository.GetPetByCategory(categoryId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(Pets);

        }
    }
}
