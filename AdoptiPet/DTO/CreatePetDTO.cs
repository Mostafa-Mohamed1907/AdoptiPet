namespace AdoptiPet.DTO
{
    public class CreatePetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public IFormFile Image { get; set; }

    }
}
