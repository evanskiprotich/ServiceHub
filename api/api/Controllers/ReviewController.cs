using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        // POST: api/review
        [HttpPost]
        public async Task<IActionResult> AddReview([FromBody] Review review)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var createdReview = await _reviewRepository.AddReview(review);
            return CreatedAtAction(nameof(GetReviewById), new { id = createdReview.ReviewID }, createdReview);
        }

        // GET: api/review/service/{serviceId}
        [HttpGet("service/{serviceId}")]
        public async Task<IActionResult> GetReviewsByServiceId(int serviceId)
        {
            var reviews = await _reviewRepository.GetReviewsByServiceId(serviceId);
            if (reviews == null || reviews.Count == 0) return NotFound("No reviews found for the specified service.");

            return Ok(reviews);
        }

        // GET: api/review/{reviewId}
        [HttpGet("{reviewId}")]
        public async Task<IActionResult> GetReviewById(int reviewId)
        {
            var review = await _reviewRepository.GetReviewById(reviewId);
            if (review == null) return NotFound();

            return Ok(review);
        }

        // GET: api/review/client/{clientId}
        [HttpGet("client/{clientId}")]
        public async Task<IActionResult> GetReviewsByClientId(int clientId)
        {
            var reviews = await _reviewRepository.GetReviewsByClientId(clientId);
            if (reviews == null || reviews.Count == 0) return NotFound("No reviews found for the specified client.");

            return Ok(reviews);
        }
    }
}
