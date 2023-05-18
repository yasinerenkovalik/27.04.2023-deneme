using Bussines.Abstract;
using Entities.DTOS;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.success)
            {
                return BadRequest(userToLogin.message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.message);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.success)
            {
                return BadRequest(userExists.message);
            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.message);
        }
    }
}
