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
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository countryRepository;
        private readonly IMapper mapper;

        public CountryController(ICountryRepository countryRepository, IMapper mapper)
        {
            this.countryRepository = countryRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetCountries()
        {
            var countries = mapper.Map<List<CountryDTO>>(countryRepository.GetCountries());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(countries);
        }
        [HttpGet("{countryId}")]
        public IActionResult GetCountryById(int countryId)
        {
            var country = mapper.Map<CountryDTO>(countryRepository.GetById(countryId));
            if (!countryRepository.CountryExists(countryId))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(country);
        }
        [HttpGet("/owners/{ownerId}")]
        public IActionResult GetCountryOfAnOwner(int ownerId)
        {
            var country = mapper.Map<CountryDTO>(countryRepository.GetCountryByOwner(ownerId));
            if (country==null)
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(country);
        }
        [HttpGet("/country/{countryId}")]
        public IActionResult GetOwnersOfAnCountry(int countryId)
        {
            var owners = mapper.Map<List<OwnerDTO>>(countryRepository.GetOwnersFromCountry(countryId)); 
            if (!countryRepository.CountryExists(countryId))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(owners);
        }
    }
}
