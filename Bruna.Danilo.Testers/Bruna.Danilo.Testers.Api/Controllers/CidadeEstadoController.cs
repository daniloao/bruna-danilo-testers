using System;
using System.Threading.Tasks;
using Bruna.Danilo.Testers.Database;
using Bruna.Danilo.Testers.Logs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bruna.Danilo.Testers.Api.Controllers
{
	
	[Route("api/[controller]")]
	public class CidadeEstadoController: Controller
    {
		private readonly Logger _logger;
		private readonly CidadeDao _cidadeDao;
		private readonly EstadoDao _estadoDao;
		private readonly HistoricoCidadesEstadosDao _historicoCidadesEstadosDao;
		public CidadeEstadoController(Logger logger,
                                      CidadeDao cidadeDao,
		                              EstadoDao estadoDao,
		                             HistoricoCidadesEstadosDao historicoCidadesEstadosDao)
        {
			this._logger = logger;
			this._cidadeDao = cidadeDao;
			this._estadoDao = estadoDao;
			this._historicoCidadesEstadosDao = historicoCidadesEstadosDao;
        }
        
        [Authorize]
		[HttpGet("atualizaCidadesEstados")]
		public async Task<IActionResult> AtualizaCidadesEstados()
        {
            try
            {
				await this.AtualizaEstadosAsync();
				return Ok();
            }
            catch (Exception ex)
            {
                _logger.ErrorAsync(ex, null);
                throw ex;
            }
        }

		private async Task<int> AtualizaEstadosAsync()
		{
			return 0;
		}
	}
}
