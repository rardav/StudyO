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
        Task AddLessonAsync(Guid courseId, Guid chapterId, Lesson lesson);
        Task AddSectionAsync(Guid courseId, Guid chapterId, Guid lessonId, Section section);
    }
}
