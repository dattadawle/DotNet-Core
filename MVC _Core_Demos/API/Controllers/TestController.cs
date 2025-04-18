using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {


        [HttpGet]
        [Authorize (Roles ="admin")]
        [Route("admindata")]
        public async Task<ActionResult> GetAdminData()
        {

            return Ok("you are admin role user");
        }

        [HttpGet]
        [Authorize (Roles ="user")]
        [Route("userdata")]
        public async Task< ActionResult > GetUserRoleData()
        {
            return Ok("you are normal user role user");
        }

        [HttpGet]
        [Route("publicdata")]
        public async Task<IActionResult> GetPublicData()
        {
            return Ok("you are normal user role user");
        }
    }
}
