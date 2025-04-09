using System.Text.Json.Serialization;

namespace AdoptiPet.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Owner> Owners { get; set; }
    }
}
