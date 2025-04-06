using AdoptiPet.DTO;
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
        private readonly IMapper mapper;

        public OwnerController(IOwnerRepository ownerRepository, IMapper mapper)
        {
            this.ownerRepository = ownerRepository;
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
        [HttpGet("{ownerId}")]
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
    }
}
