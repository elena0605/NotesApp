using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notes.CustomExceptions;
using Notes.DTOs;
using Notes.Services.Abstraction;

namespace Notes.Api.Controllers
{
    [Authorize]
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterUserDto registerUserDto)
        {
            try
            {           
                _userService.RegisterUser(registerUserDto);

                return StatusCode(201, "User created!");
                
            }
            catch (UserDataException ex)
            {
                //Log.Error(ex.Message);
              
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, "An error occurred!");
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginUserDto loginUserDto)
        {
            try
            {
               
                var token = _userService.LoginUser(loginUserDto);
                return Ok(new {token});
            }
            catch (UserDataException ex)
            {
               
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, "An error occurred!");
            }
        }
    }
}
