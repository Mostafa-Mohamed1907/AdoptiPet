using System.ComponentModel.DataAnnotations.Schema;

namespace AdoptiPet.Models
{
    public class PetCategory
    {
        [ForeignKey("Pet")]
        public int PetId { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Pet Pet { get; set; }
        public Category Category { get; set; }
    }
}
