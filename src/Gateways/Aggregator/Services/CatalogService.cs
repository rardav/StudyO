using Aggregator.Extensions;
using Aggregator.Models;
using Aggregator.Services.Contracts;

namespace Aggregator.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _httpClient;

        public CatalogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CourseModel> GetCourse(Guid id)
        {
            var response = _httpClient.GetAsync($"/api/Courses/{id}");

            return await response.ReadContentAs<CourseModel>();
        }

        public Task<IEnumerable<CourseModel>> GetCourses()
        {
            throw new NotImplementedException();
        }
    }
}
