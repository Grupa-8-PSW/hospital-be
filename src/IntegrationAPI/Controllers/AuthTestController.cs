using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthTestController : ControllerBase
    {

        [HttpGet]
        [Authorize(Roles = "Manager")]
        public IActionResult Test()
        {
            return Ok();
        }
    }
}
