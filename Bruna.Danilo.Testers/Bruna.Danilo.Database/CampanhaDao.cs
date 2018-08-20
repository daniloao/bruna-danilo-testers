using System;
using System.Collections.Generic;
using System.Linq;
using Bruna.Danilo.Testers.Database.Entities;

namespace Bruna.Danilo.Testers.Database
{
    public class CampanhaDao
    {
		private TestersContext _testersContext;

		public CampanhaDao(TestersContext testersContext)
        {
            this._testersContext = testersContext;
        }

		public IList<Campanha> GetAll()
        {
			return this._testersContext.Campanhas.ToList();
        }

		public Campanha GetById(int id)
        {
			return this._testersContext.Campanhas.Find(id);
        }

		public int Add(Campanha campanha)
        {
			campanha.CreatedDate = DateTime.Now;
			this._testersContext.Campanhas.Add(campanha);
            return this._testersContext.SaveChanges();
        }

		public int Update(Campanha campanha)
        {
			var cm = this.GetById(campanha.Id);
            
            if (cm == null)
				throw new Exception($"Campanha não encontrado: {campanha.Id}");

			this.Map(campanha, ref cm);
			cm.UpdateDate = DateTime.Now;
            return this._testersContext.SaveChanges();
        }

		private void Map(Campanha campanha, ref Campanha cm)
        {
			cm.Chave = campanha.Chave;
			cm.Titulo = campanha.Titulo;
			cm.Texto = campanha.Texto;
			cm.TipoCampanhaId = campanha.TipoCampanhaId;
			cm.CidadeId = campanha.CidadeId;
			cm.Logo = campanha.Logo;
			cm.LogoUrl = campanha.LogoUrl;
			cm.CidadeId = campanha.CidadeId;
			cm.EstadoId = campanha.EstadoId;
			cm.DataInicio = campanha.DataInicio;
			cm.DataFim = campanha.DataFim;
			cm.IsActive = campanha.IsActive;
			cm.LinkTrackeado = campanha.LinkTrackeado;
			cm.Cupom = campanha.Cupom;
			cm.ClienteId = campanha.ClienteId;
			cm.AnuncianteId = campanha.AnuncianteId;
			cm.CreatedById = campanha.CreatedById;
			cm.CreatedDate = campanha.CreatedDate;
			cm.UpdatedById = campanha.UpdatedById;
			cm.UpdateDate = campanha.UpdateDate;
        }
    }
}
