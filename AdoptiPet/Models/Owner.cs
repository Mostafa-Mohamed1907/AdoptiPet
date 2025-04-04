using System.ComponentModel.DataAnnotations.Schema;

namespace AdoptiPet.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gym { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<PetOwner> PetOwners { get; set; }
    }
}
