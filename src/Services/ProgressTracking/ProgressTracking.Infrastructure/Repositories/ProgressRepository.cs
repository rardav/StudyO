using MongoDB.Driver;
using ProgressTracking.Domain.Entities;
using ProgressTracking.Infrastructure.Repositories.Contracts;

namespace ProgressTracking.Infrastructure.Repositories
{
    public class ProgressRepository : IProgressRepository
    {
        private const string COLLECTION_NAME = "progressTracking";

        private readonly IMongoCollection<Progress> _dbCollection;
        private readonly FilterDefinitionBuilder<Progress> _filterBuilder = Builders<Progress>.Filter;

        public ProgressRepository(IMongoDatabase db)
        {
            _dbCollection = db.GetCollection<Progress>(COLLECTION_NAME);
        }

        public async Task AddProgressAsync(Progress progress)
        {
            if (progress == null)
            {
                throw new ArgumentNullException(nameof(progress));
            }

            await _dbCollection.InsertOneAsync(progress);
        }

        public async Task<Progress> GetProgressByCourseAndStudentAsync(Guid courseId, string studentEmail)
        {
            var filter = _filterBuilder.Eq(prog => prog.CourseId, courseId) & _filterBuilder.Eq(prog => prog.StudentEmail, studentEmail);

            return await _dbCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task UpdateProgressAsync(Progress progress)
        {
            var filter = _filterBuilder.Eq(prog => prog.CourseId, progress.CourseId) & _filterBuilder.Eq(prog => prog.StudentEmail, progress.CourseId);

            await _dbCollection.ReplaceOneAsync(filter, progress);
        }
    }
}
