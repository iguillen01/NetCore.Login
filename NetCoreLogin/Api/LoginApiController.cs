using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using NetCoreLogin.Logic;
using NetCoreLogin.Model;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace NetCoreLogin.Api
{
    [ApiController]
    [Route("api")]
    public class LoginApiController : ControllerBase
    {
        readonly IUserService _userService;

        public LoginApiController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (!IsValidEmail(request.Email))
            {
                return Ok("invalid email");
            }

            bool isValid = _userService.ValidateLogin(request.Email, request.Password);

            if (isValid)
            {
                var claims = new[] { new Claim(ClaimTypes.Name, request.Email.ToLower()) };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return Ok("ok");
            }
            else
            {
                return Ok("invalid login");
            }
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok("ok");
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            string emailPattern = @"^[^\s@]+@[^\s@]+\.[^\s@]+$";
            return Regex.IsMatch(email, emailPattern);
        }
    }
}
