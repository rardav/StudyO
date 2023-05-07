using Aggregator.Models;
using Aggregator.Services;
using Aggregator.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Aggregator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ICatalogService _catalogService;

        public CoursesController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseModel>>> GetCourses()
        {
            var courses = await _catalogService.GetCourses();

            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClassModel>> GetCourse(Guid id)
        {
            var clss = await _catalogService.GetCourse(id);

            if (clss == null)
            {
                return NotFound();
            }

            return Ok(clss);
        }
    }
}