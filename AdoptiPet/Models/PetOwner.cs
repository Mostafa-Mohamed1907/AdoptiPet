using System.ComponentModel.DataAnnotations.Schema;

namespace AdoptiPet.Models
{
    public class PetOwner
    {
        [ForeignKey("Pet")]
        public int PetId { get; set; }
        [ForeignKey("Owner")]
        public int OwnerId { get; set; }

        public Pet Pet { get; set; }
        public Owner Owner { get; set; }
    }
}
