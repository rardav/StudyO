using ProgressTracking.Domain.Entities;

namespace ProgressTracking.Infrastructure.Repositories.Contracts
{
    public interface IProgressRepository
    {
        Task<Progress> GetProgressByCourseAndStudentAsync(Guid courseId, string studentEmail);
        Task<IEnumerable<Progress>> GetLatestProgressByStudentAsync(string studentEmail);
        Task AddProgressAsync(Progress progress);
        Task UpdateProgressAsync(Progress progress);
    }
}
