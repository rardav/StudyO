using Catalog.Domain.Entities;
using Catalog.Infrastructure.Repositories.Contracts;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories
{
    public class ChaptersRepository : IChaptersRepository
    {
        private const string COLLECTION_NAME = "chapters";

        private readonly IMongoCollection<Chapter> _dbCollection;
        private readonly FilterDefinitionBuilder<Chapter> _filterBuilder = Builders<Chapter>.Filter;

        public ChaptersRepository(IMongoDatabase db)
        {
            _dbCollection = db.GetCollection<Chapter>(COLLECTION_NAME);
        }
    }
}
