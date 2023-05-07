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

        public async Task AddLessonAsync(Course course, Guid chapterId, Lesson lesson)
        {
            lesson.Id = Guid.NewGuid();

            course.Chapters.FirstOrDefault(chapter => chapter.Id.Equals(chapterId))!.Lessons.Add(lesson);

            var filter = _filterBuilder.Eq(existingCourse => existingCourse.Id, course.Id);

            await _dbCollection.ReplaceOneAsync(filter, course);
        }

        public async Task AddSectionAsync(Course course, Guid chapterId, Guid lessonId, Section section)
        {
            section.Id = Guid.NewGuid();

            course.Chapters.FirstOrDefault(chapter => chapter.Id.Equals(chapterId))!.Lessons.FirstOrDefault(lesson => lesson.Id.Equals(lessonId))!.Sections.Add(section);

            var filter = _filterBuilder.Eq(existingCourse => existingCourse.Id, course.Id);

            await _dbCollection.ReplaceOneAsync(filter, course);
        }
    }
}
