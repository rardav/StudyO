using Aggregator.Extensions;
using Aggregator.Models;
using Aggregator.Services.Contracts;

namespace Aggregator.Services
{
    public class ReviewsService : IReviewsService
    {
        private readonly HttpClient _httpClient;

        public ReviewsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ReviewModel>> GetReviewsAsync(Guid id)
        {
            var response = _httpClient.GetAsync($"/api/Reviews/courses/{id}");

            return await response.ReadContentAs<List<ReviewModel>>();
        }
    }
}
