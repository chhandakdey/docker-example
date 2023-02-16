using System.Text.Json;

namespace AggregatorApi.Infra
{
    public class HumidAdapter : IHumidHttpAdapter
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public HumidAdapter(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient("HumidApi");
            _configuration = configuration;
        }

        public async Task<int> GetResult()
        {
            var tempApiURL = _configuration.GetValue<string>("HumidApiURL");
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
