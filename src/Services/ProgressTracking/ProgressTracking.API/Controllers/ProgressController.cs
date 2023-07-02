using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProgressTracking.Domain.Dtos;
using ProgressTracking.Domain.Entities;
using ProgressTracking.Infrastructure.Repositories.Contracts;

namespace ProgressTracking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgressController : ControllerBase
    {
        private readonly IProgressRepository _progressRepository;
        private readonly IMapper _mapper;

        public ProgressController(IProgressRepository progressRepository, IMapper mapper)
        {
            _progressRepository = progressRepository;
            _mapper = mapper;
        }

        [HttpGet("courses/{courseId}")]
        public async Task<ActionResult<ProgressDto>> Get(Guid courseId, [FromQuery] string studentEmail)
        {
            var progress = await _progressRepository.GetProgressByCourseAndStudentAsync(courseId, studentEmail);

            if (progress is null)
            {
                return NotFound();
            }

            var progressDto = _mapper.Map<ProgressDto>(progress);

            return Ok(progressDto);
        }

        [HttpGet("courses")]
        public async Task<ActionResult<IEnumerable<ProgressDto>>> Get([FromQuery] string studentEmail)
        {
            var progressList = await _progressRepository.GetLatestProgressByStudentAsync(studentEmail);

            var progressDtoList = progressList.Select(prog => _mapper.Map<ProgressDto>(prog));

            return Ok(progressDtoList);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProgressDto progressDto)
        {
            var existingProgress = await _progressRepository.GetProgressByCourseAndStudentAsync(progressDto.CourseId, progressDto.StudentEmail);

            if (existingProgress is null)
            {
                var progress = _mapper.Map<Progress>(progressDto);

                await _progressRepository.AddProgressAsync(progress);

                return NoContent();
            }

            existingProgress.CourseFinished = progressDto.CourseFinished;
            existingProgress.LessonId = progressDto.LessonId;

            await _progressRepository.UpdateProgressAsync(existingProgress);

            return NoContent();

        }
    }
}
