using Reviews.Domain.Entities;

namespace Reviews.Infrastructure.Repositories.Contracts
{
    public interface IReviewsRepository
    {
        Task<IReadOnlyCollection<Review>> GetAllByCourseAsync(Guid id);
        Task CreateAsync(Review review);

    }
}
