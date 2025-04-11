using System.Text.Json.Serialization;

namespace AdoptiPet.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Image { get; set; }
        [JsonIgnore]
        public ICollection<Review> Reviews { get; set; }
        [JsonIgnore]
        public ICollection<PetCategory> PetCategories { get; set; }
        [JsonIgnore]
        public ICollection<PetOwner> PetOwners { get; set; }
    }
}
