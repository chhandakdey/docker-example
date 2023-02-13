using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AggregatorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HttpAggregatorController : ControllerBase
    {
        [HttpGet(Name = "GetWeather")]
        public int Get()
        {
            return new Random().Next(100);
        }
    }
}
