using MongoDB.Driver;
using StudyO.Courses.Domain.Entities;

namespace StudyO.Courses.Infrastructure.Repositories
{
    public class CoursesRepository
    {
        private const string collectionName = "courses";

        private readonly IMongoCollection<Course> dbCollection;
        private readonly FilterDefinitionBuilder<Course> filterBuilder = Builders<Course>.Filter;

        public CoursesRepository()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var db = mongoClient.GetDatabase("Catalog");
            dbCollection = db.GetCollection<Course>(collectionName);
        }

        public async Task<IReadOnlyCollection<Course>> GetAllAsync()
        {
            return await dbCollection.Find(filterBuilder.Empty).ToListAsync();
        }
    }
}
