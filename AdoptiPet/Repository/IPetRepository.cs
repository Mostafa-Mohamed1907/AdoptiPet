using AdoptiPet.Data;
using AdoptiPet.Models;

namespace AdoptiPet.Repository
{
    public interface IPetRepository
    {
        public ICollection<Pet> GetPets();
        public Pet GetPet(int petId);
        public int GetPetRating(int petId);
        public void CreatePet(Pet pet);
        public void UpdatePet(Pet pet);
        public void DeletePet(Pet pet);
        public void Save();
    }
}
