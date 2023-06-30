using MongoDB.Driver;
using Reviews.Domain.Entities;
using Reviews.Infrastructure.Repositories.Contracts;

namespace Reviews.Infrastructure.Repositories
{
    public class ReviewsRepository : IReviewsRepository
    {
        private const string COLLECTION_NAME = "reviews";

        private readonly IMongoCollection<Review> _dbCollection;
        private readonly FilterDefinitionBuilder<Review> _filterBuilder = Builders<Review>.Filter;

        public ReviewsRepository(IMongoDatabase db)
        {
            _dbCollection = db.GetCollection<Review>(COLLECTION_NAME);
        }

        public async Task CreateAsync(Review review)
        {
            if (review == null)
            {
                throw new ArgumentNullException(nameof(review));
            }

            await _dbCollection.InsertOneAsync(review);
        }

        public async Task<IReadOnlyCollection<Review>> GetAllByCourseAsync(Guid id)
        {
            var filter = _filterBuilder.Eq(rev => rev.CourseId, id);

            return await _dbCollection.Find(filter).ToListAsync();
        }
    }
}
