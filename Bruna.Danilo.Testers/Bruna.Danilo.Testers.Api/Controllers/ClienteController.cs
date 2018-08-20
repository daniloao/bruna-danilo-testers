using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
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
	
	[Route("api/[controller]")]
	public class ClienteController: Controller
    {
		private readonly Logger _logger;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly ClienteDao _clienteDao;
		public ClienteController(Logger logger,
		                         UserManager<IdentityUser> userManager,
		                         ClienteDao clienteDao)
        {
			this._logger = logger;
			this._userManager = userManager;
			this._clienteDao = clienteDao;
        }

		[HttpPost("clientes")]
		[Authorize]
		public IActionResult GetClientes([FromBody] PagedRequestModel<Cliente> model)
        {
            try
            {
				return Ok(_clienteDao.PagedFielter(model));
            }
            catch (Exception ex)
            {
                _logger.ErrorAsync(ex, null);
                throw ex;
            }
        }

		[HttpPost("save")]
        [Authorize]
        public IActionResult SaveCliente([FromBody] Cliente model)
        {
            try
            {
				_clienteDao.SaveCliente(model);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.ErrorAsync(ex, null);
                throw ex;
            }
        }

		[HttpGet("cliente")]
        [Authorize]
        public IActionResult GetCliente( int id)
        {
            try
            {
				var cliente = _clienteDao.GetById(id);
				return Ok(cliente);
            }
            catch (Exception ex)
            {
                _logger.ErrorAsync(ex, null);
                throw ex;
            }
        }
	}
}
