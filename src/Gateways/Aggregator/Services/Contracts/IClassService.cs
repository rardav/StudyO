using Aggregator.Models;

namespace Aggregator.Services.Contracts
{
    public interface IClassService
    {
        Task<ClassModel> GetClass(Guid id);

    }
}
