using AdoptiPet.DTO;
using AdoptiPet.Models;
using AdoptiPet.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdoptiPet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewerController : ControllerBase
    {
        private readonly IReviewerRepository reviewerRepository;
        private readonly IMapper mapper;

        public ReviewerController(IReviewerRepository reviewerRepository, IMapper mapper)
        {
            this.reviewerRepository = reviewerRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetReviewers()
        {
            var reviewers = mapper.Map<List<ReviewerDTO>>(reviewerRepository.GetReviewers());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(reviewers);
        }
        [HttpGet("{reviewerId}", Name = "GetReviewerById")]
        public IActionResult GetReviewerById(int reviewerId)
        {
            var reviewer = mapper.Map<ReviewerDTO>(reviewerRepository.GetById(reviewerId));
            if (!reviewerRepository.ReviewerExists(reviewerId))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(reviewer);
        }
        [HttpGet("{reviewerId}/reviews")]
        public IActionResult GetReviewsByReviewer(int reviewerId)
        {
            var reviews = mapper.Map<List<ReviewDTO>>(reviewerRepository.GetReviewsByReviewer(reviewerId));
            if (!reviewerRepository.ReviewerExists(reviewerId))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(reviews);
        }
        [HttpPost]
        public IActionResult CreateReviewer([FromBody] ReviewerDTO reviewerDto)
        {
            if (reviewerDto == null)
                return BadRequest("Reviewer data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var reviewer = mapper.Map<Reviewer>(reviewerDto);
            reviewerRepository.CreateReviewer(reviewer);
            return CreatedAtRoute("GetReviewerById", new { reviewerId = reviewer.Id }, reviewer);
        }
        [HttpPut("{reviewerId}")]
        public IActionResult UpdateReviewer(int reviewerId, [FromBody] ReviewerDTO reviewerDto)
        {
            if (reviewerDto == null || reviewerId != reviewerDto.Id || !ModelState.IsValid)
                return BadRequest(ModelState);  
            if (!reviewerRepository.ReviewerExists(reviewerId))
                return NotFound();
            var reviewer = mapper.Map<Reviewer>(reviewerDto);
            reviewerRepository.UpdateReviewer(reviewer);
            return Ok("Reviewer Updated successfully");
        }
        [HttpDelete("{reviewerId}")]
        public IActionResult DeleteReviewer(int reviewerId)
        {
            if (!reviewerRepository.ReviewerExists(reviewerId))
                return NotFound();
            var reviewer = reviewerRepository.GetById(reviewerId);
            reviewerRepository.DeleteReviewer(reviewer);
            return Ok("Reviewer deleted successfully");
        } 
    }
}
