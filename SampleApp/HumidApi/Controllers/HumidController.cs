using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HumidApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumidController : ControllerBase
    {
        [HttpGet(Name = "GetHumid")]
        public int Get()
        {
            return new Random().Next(100);
        }
    }
}
