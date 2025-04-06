﻿using AdoptiPet.Models;

namespace AdoptiPet.Repository
{
    public interface IOwnerRepository
    {
        public ICollection<Owner> GetOwners();
        public Owner GetById(int id);
        public ICollection<Owner> GetOwnersOfAPet(int petId);
        public ICollection<Pet> GetPetByOwner(int ownerId);
        public bool OwnerExists(int ownerId);
        public void Save();
    }
}
