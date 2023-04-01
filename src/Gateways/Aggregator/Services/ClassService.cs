using Aggregator.Models;
using Aggregator.Services.Contracts;
using Aggregator.Extensions;

namespace Aggregator.Services
{
    public class ClassService : IClassService
    {
        private readonly HttpClient _httpClient;

        public ClassService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ClassModel> GetClass(Guid id)
        {
            var response = _httpClient.GetAsync($"/api/Classes/{id}");

            return await response.ReadContentAs<ClassModel>();
        }
    }
}
