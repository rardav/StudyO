using MongoDB.Driver;
using StudyO.Courses.Domain.Entities;
using StudyO.Courses.Infrastructure.Repositories.Contracts;

namespace StudyO.Courses.Infrastructure.Repositories
{
    public class CoursesRepository : ICoursesRepository
    {
        private const string collectionName = "courses";
        private readonly IMongoCollection<Course> dbCollection;
        private readonly FilterDefinitionBuilder<Course> filterBuilder = Builders<Course>.Filter;

        public CoursesRepository(IMongoDatabase db)
        {
            dbCollection = db.GetCollection<Course>(collectionName);
        }

        public async Task<IReadOnlyCollection<Course>> GetAllAsync()
        {
            return await dbCollection.Find(filterBuilder.Empty).ToListAsync();
        }

        public async Task<Course> GetAsync(Guid id)
        {
            var filter = filterBuilder.Eq(course => course.Id, id);

            return await dbCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }

            await dbCollection.InsertOneAsync(course);
        }
    }
}
