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

        public void CreateReview(Review review)
        {
            context.Reviews.Add(review);
            Save();
        }

        public void UpdateReview(Review review)
        {
            context.Reviews.Update(review);
            Save();
        }
        public void DeleteReview(Review review)
        {
            context.Reviews.Remove(review);
            Save();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
