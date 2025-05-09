﻿using AdoptiPet.DTO;
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
        [HttpPost]
        public IActionResult CreateCategory([FromBody] CategoryDTO categoryDto)
        {
            if (categoryDto == null)
                return BadRequest(ModelState);

            var category = categoryRepository.GetCategories()
                .FirstOrDefault(c => c.Name.Trim().ToUpper() == categoryDto.Name.Trim().ToUpper());

            if (category != null)
            {
                ModelState.AddModelError("", "Category already exists");
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var categoryMap = mapper.Map<Category>(categoryDto);
            categoryRepository.CreateCategory(categoryMap);
            return Ok("Created Successfully");
        }

        [HttpPut("{categoryId}")]
        public IActionResult UpdateCategory(int categoryId, [FromBody] CategoryDTO categoryDto)
        {
            if (categoryDto == null || categoryId != categoryDto.Id || !ModelState.IsValid)
                return BadRequest(ModelState);
            if (!categoryRepository.CategoryExist(categoryId))
                return NotFound();
            var categoryMap = mapper.Map<Category>(categoryDto);
            categoryRepository.UpdateCategory(categoryMap);
            return Ok("Updated Successfully");
        }

        [HttpDelete("{categoryId}")]
        public IActionResult DeleteCategory(int categoryId)
        {
            if (!categoryRepository.CategoryExist(categoryId))
                return NotFound();
            var category = categoryRepository.GetById(categoryId);
            categoryRepository.DeleteCategory(category);
            return Ok("Category deleted Successfully");
        }
    
        

    }
}
