using Microsoft.AspNetCore.Mvc;

namespace Week2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Index action");
        }
    }
}