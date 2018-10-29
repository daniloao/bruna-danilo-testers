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
	
	[Route("api/[controller]")]
	public class ClienteController: BaseController
    {
		private readonly Logger _logger;
		private readonly ClienteDao _clienteDao;
		public ClienteController(Logger logger,
		                         UserManager<IdentityUser> userManager,
		                         ClienteDao clienteDao)
			: base(userManager)
        {
			this._logger = logger;
			this._clienteDao = clienteDao;
        }



		[HttpPost("filteredClientes")]
		[Authorize(Roles = "ADMIN")]
		public IActionResult GetClientes([FromBody] PagedRequestModel<Cliente> model)
		{
            try
			{
				return Ok(_clienteDao.PagedFielter(model));
            }
            catch (Exception ex)
            {
                _logger.ErrorAsync(ex, this.GetLoggedInUserId());
                throw ex;
            }
        }


        [HttpGet("clientes")]
        [Authorize(Roles = "ADMIN")]
        public IActionResult GetAll()
        {
            try
            {
				return Ok(_clienteDao.GetAll());
            }
            catch (Exception ex)
            {
                _logger.ErrorAsync(ex, this.GetLoggedInUserId());
                throw ex;
            }
        }

		[HttpPost("save")]
		[Authorize(Roles = "ADMIN")]
		[ValidateModel]
        public IActionResult SaveCliente([FromBody] Cliente model)
        {
            try
            {
				model.UpdatedById = this.GetLoggedInUserId();
				_clienteDao.SaveCliente(model);
                return Ok();
            }
            catch (Exception ex)
            {
				_logger.ErrorAsync(ex, this.GetLoggedInUserId());
                throw ex;
            }
        }

		[HttpDelete("delete")]
        [Authorize(Roles = "ADMIN")]
        public IActionResult DeleteCliente(int clienteId)
        {
            try
            {
				_clienteDao.DeleteCliente(clienteId);
                return Ok();
            }
            catch (Exception ex)
            {
				_logger.ErrorAsync(ex, this.GetLoggedInUserId());
                throw ex;
            }
        }

		[HttpGet("cliente")]
		[Authorize(Roles = "ADMIN")]
        public IActionResult GetCliente( int id)
        {
            try
            {
				var cliente = _clienteDao.GetById(id);
				return Ok(cliente);
            }
            catch (Exception ex)
            {
				_logger.ErrorAsync(ex, this.GetLoggedInUserId());
                throw ex;
            }
        }
	}
}
