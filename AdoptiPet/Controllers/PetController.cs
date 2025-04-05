using AdoptiPet.DTO;
using AdoptiPet.Models;
using AdoptiPet.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdoptiPet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetRepository petRepository;
        private readonly IMapper mapper;

        public PetController(IPetRepository petRepository, IMapper mapper)
        {
            this.petRepository = petRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetPets()
        {
            var pets = mapper.Map<List<PetDTO>>(petRepository.GetPets());
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(pets);
        }
        [HttpGet("{petId}")]
        public IActionResult GetPetById(int petId)
        {
            var pet = mapper.Map<PetDTO>(petRepository.GetPet(petId));
            if (pet == null)
            {
                return NotFound();
            }
            return Ok(pet);
        }
        [HttpGet("{petId}/rating")]
        public IActionResult GetPetRating(int petId)
        {
            var pet = petRepository.GetPet(petId);
            if(pet == null)
                return NotFound();

            var rating = petRepository.GetPetRating(petId);
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(rating);
        }
        [HttpPost]
        public IActionResult CreatePet([FromBody] Pet pet)
        {
            if (pet == null)
            {
                return BadRequest();
            }
            petRepository.CreatePet(pet);
            return CreatedAtAction(nameof(GetPetById), new { petId = pet.Id }, pet);
        }
        [HttpPut("{petId}")]
        public IActionResult UpdatePet(int petId, [FromBody] Pet pet)
        {
            if (pet == null || petId != pet.Id)
            {
                return BadRequest();
            }
            Pet existingPet = petRepository.GetPet(petId);
            if (existingPet == null)
            {
                return NotFound();
            }
            petRepository.UpdatePet(pet);
            return NoContent();
        }
        [HttpDelete("{petId}")]
        public IActionResult DeletePet(int petId)
        {
            Pet pet = petRepository.GetPet(petId);
            if (pet == null)
            {
                return NotFound();
            }
            petRepository.DeletePet(pet);
            return NoContent();
        }
    }
}
