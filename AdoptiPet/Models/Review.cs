using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AdoptiPet.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }

        [ForeignKey("Reviewer")]
        public int ReviewerId { get; set; }
        [JsonIgnore]
        public Reviewer Reviewer { get; set; }

        [ForeignKey("Pet")]
        public int PetId { get; set; }
        [JsonIgnore]
        public Pet Pet { get; set; }
    }
}
