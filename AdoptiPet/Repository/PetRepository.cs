using AdoptiPet.Data;
using AdoptiPet.Models;
using Microsoft.EntityFrameworkCore;

namespace AdoptiPet.Repository
{
    public class PetRepository : IPetRepository
    {
        private readonly DataContext context;

        public PetRepository(DataContext context)
        {
            this.context = context;
        }
        public ICollection<Pet> GetPets()
        {
            return context.Pets.OrderBy(p => p.Id).ToList();
        }

        public Pet GetPet(int petId)
        {
            return context.Pets.FirstOrDefault(p => p.Id == petId);
        }

        public void CreatePet(Pet pet)
        {
            context.Pets.Add(pet);
        }

        public void DeletePet(Pet pet)
        {
            context.Pets.Remove(pet);
        }
        public void UpdatePet(Pet pet)
        {
            context.Update(pet);
        }
        public int GetPetRating(int petId)
        {
            var review = context.Reviews.Where(p => p.Id == petId);
            if (review.Count() <= 0)
            {
                return 0;
            }
            return ((int) review.Sum(r => r.Rating) / review.Count());
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
    
}
