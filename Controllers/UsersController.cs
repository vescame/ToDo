using System;
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
        [HttpPost("login")]
        public async Task<ActionResult<User>> LoginUser(User user, [FromServices] IUserService userService)
        {
            var canLogin = await userService.Login(user);

            if (canLogin) 
                return Ok("Login allowed!");
            
            return NotFound("Invalid credentials");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers([FromServices] IUserService userService)
        {
            return Ok(await userService.GetAllUsers());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<User>> GetUserById(int id, [FromServices] IUserService userService)
        {
            try
            {
                var user = await userService.GetUserById(id);
                return user;
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] User user, [FromServices] IUserService userService)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return await userService.CreateUser(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<User>> UpdateUser(int id,
            [FromBody] User user, [FromServices] IUserService userService)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (user.Id != id)
                return BadRequest("ID's doesn't match");
            
            try
            {
                return await userService.UpdateUser(user);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<User>> DeleteUser(int id, [FromServices] IUserService userService)
        {
            try
            {
                return await userService.DeleteUser(id);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
