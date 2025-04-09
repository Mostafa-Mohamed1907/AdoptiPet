using System.Text.Json.Serialization;

namespace AdoptiPet.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<PetCategory> PetCategories { get; set; }

    }
}
