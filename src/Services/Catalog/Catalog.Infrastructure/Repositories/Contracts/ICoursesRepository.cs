using Catalog.Domain.Entities;

namespace Catalog.Infrastructure.Repositories.Contracts
{
    public interface ICoursesRepository
    {
        Task<IReadOnlyCollection<Course>> GetAllAsync();
        Task<Course> GetAsync(Guid id);
        Task CreateAsync(Course course);
        Task UpdateAsync(Course course);
        Task RemoveAsync(Guid id);
        Task AddChapterAsync(Guid courseId, Chapter chapter);
        Task AddLessonAsync(Course course, Guid chapterId, Lesson lesson);
        Task AddSectionAsync(Course course, Guid chapterId, Guid lessonId, Section section);
    }
}
