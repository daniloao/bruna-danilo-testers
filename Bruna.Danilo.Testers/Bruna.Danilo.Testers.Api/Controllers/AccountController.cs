using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Bruna.Danilo.Testers.Settings;
using Bruna.Danilo.Testers.Api.Models;
using Bruna.Danilo.Testers.Logs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Bruna.Danilo.Testers.Database;
using Bruna.Danilo.Testers.Api.Mappers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bruna.Danilo.Testers.Api.Controllers
{
    [Route("api/[controller]")]
	[ValidateModel]
    public class AccountController : Controller
    {
		private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
		private readonly Logger _logger;
		private readonly UserDao _userDao;

		public AccountController(
        UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager,
		Logger logger,
			UserDao userDao)
        {
            _userManager = userManager;
            _signInManager = signInManager;
			_logger = logger;
			_userDao = userDao;
        }

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] UserModel model)
        {
			try
			{
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

                if (result.Succeeded)
                {
                    var appUser = _userManager.Users.SingleOrDefault(r => r.Email == model.Email);
    				model.Token = await GenerateJwtToken(model.Email, appUser);
    				return Ok(model.ClearPassword());
                }

    			return BadRequest("Login e/ou senha invalidos!");
		    }
            catch (Exception ex)
            {
                _logger.ErrorAsync(ex, null);
                throw ex;
            }
        }

		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegisterModel  model)
        {
			try
			{
				if(!this.ModelState.IsValid)
					return BadRequest(this.ModelState);
				
    			var user = new IdentityUser
                {
                    UserName = model.Name,
                    Email = model.Email
                };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
					this._userDao.Update(model.ToEntity(user));
                    await _signInManager.SignInAsync(user, false);
    				model.Token = await GenerateJwtToken(model.Email, user);
                    return Ok(model.ClearPassword());
                }

    			foreach(var currentError in result.Errors){
                    if(currentError.Code == "DuplicateUserName")
					    this.ModelState.AddModelError("Email", currentError.Description);
					else
						this.ModelState.AddModelError("Password", currentError.Description);
    			}

    			return BadRequest(this.ModelState);
			}
            catch (Exception ex)
            {
				_logger.ErrorAsync(ex, null);
				throw ex;
            }
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
