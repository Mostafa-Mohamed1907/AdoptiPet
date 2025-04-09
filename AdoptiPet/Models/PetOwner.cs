using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AdoptiPet.Models
{
    public class PetOwner
    {
        [ForeignKey("Pet")]
        public int PetId { get; set; }
        [ForeignKey("Owner")]
        public int OwnerId { get; set; }
        [JsonIgnore]
        public Pet Pet { get; set; }
        [JsonIgnore]
        public Owner Owner { get; set; }
    }
}
