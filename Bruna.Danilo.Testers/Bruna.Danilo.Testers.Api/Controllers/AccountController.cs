using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Bruna.Danilo.Testers.Settings;
using Bruna.Danilo.Testers.Api.Validate;
using Bruna.Danilo.Testers.Logs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Bruna.Danilo.Testers.Database;
using Bruna.Danilo.Testers.Api.Mappers;
using Bruna.Danilo.Testers.Database.Entities;
using Microsoft.AspNetCore.Authorization;
using Bruna.Danilo.Testers.Models;
using DotNetOpenAuth.OAuth2;

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
		private readonly UserRoleDao _userRoleDao;

        public AccountController(UserManager<IdentityUser> userManager,
                                SignInManager<IdentityUser> signInManager,
                                Logger logger,
                                UserDao userDao,
                                UserRoleDao userRoleDao)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _userDao = userDao;
			_userRoleDao = userRoleDao;
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
					model.UserRoles = _userRoleDao.GetByUser(appUser.Id).ToModels();
					model.Token = await GenerateJwtToken(model.Email, appUser, model.UserRoles  );
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



		[Authorize]
        [HttpPost("isAuthenticated")]
        public  IActionResult IsAuthenticated(){
			// Funcion is authorize, so if gets to here is authenticated
            return Ok(true);
        }
        
		[Authorize]
        [HttpPost("logOut")]
        public IActionResult LogOut()
        {
            _signInManager.SignOutAsync();
            return Ok();
        }

		[Authorize]
		[HttpGet("refreshToken")]
		public async Task<IActionResult> RefreshToken()
        {
            try
            {
				var appUser = await _userManager.GetUserAsync(this.User);

				var roles = _userRoleDao.GetByUser(appUser.Id).ToModels();
				return Ok(new UserModel()
				{
					Token = await GenerateJwtToken(appUser.Email, appUser, roles),
                    UserRoles = roles,
                    Email = appUser.Email,
                    Name = appUser.UserName
				});
                   
            }
            catch (Exception ex)
            {
                _logger.ErrorAsync(ex, null);
                throw ex;
            }
        }
        
		[Authorize]
        [HttpPost("hasRole")]
        public async Task<IActionResult> HasRole(string role)
        {
			try
            { 
                var appUser = await _userManager.GetUserAsync(this.User);
                if (appUser == null)
                    throw new Exception("Não autorizado");
                
                var rl = _userRoleDao.GetById(appUser.Id, role);
                
                return Ok(rl != null);
			}
            catch (Exception ex)
            {
                _logger.ErrorAsync(ex, null);
                throw ex;
            }

        }
        
		[Authorize]
        [HttpPost("getRoles")]
        public async Task<IActionResult> GetRoles()
        {
			try
			{            
    			var appUser =  _userManager.GetUserId(this.User);
				if (String.IsNullOrEmpty(appUser))
                    throw new Exception("Não autorizado");
                
				var rl = _userRoleDao.GetByUser(appUser);

                return Ok(rl);
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
					model.UserRoles = _userRoleDao.GetByUser(user.Id).ToModels();
					model.Token = await GenerateJwtToken(model.Email, user, model.UserRoles);
					this.SendWellcomeEmail();
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

		private void SendWellcomeEmail()
		{
			// TODO: Wellcome email
		}

		private async Task<string> GenerateJwtToken(string email, IdentityUser user, IList<UserRoleModel> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.CHash, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
				new Claim(ClaimTypes.NameIdentifier, user.Id),
				new Claim(ClaimTypes.Email, email)
            };

			foreach(var role in roles)
			{
				claims.Add(new Claim("role", role.RoleId));
				claims.Add(new Claim(ClaimTypes.Role, role.RoleId));
			}

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
