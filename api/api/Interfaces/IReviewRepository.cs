using api.Models;

namespace api.Interfaces
{
    public interface IReviewRepository
    {
        Task<Review> AddReview(Review review);
        Task<List<Review>> GetReviewsByServiceId(int serviceId);
        Task<Review> GetReviewById(int reviewId);
        Task<List<Review>> GetReviewsByClientId(int clientId);
    }
}
