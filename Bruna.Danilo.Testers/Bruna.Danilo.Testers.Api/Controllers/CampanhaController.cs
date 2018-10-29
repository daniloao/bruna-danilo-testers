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

namespace Bruna.Danilo.Testers.Api.Controllers
{
	[Route("api/[controller]")]
    [ValidateModel]
	public class CampanhaController: BaseController
    {
		private readonly Logger _logger;
		private readonly TipoCampanhaDao _tipoCampanhaDao;
		private readonly AnuncianteDao _anuncianteDao;
		private readonly TipoImagemDao _tipoImagemDao;
		private readonly CampanhaDao _campanhaDao;
		public CampanhaController(Logger logger,
		                          UserManager<IdentityUser> userManager,
		                          TipoCampanhaDao tipoCampanhaDao,
		                          AnuncianteDao anuncianteDao,
		                          TipoImagemDao tipoImagemDao,
		                          CampanhaDao campanhaDao)
			: base(userManager)
        {
			this._logger = logger;
			this._tipoCampanhaDao = tipoCampanhaDao;
			this._anuncianteDao = anuncianteDao;
			this._tipoImagemDao = tipoImagemDao;
			this._campanhaDao = campanhaDao;
        }

		[HttpGet("anunciantes")]
		[Authorize(Roles = "ADMIN")]
		public IActionResult GetAnunciantes()
        {
            try
            {
				return Ok(_anuncianteDao.GetAll());
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
		public IActionResult SaveCampanha([FromBody] CampanhaModel model)
        {
            try
            {
                model.UpdatedById = this.GetLoggedInUserId();
                _campanhaDao.SaveCliente(model);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.ErrorAsync(ex, this.GetLoggedInUserId());
                throw ex;
            }
        }

		[HttpGet("tiposCampanha")]
        [Authorize(Roles = "ADMIN")]
		public IActionResult GetTiposCampanha()
        {
            try
            {
				return Ok(_tipoCampanhaDao.GetAll());
            }
            catch (Exception ex)
            {
                _logger.ErrorAsync(ex, this.GetLoggedInUserId());
                throw ex;
            }
        }

		[HttpGet("tiposImagem")]
        [Authorize(Roles = "ADMIN")]
		public IActionResult GetTiposImagem()
        {
            try
            {
                return Ok(_tipoImagemDao.GetAll());
            }
            catch (Exception ex)
            {
                _logger.ErrorAsync(ex, this.GetLoggedInUserId());
                throw ex;
            }
        }
    }
}
