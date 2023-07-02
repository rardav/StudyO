using Aggregator.Models;
using Aggregator.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Aggregator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgressController : ControllerBase
    {
        private readonly IProgressService _progressService;
        private readonly ICatalogService _catalogService;

        public ProgressController(IProgressService progressService, ICatalogService catalogService)
        {
            _progressService = progressService;
            _catalogService = catalogService;
        }

        [HttpGet]
        public async Task<ActionResult<ProgressModel>> GetProgress([FromQuery] string studentEmail)
        {
            var progressList = await _progressService.GetLatestProgressByEmail(studentEmail);

            foreach (var progress in progressList)
            {
                progress.Course = await _catalogService.GetCourse(progress.CourseId);
            }

            return Ok(progressList);
        }
    }
}
