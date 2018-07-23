using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bruna.Danilo.Testers.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bruna.Danilo.Testers.Api.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
		private UserManager<UserModel> _userManager;

		public AccountController( UserManager<UserModel> userManager){
			_userManager = userManager;

		}

		[HttpPost("login")]
        public string Login([FromBody]string value)
        {
			return $"login ok: {value}";
        }

		[HttpPost("createUser")]
		public async Task<IActionResult> CreateUserAsync([FromBody]UserModel model)
        {
			var result = await _userManager.CreateAsync(model, model.UserPassword);
			return Ok();
        }

    }
}
