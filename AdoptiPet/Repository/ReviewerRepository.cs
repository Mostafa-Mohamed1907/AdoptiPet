using AdoptiPet.Data;
using AdoptiPet.Models;
using Microsoft.EntityFrameworkCore;

namespace AdoptiPet.Repository
{
    public class ReviewerRepository : IReviewerRepository
    {
        private readonly DataContext context;

        public ReviewerRepository(DataContext context)
        {
            this.context = context;
        }
        public ICollection<Reviewer> GetReviewers()
        {
            return context.Reviewers.ToList();
        }

        public Reviewer GetById(int id)
        {
            return context.Reviewers.Where(r => r.Id == id).Include(d=>d.Reviews).FirstOrDefault();
        }

        public ICollection<Review> GetReviewsByReviewer(int reviewerId)
        {
            return context.Reviews.Where(r => r.Reviewer.Id == reviewerId).ToList();
        }

        public bool ReviewerExists(int reviewerId)
        {
            return context.Reviewers.Any(r => r.Id == reviewerId);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
