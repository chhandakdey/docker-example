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
            var resultData = -1000;
            var tempApiURL = _configuration.GetValue<string>("HumidApiURL");
            var httpResponseMessage = await _httpClient.GetAsync(tempApiURL);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream =
                    await httpResponseMessage.Content.ReadAsStreamAsync();

                resultData = await JsonSerializer.DeserializeAsync
                    <int>(contentStream);
            }

            return resultData;
        }
    }
}
