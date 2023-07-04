using MongoDB.Driver;
using ProgressTracking.Domain.Entities;
using ProgressTracking.Infrastructure.Repositories.Contracts;
using System;

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

        public async Task<IEnumerable<Progress>> GetLatestProgressByStudentAsync(string studentEmail)
        {
            var filter = _filterBuilder.Where(prog => prog.CourseFinished == false && prog.StudentEmail == studentEmail);

            return await _dbCollection.Find(filter).Limit(3).ToListAsync();
        }

        public async Task<Progress> GetProgressByCourseAndStudentAsync(Guid courseId, string studentEmail)
        {
            var filter = _filterBuilder.Where(prog => prog.CourseId == courseId && prog.StudentEmail == studentEmail);

            return await _dbCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task UpdateProgressAsync(Progress progress)
        {
            var filter = _filterBuilder.Where(prog => prog.CourseId == progress.CourseId && prog.StudentEmail == progress.StudentEmail);
            var update = Builders<Progress>.Update
                .Set(prog => prog.CourseFinished, progress.CourseFinished)
                .Set(prog => prog.LessonId, progress.LessonId);


            await _dbCollection.UpdateOneAsync(filter, update);
        }
    }
}
