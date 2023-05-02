using System.Text.Json;

namespace Aggregator.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<T> ReadContentAs<T>(this Task<HttpResponseMessage> response)
        {
            if (!response.Result.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Something went wrong calling the API: {response.Result.ReasonPhrase}");
            }

            var dataAsString = await response.Result.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonSerializer.Deserialize<T>(dataAsString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? default!;
        }
    }
}
