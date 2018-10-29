using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Bruna.Danilo.Testers.Api.Validate;
using Bruna.Danilo.Testers.Database;
using Bruna.Danilo.Testers.Database.Entities;
using Bruna.Danilo.Testers.Logs;
using Bruna.Danilo.Testers.Models;
using Bruna.Danilo.Testers.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Bruna.Danilo.Testers.Api.Controllers
{
	public class BaseController : Controller
    {
		protected readonly UserManager<IdentityUser> _userManager;

		public BaseController(UserManager<IdentityUser> userManager)
		{
			_userManager = userManager;
		}

		protected string GetLoggedInUserId()
        {
            try
            {
                var appUser = _userManager.GetUserAsync(this.User).Result;
                return appUser.Id;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
