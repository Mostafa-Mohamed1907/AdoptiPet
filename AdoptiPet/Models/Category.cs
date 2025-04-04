namespace AdoptiPet.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PetCategory> PetCategories { get; set; }

    }
}
