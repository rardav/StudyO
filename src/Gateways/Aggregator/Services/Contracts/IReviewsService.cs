using Aggregator.Models;

namespace Aggregator.Services.Contracts
{
    public interface IReviewsService
    {
        Task<List<ReviewModel>> GetReviewsAsync(Guid id);
    }
}
