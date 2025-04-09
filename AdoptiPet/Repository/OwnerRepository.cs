using AdoptiPet.Data;
using AdoptiPet.Models;

namespace AdoptiPet.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext context;

        public OwnerRepository(DataContext context)
        {
            this.context = context;
        }
        public ICollection<Owner> GetOwners()
        {
            return context.Owners.ToList();
        }
        public Owner GetById(int id)
        {
            return context.Owners.Where(o => o.Id == id).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnersOfAPet(int petId)
        {
            return context.PetOwners.Where(p => p.PetId == petId).Select(o => o.Owner).ToList();
        }

        public ICollection<Pet> GetPetByOwner(int ownerId)
        {
            return context.PetOwners.Where(o => o.Owner.Id == ownerId).Select(p => p.Pet).ToList();
        }

        public bool OwnerExists(int ownerId)
        {
            return context.Owners.Any(o => o.Id == ownerId);
        }
        public void CreateOwner(Owner owner)
        {
            context.Owners.Add(owner);
            Save();
        }
        public void DeleteOwner(Owner owner)
        {
            context.Owners.Remove(owner);
            Save();
        }
        public void Save()
        {
            context.SaveChanges();
        }

        
    }
}
