using AdoptiPet.Models;

namespace AdoptiPet.Repository
{
    public interface ICountryRepository
    {
        public ICollection<Country> GetCountries();
        public Country GetById(int id);
        public Country GetCountryByOwner(int ownerId);
        public ICollection<Owner> GetOwnersFromCountry(int countryId);
        public bool CountryExists(int id);
        public void CreateCountry(Country country);
        public void Save();


    }
}
