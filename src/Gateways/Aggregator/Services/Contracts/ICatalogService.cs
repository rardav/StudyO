using Aggregator.Models;

namespace Aggregator.Services.Contracts
{
    public interface ICatalogService
    {
        Task<IEnumerable<CourseModel>> GetCourses();
        Task<CourseModel> GetCourse(Guid id);
    }
}
