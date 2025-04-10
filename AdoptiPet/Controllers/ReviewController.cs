using AdoptiPet.DTO;
using AdoptiPet.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdoptiPet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository reviewRepository;
        private readonly IReviewerRepository reviewerRepository;
        private readonly IPetRepository petRepository;
        private readonly IMapper mapper;

        public ReviewController(IReviewRepository reviewRepository, IMapper mapper,
            IReviewerRepository reviewerRepository, IPetRepository petRepository)
        {
            this.reviewRepository = reviewRepository;
            this.reviewerRepository = reviewerRepository;
            this.petRepository = petRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetReviews()
        {
            var reviews = mapper.Map<List<ReviewDTO>>(reviewRepository.GetReviews());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(reviews);
        }
        [HttpGet("{reviewId}", Name = "GetReviewById")]
        public IActionResult GetReviewById(int reviewId)
        {
            var review = mapper.Map<ReviewDTO>(reviewRepository.GetById(reviewId));
            if (!reviewRepository.ReviewExists(reviewId))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(review);
        }
        [HttpGet("/pet/{petId}")]
        public IActionResult GetReviewsForPet(int petId)
        {
            var review = mapper.Map<List<ReviewDTO>>(reviewRepository.GetReviewsOfAPet(petId));
            if (!reviewRepository.ReviewExists(petId))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(review);
        }
        [HttpPost]
        public IActionResult CreateReview([FromBody] ReviewDTO reviewDto)
        {
            if (reviewDto == null)
                return BadRequest("Review data is required.");
            if (reviewDto.Rating < 1 || reviewDto.Rating > 5)
            {
                return BadRequest("Rating must be between 1 and 5.");
            }
            if (!reviewerRepository.ReviewerExists(reviewDto.ReviewerId))
            {
                return NotFound($"Reviewer with ID {reviewDto.ReviewerId} does not exist.");
            }
            if (!petRepository.PetExists(reviewDto.PetId))
            {
                return NotFound($"Pet with ID {reviewDto.PetId} does not exist.");
            }
            var review = mapper.Map<Models.Review>(reviewDto);
            reviewRepository.CreateReview(review);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok("Review created successfully");
        }
        [HttpPut("{reviewId}")]
        public IActionResult UpdateReview(int reviewId, [FromBody] ReviewDTO reviewDto)
        {
            if (reviewDto == null || reviewId != reviewDto.Id || !ModelState.IsValid)
                return BadRequest(ModelState);
            if (!reviewRepository.ReviewExists(reviewId))
                return NotFound();
            if (reviewDto.Rating < 1 & reviewDto.Rating > 5)
            {
                return BadRequest("Rating must be between 1 and 5.");
            }
            if (!reviewerRepository.ReviewerExists(reviewDto.ReviewerId))
            {
                return NotFound($"Reviewer with ID {reviewDto.ReviewerId} does not exist.");
            }
            if (!petRepository.PetExists(reviewDto.PetId))
            {
                return NotFound($"Pet with ID {reviewDto.PetId} does not exist.");
            }
            var reviewMap = mapper.Map<Models.Review>(reviewDto);
            reviewRepository.UpdateReview(reviewMap);
            return Ok("Review updated successfully");
        }
        [HttpDelete("{reviewId}")]
        public IActionResult DeleteReview(int reviewId)
        {
            if (!reviewRepository.ReviewExists(reviewId))
                return NotFound();
            var review = reviewRepository.GetById(reviewId);
            reviewRepository.DeleteReview(review);
            return Ok("Review deleted successfully");
        }
    }
}
