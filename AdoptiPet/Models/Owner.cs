using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AdoptiPet.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gym { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }
        [JsonIgnore]
        public Country Country { get; set; }
        [JsonIgnore]
        public ICollection<PetOwner> PetOwners { get; set; }
    }
}
