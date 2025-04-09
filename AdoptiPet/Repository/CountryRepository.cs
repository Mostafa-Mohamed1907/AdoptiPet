using AdoptiPet.Data;
using AdoptiPet.Models;

namespace AdoptiPet.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext context;

        public CountryRepository(DataContext context)
        {
            this.context = context;
        }

        public ICollection<Country> GetCountries()
        {
            return context.Countries.ToList();
        }
        public Country GetById(int id)
        {
            return context.Countries.Where(c => c.Id == id).FirstOrDefault();
        }
        public bool CountryExists(int id)
        {
            return context.Countries.Any(c => c.Id == id);
        }

        public Country GetCountryByOwner(int ownerId)
        {
            return context.Owners.Where(o => o.Id == ownerId).Select(o => o.Country).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnersFromCountry(int countryId)
        {
            return context.Owners.Where(o => o.CountryId == countryId).ToList();
        }

        public void CreateCountry(Country country)
        {
            context.Countries.Add(country);
            Save();
        }
        public void DeleteCountry(Country country)
        {
            context.Countries.Remove(country);
            Save();
        }
        public void Save()
        {
            context.SaveChanges();
        }


    }
}
