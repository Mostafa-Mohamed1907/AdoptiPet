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
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerRepository ownerRepository;
        private readonly ICountryRepository countryRepository;
        private readonly IMapper mapper;

        public OwnerController(IOwnerRepository ownerRepository, ICountryRepository countryRepository, IMapper mapper)
        {
            this.ownerRepository = ownerRepository;
            this.countryRepository = countryRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetOwners()
        {
            var owners = mapper.Map<List<OwnerDTO>>(ownerRepository.GetOwners());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(owners);
        }
        [HttpGet("{ownerId}", Name = "GetOwnerById")]
        public IActionResult GetOwnerById(int ownerId)
        {
            var owner = mapper.Map<OwnerDTO>(ownerRepository.GetById(ownerId));
            if (!ownerRepository.OwnerExists(ownerId))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(owner);
        }
        [HttpGet("{ownerId}/pet")]
        public IActionResult GetPetByOwner(int ownerId)
        {
            var Pets = mapper.Map<List<PetDTO>>(ownerRepository.GetPetByOwner(ownerId));
            if (!ownerRepository.OwnerExists(ownerId))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(Pets);
        }
        [HttpGet("/Owner/{petId}")]
        public IActionResult GetOwnersOfAPet(int petId)
        {
            var owners = mapper.Map<List<OwnerDTO>>(ownerRepository.GetOwnersOfAPet(petId));
            if (!ownerRepository.OwnerExists(petId))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(owners);
        }

        [HttpPost]
        public IActionResult CreateOwner([FromBody] OwnerDTO ownerDto)
        {
            if (ownerDto == null)
                return BadRequest(ModelState);
            if (ownerRepository.OwnerExists(ownerDto.Id))
            {
                ModelState.AddModelError("", "Owner already exists");
                return StatusCode(422, ModelState);
            }
            if (!countryRepository.CountryExists(ownerDto.CountryId))
            {
                ModelState.AddModelError("CountryId", "Invalid Country ID.");
                return BadRequest(ModelState);
            }
            var owner = mapper.Map<Owner>(ownerDto);
            ownerRepository.CreateOwner(owner);
            return CreatedAtRoute("GetOwnerById", new { ownerId = owner.Id }, owner);
        }
        [HttpDelete("{ownerId}")]
        public IActionResult DeleteOwner(int ownerId)
        {
            if (!ownerRepository.OwnerExists(ownerId))
                return NotFound();
            var ownerToDelete = ownerRepository.GetById(ownerId);
            ownerRepository.DeleteOwner(ownerToDelete);
            return Ok("Review deleted successfully");
        }
    }
}
