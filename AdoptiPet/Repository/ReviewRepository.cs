using AdoptiPet.Data;
using AdoptiPet.Models;
using AutoMapper;

namespace AdoptiPet.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public ReviewRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public ICollection<Review> GetReviews()
        {
            return context.Reviews.ToList();
        }
        public Review GetById(int id)
        {
            return context.Reviews.Where(r => r.Id == id).FirstOrDefault();
        }

        public ICollection<Review> GetReviewsOfAPet(int petId)
        {
            return context.Reviews.Where(r => r.Pet.Id == petId).ToList();
        }

        public bool ReviewExists(int reviewId)
        {
            return context.Reviews.Any(r => r.Id == reviewId);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
