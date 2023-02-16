using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TempApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TempController : ControllerBase
    {
        [HttpGet]
        public int Get()
        {
            return new Random().Next(40);
        }
    }
}
