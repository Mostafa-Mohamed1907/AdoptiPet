namespace AdoptiPet.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public ICollection<Review> Reviews { get; set; }
        public ICollection<PetCategory> PetCategories { get; set; }
        public ICollection<PetOwner> PetOwners { get; set; }
    }
}
