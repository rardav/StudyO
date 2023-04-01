using Classes.Domain.Entities;
using Classes.Infrastructure.Repositories.Contracts;
using MongoDB.Driver;

namespace Classes.Infrastructure.Repositories
{
    public class ClassesRepository : IClassesRepository
    {
        private const string COLLECTION_NAME = "classes";

        private readonly IMongoCollection<Class> _dbCollection;
        private readonly FilterDefinitionBuilder<Class> _filterBuilder = Builders<Class>.Filter;

        public ClassesRepository(IMongoDatabase db)
        {
            _dbCollection = db.GetCollection<Class>(COLLECTION_NAME);
        }

        public async Task CreateAsync(Class clss)
        {
            if (clss == null)
            {
                throw new ArgumentNullException(nameof(clss));
            }

            await _dbCollection.InsertOneAsync(clss);
        }

        public async Task<IReadOnlyCollection<Class>> GetAllByInstructorAsync(Guid id)
        {
            var filter = _filterBuilder.Eq(clss => clss.InstructorId, id);

            return await _dbCollection.Find(filter).ToListAsync();
        }

        public async Task<IReadOnlyCollection<Class>> GetAllByStudentAsync(Guid id)
        {
            var filter = _filterBuilder.ElemMatch(clss => clss.StudentsIds, studentId => studentId == id);

            return await _dbCollection.Find(filter).ToListAsync();
        }

        public async Task<Class> GetAsync(Guid id)
        {
            var filter = _filterBuilder.Eq(clss => clss.Id, id);

            return await _dbCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            var filter = _filterBuilder.Eq(clss => clss.Id, id);

            await _dbCollection.DeleteOneAsync(filter);
        }

        public async Task UpdateAsync(Class clss)
        {
            var filter = _filterBuilder.Eq(existingClass => existingClass.Id, clss.Id);

            await _dbCollection.ReplaceOneAsync(filter, clss);
        }

        public async Task CreateAssignmentAsync(Assignment assignment, Guid classId)
        {
            var filter = _filterBuilder.Eq(clss => clss.Id, classId);

            var update = Builders<Class>.Update.AddToSet(clss => clss.Assignments, assignment);

            await _dbCollection.UpdateOneAsync(filter, update);
        }
    }
}
