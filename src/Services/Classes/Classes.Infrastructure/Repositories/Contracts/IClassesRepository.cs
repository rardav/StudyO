using Classes.Domain.Entities;

namespace Classes.Infrastructure.Repositories.Contracts
{
    public interface IClassesRepository
    {
        Task<IReadOnlyCollection<Class>> GetAllByInstructorAsync(Guid id);
        Task<IReadOnlyCollection<Class>> GetAllByStudentAsync(Guid id);
        Task<Class> GetAsync(Guid id);
        Task CreateAsync(Class clss);
        Task UpdateAsync(Class clss);
        Task RemoveAsync(Guid id);
    }
}
