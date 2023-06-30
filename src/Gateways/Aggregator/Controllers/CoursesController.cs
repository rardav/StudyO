using Aggregator.Models;
using Aggregator.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Aggregator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ICatalogService _catalogService;
        private readonly IReviewsService _reviewsService;

        public CoursesController(ICatalogService catalogService, IReviewsService reviewsService)
        {
            _catalogService = catalogService;
            _reviewsService = reviewsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseModel>>> GetCourses()
        {
            var courses = await _catalogService.GetCourses();

            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseModel>> GetCourse(Guid id)
        {
            var course = await _catalogService.GetCourse(id);

            if (course == null)
            {
                return NotFound();
            }

            course.Reviews = await _reviewsService.GetReviewsAsync(course.Id);

            return Ok(course);
        }
    }
}