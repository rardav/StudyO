using Catalog.Domain.Entities;
using Catalog.Infrastructure.Repositories.Contracts;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories
{
    public class CoursesRepository : ICoursesRepository
    {
        private const string COLLECTION_NAME = "courses";

        private readonly IMongoCollection<Course> _dbCollection;
        private readonly FilterDefinitionBuilder<Course> _filterBuilder = Builders<Course>.Filter;

        public CoursesRepository(IMongoDatabase db)
        {
            _dbCollection = db.GetCollection<Course>(COLLECTION_NAME);
        }

        public async Task<IReadOnlyCollection<Course>> GetAllAsync()
        {
            return await _dbCollection.Find(_filterBuilder.Empty).ToListAsync();
        }

        public async Task<Course> GetAsync(Guid id)
        {
            var filter = _filterBuilder.Eq(course => course.Id, id);

            return await _dbCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }

            await _dbCollection.InsertOneAsync(course);
        }

        public async Task UpdateAsync(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }

            var filter = _filterBuilder.Eq(existingCourse => existingCourse.Id, course.Id);

            await _dbCollection.ReplaceOneAsync(filter, course);
        }

        public async Task RemoveAsync(Guid id)
        {
            var filter = _filterBuilder.Eq(course => course.Id, id);

            await _dbCollection.DeleteOneAsync(filter);
        }

        public async Task AddChapterAsync(Guid courseId, Chapter chapter)
        {
            chapter.Id = Guid.NewGuid();

            var filter = _filterBuilder.Eq(course => course.Id, courseId);
            var update = Builders<Course>.Update.Push(course => course.Chapters, chapter);

            await _dbCollection.UpdateOneAsync(filter, update);
        }

        public async Task AddLessonAsync(Guid courseId, Guid chapterId, Lesson lesson)
        {
            lesson.Id = Guid.NewGuid();

            var filter = _filterBuilder.And(
                _filterBuilder.Eq(course => course.Id, courseId),
                _filterBuilder.ElemMatch(course => course.Chapters, chapter => chapter.Id == chapterId));

            var update = Builders<Course>.Update.Push(course => course.Chapters[-1].Lessons, lesson);

            await _dbCollection.UpdateOneAsync(filter, update);
        }

        public async Task AddSectionAsync(Guid courseId, Guid chapterId, Guid lessonId, Section section)
        {
            section.Id = Guid.NewGuid();

            var filter = Builders<Course>.Filter.And(
                _filterBuilder.Eq(course => course.Id, courseId),
                _filterBuilder.ElemMatch(course => course.Chapters, chapter => chapter.Id.Equals(chapterId) && chapter.Lessons.Any(lesson => lesson.Id.Equals(lessonId)))
            );

            var update = Builders<Course>.Update.Push(c => c.Chapters[-1].Lessons[-1].Sections, section);

            await _dbCollection.UpdateOneAsync(filter, update);
        }
    }
}
