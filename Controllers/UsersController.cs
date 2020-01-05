using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDo.Models;
using ToDo.Services.UserServices;

namespace ToDo.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            return Ok(new User[] { new User() });
        }
        [HttpPost]
        public async Task<ActionResult<User>> LoginUser(User user, [FromServices] IUserService userService)
        {
            var canLogin = await userService.Login(user);

            if (canLogin) return Ok("Login allowed!");

            return NotFound("Invalid credentials");
        }
    }
}
