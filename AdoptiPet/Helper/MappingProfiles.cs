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
            CreateMap<PetDTO, Pet>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<Country, CountryDTO>();
            CreateMap<CountryDTO, Country>();
            CreateMap<Owner, OwnerDTO>();
            CreateMap<Review, ReviewDTO>();
            CreateMap<Reviewer, ReviewerDTO>();
        }
    }
}
