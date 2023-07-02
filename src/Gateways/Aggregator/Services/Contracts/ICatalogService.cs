using Aggregator.Models;

namespace Aggregator.Services.Contracts
{
    public interface IProgressService
    {
        Task<IEnumerable<ProgressModel>> GetLatestProgressByEmail(string email);
    }
}
