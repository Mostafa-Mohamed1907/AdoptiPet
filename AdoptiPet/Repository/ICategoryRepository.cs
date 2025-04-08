using AdoptiPet.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AdoptiPet.Repository
{
    public interface ICategoryRepository
    {
        public ICollection<Category> GetCategories();
        public Category GetById(int id);
        public ICollection<Pet> GetPetByCategory(int categoryId);
        public bool CategoryExist(int id);
        public void CreateCategory(Category category);
        public void Save();
    }
}
