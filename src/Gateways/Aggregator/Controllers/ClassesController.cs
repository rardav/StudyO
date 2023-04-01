using Aggregator.Models;
using Aggregator.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Aggregator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassesController : ControllerBase
    {
        private readonly IClassService _classService;
        private readonly ICatalogService _catalogService;

        public ClassesController(IClassService classService, ICatalogService catalogService)
        {
            _classService = classService;
            _catalogService = catalogService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClassModel>> GetClass(Guid id)
        {
            var clss = await _classService.GetClass(id);

            if (clss == null)
            {
                return NotFound();
            }

            foreach (var assignment in clss.Assignments)
            {
                assignment.Course = await _catalogService.GetCourse(assignment.CourseId);
            }

            return Ok(clss);
        }
    }
}
