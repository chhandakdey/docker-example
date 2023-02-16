using System.Text.Json;

namespace AggregatorApi.Infra
{
    public class TempAdadpter : ITempHttpAdapter
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public TempAdadpter(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient("TempApi");
            _configuration = configuration;
        }

        public async Task<int> GetResult()
        {
            var tempApiURL = _configuration.GetValue<string>("TempApiURL");
            var httpResponseMessage = await _httpClient.GetAsync(tempApiURL);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream =
                    await httpResponseMessage.Content.ReadAsStreamAsync();

                await JsonSerializer.DeserializeAsync
                    <int>(contentStream);
            }

            return -1000;
        }
    }
}
