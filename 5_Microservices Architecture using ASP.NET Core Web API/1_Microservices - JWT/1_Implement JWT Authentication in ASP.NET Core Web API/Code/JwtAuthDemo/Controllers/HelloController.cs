using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloController : ControllerBase
    {
        [HttpGet("public")]
        public IActionResult Public() => Ok("✅ Public endpoint accessed");

        [HttpGet("private")]
        [Authorize]
        public IActionResult Private() => Ok($"🔐 Protected endpoint accessed by {User.Identity.Name}");
    }
}
