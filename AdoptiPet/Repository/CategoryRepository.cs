using AdoptiPet.Data;
using AdoptiPet.Models;

namespace AdoptiPet.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext context;

        public CategoryRepository(DataContext context)
        {
            this.context = context;
        }
        public ICollection<Category> GetCategories()
        {
            return context.Categories.OrderBy(c => c.Id).ToList();
        }
        public Category GetById(int id)
        {
            return context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public ICollection<Pet> GetPetByCategory(int categoryId)
        {
            return context.PetCategories.Where(p => p.CategoryId == categoryId).Select(p => p.Pet).ToList();
        }
        public bool CategoryExist(int id)
        {
            return context.Categories.Any(c => c.Id == id);
        }

        public void CreateCategory(Category category)
        {
            context.Categories.Add(category);
            Save();
        }
        public void DeleteCategory(Category category)
        {
            context.Categories.Remove(category);
            Save();
        }
        public void Save()
        {
            context.SaveChanges();
        }

        
    }
}
