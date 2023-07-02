using Aggregator.Extensions;
using Aggregator.Models;
using Aggregator.Services.Contracts;

namespace Aggregator.Services
{
    public class ProgressService : IProgressService
    {
        private readonly HttpClient _httpClient;

        public ProgressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ProgressModel>> GetLatestProgressByEmail(string email)
        {
            var response = _httpClient.GetAsync($"/api/Progress/courses?studentEmail={email}");

            return await response.ReadContentAs<IEnumerable<ProgressModel>>();
        }
    }
}
