using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Bruna.Danilo.Testers.Api.Models;
using Bruna.Danilo.Testers.Database;
using Bruna.Danilo.Testers.Database.Entities;
using Bruna.Danilo.Testers.Logs;
using Bruna.Danilo.Testers.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Bruna.Danilo.Testers.Api.Controllers
{
	
	[Route("api/[controller]")]
	public class CidadeEstadoController: Controller
    {
		private readonly Logger _logger;
		private readonly CidadeDao _cidadeDao;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly EstadoDao _estadoDao;
		private readonly HistoricoCidadesEstadosDao _historicoCidadesEstadosDao;
		public CidadeEstadoController(Logger logger,
                                      CidadeDao cidadeDao,
		                              EstadoDao estadoDao,
		                             HistoricoCidadesEstadosDao historicoCidadesEstadosDao,
		                              UserManager<IdentityUser> userManager)
        {
			this._logger = logger;
			this._cidadeDao = cidadeDao;
			this._estadoDao = estadoDao;
			this._userManager = userManager;
			this._historicoCidadesEstadosDao = historicoCidadesEstadosDao;
        }

		[HttpGet("cidades")]
		public IActionResult GetCidades(string estado){
			try
			{
				int iEstado = 0;
				if (Int32.TryParse(estado, out iEstado))
				{
					return Ok(_cidadeDao.GetByEstado(iEstado));
				}
				else
				{
					return NotFound(estado);
				}
			}
			catch (Exception ex)
			{
				_logger.ErrorAsync(ex, null);
                throw ex;
			}
		}

		[HttpGet("estados")]
        public  IActionResult GetEstados()
        {
            try
            {
                return Ok(_estadoDao.GetAll());
            }
            catch (Exception ex)
            {
                _logger.ErrorAsync(ex, null);
                throw ex;
            }
        }
        
        [Authorize]
		[HttpGet("atualizaCidadesEstados")]
		public async Task<IActionResult> AtualizaCidadesEstados()
        {
            try
            {
				var appUser = await _userManager.GetUserAsync(this.User);
				if (appUser == null)
					throw new Exception("Não autorizado");

				await this.AtualizaEstadosAsync();
				await this.AtualizaCidadesAsync();
				await this._historicoCidadesEstadosDao.SaveAsync(new HistoricoCidadesEstados(){
					UserId = appUser.Id,
					TimeStamp = DateTime.Now
				});
				return Ok();
            }
            catch (Exception ex)
            {
                _logger.ErrorAsync(ex, null);
                throw ex;
            }
        }

		private async Task<int> AtualizaCidadesAsync()
		{
			int result = 0;
			foreach(var currentEstado in this._estadoDao.GetAll())
			{
				using (var httpClient = new HttpClient())
                {
					IList<Cidade> cidades = JsonConvert.DeserializeObject<IList<Cidade>>
					                                   (httpClient.GetStringAsync(new Uri(AppSettings.IBGECidadesUrl.Replace("{UF}", currentEstado.Id.ToString()))).Result);
					result += await _cidadeDao.AtualizaCidadesAsync(cidades, currentEstado.Id);
                }
				
			}
			return result;
		}

		private async Task<int> AtualizaEstadosAsync()
		{
            using (var httpClient = new HttpClient())
            {
				IList<Estado> estados = JsonConvert.DeserializeObject<IList<Estado>>(httpClient.GetStringAsync(new Uri(AppSettings.IBGEEstadosUrl)).Result);
				return await _estadoDao.AtualizaEstadosAsync(estados);
            }

		}
	}
}
