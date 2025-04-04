using System.ComponentModel.DataAnnotations.Schema;

namespace AdoptiPet.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }

        [ForeignKey("Reviewer")]
        public int ReviewId { get; set; }
        public Reviewer Reviewer { get; set; }

        [ForeignKey("Pet")]
        public int PetId { get; set; }
        public Pet Pet { get; set; }
    }
}
