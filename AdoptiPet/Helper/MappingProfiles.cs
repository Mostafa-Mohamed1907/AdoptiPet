using AdoptiPet.DTO;
using AdoptiPet.Models;
using AutoMapper;

namespace AdoptiPet.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pet, PetDTO>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<Country, CountryDTO>();
            CreateMap<Owner, OwnerDTO>();
            CreateMap<Review, ReviewDTO>();
            CreateMap<Reviewer, ReviewerDTO>();
        }
    }
}
