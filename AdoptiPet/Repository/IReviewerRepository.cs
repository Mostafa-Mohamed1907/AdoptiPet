using AdoptiPet.Models;

namespace AdoptiPet.Repository
{
    public interface IReviewerRepository
    {
        public ICollection<Reviewer> GetReviewers();
        public Reviewer GetById(int id);
        public ICollection<Review> GetReviewsByReviewer(int reviewerId);
        public bool ReviewerExists(int reviewerId);
        public void CreateReviewer(Reviewer reviewer);
        public void DeleteReviewer(Reviewer reviewer);
        public void Save();
    }
}
