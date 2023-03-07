using StudyO.Courses.Domain.Entities;

namespace StudyO.Courses.Infrastructure.Repositories.Contracts
{
    public interface ICoursesRepository
    {
        Task CreateAsync(Course course);
        Task<IReadOnlyCollection<Course>> GetAllAsync();
        Task<Course> GetAsync(Guid id);
    }
}
