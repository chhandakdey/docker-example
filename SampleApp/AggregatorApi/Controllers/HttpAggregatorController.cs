using AggregatorApi.Infra;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AggregatorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HttpAggregatorController : ControllerBase
    {
        public readonly ITempHttpAdapter _tempHttpAdapter;
        public readonly IHumidHttpAdapter _humidHttpAdapter;

        public HttpAggregatorController(ITempHttpAdapter tempHttpAdapter, IHumidHttpAdapter humidHttpAdapter)
        {
            _tempHttpAdapter = tempHttpAdapter;
            _humidHttpAdapter = humidHttpAdapter;
        }

        [HttpGet(Name = "GetWeather")]
        public string Get()
        {
            var tempTask = _tempHttpAdapter.GetResult();
            var humidTask = _humidHttpAdapter.GetResult();
            Task.WaitAll(tempTask, humidTask);

            var weather = $"Temp: {tempTask.Result}, Humid: {humidTask.Result}";

            return weather;
        }
    }
}
