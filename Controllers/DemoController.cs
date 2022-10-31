using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityAndJwt.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[Controller]/[action]")]
    public class DemoController : ControllerBase
    {
        public DemoController()
        {
        }

        [HttpGet]
        public async Task<string>Index()
        {
            var name = this.User.FindFirst(ClaimTypes.Name)?.Value;
            return "6666"+ name;
        }
    }
}
