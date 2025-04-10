using AdoptiPet.Models;

namespace AdoptiPet.Repository
{
    public interface IReviewRepository
    {
        public ICollection<Review> GetReviews();
        public Review GetById(int id);
        public ICollection<Review> GetReviewsOfAPet(int petId);
        public bool ReviewExists(int reviewId);
        public void CreateReview(Review review);
        public void UpdateReview(Review review);
        public void DeleteReview(Review review);
        public void Save();
    }
}
