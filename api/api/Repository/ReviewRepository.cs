using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;

        public ReviewRepository(DataContext context)
        {
            _context = context;
        }

        // Add a new review
        public async Task<Review> AddReview(Review review)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return review;
        }

        // Get reviews by service ID
        public async Task<List<Review>> GetReviewsByServiceId(int serviceId)
        {
            return await _context.Reviews
                .Where(r => r.ServiceID == serviceId)
                .ToListAsync();
        }

        // Get review by review ID
        public async Task<Review> GetReviewById(int reviewId)
        {
            return await _context.Reviews
                .FirstOrDefaultAsync(r => r.ReviewID == reviewId);
        }

        // Get reviews by client ID
        public async Task<List<Review>> GetReviewsByClientId(int clientId)
        {
            return await _context.Reviews
                .Where(r => r.ClientID == clientId)
                .ToListAsync();
        }
    }
}
