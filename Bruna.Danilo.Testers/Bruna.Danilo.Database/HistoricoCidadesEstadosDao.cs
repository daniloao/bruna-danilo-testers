using System;
using System.Threading.Tasks;
using Bruna.Danilo.Testers.Database.Entities;

namespace Bruna.Danilo.Testers.Database
{
    public class HistoricoCidadesEstadosDao
    {
		private TestersContext _testersContext;

		public HistoricoCidadesEstadosDao(TestersContext testersContext)
        {
            this._testersContext = testersContext;
        }

		public async Task<int> SaveAsync(HistoricoCidadesEstados historicoCidadesEstados)
		{
			historicoCidadesEstados.TimeStamp = DateTime.Now;
			_testersContext.HistoricoCidadesEstados.Add(historicoCidadesEstados);
			return await _testersContext.SaveChangesAsync();
		}
    }
}
