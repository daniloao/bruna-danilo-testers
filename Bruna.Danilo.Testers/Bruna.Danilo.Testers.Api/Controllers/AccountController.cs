using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Bruna.Danilo.Testers.Api.Infraestructure;
using Bruna.Danilo.Testers.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bruna.Danilo.Testers.Api.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
		private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

		public AccountController(
        UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] UserModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.UserPassword, false, false);

            if (result.Succeeded)
            {
                var appUser = _userManager.Users.SingleOrDefault(r => r.Email == model.Email);
				model.Token = await GenerateJwtToken(model.Email, appUser);
				return Ok(model.ClearPassword());
            }

			model.AddModelError("UserPassword","Login e/ou senha invalidos!");
			return BadRequest(model.ClearPassword());
        }

		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] UserModel model)
        {
            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.UserPassword);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
				model.Token = await GenerateJwtToken(model.Email, appUser);
                return Ok(model.ClearPassword());
            }

			foreach(var currentError in result.Errors){
				model.AddModelError("UserPassword", $"{currentError.Code} - {currentError.Description}");
			}

			return BadRequest(model.ClearPassword());
        }

        private async Task<string> GenerateJwtToken(string email, IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSettings.JwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(AppSettings.JwtExpireDays));

            var token = new JwtSecurityToken(
                AppSettings.JwtIssuer,
				AppSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
