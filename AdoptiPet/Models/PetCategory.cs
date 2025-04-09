using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AdoptiPet.Models
{
    public class PetCategory
    {
        [ForeignKey("Pet")]
        public int PetId { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        [JsonIgnore]
        public Pet Pet { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }
    }
}
