using System;
using System.Collections.Generic;
using System.Linq;
using Bruna.Danilo.Testers.Database.Entities;

namespace Bruna.Danilo.Testers.Database
{
    public class TipoCampanhaDao
    {
		private TestersContext _testersContext;

		public TipoCampanhaDao(TestersContext testersContext)
        {
            this._testersContext = testersContext;
        }

		public IList<TipoCampanha> GetAll(bool bringInactive = false)
        {
			var query = this._testersContext.TiposCampanha
                .AsQueryable();

            if (bringInactive)
            {
                query = query.Where(current => current.IsActive == true);
            }
            return query.ToList();
        }

		public TipoCampanha GetById(int id)
        {
			return this._testersContext.TiposCampanha.Find(id);
        }

		public int Add(TipoCampanha tipoCampanha)
        {
			tipoCampanha.CreatedDate = DateTime.Now;
			 this._testersContext.TiposCampanha.Add(tipoCampanha);
			return this._testersContext.SaveChanges();
        }

		public int Update(TipoCampanha tipoCampanha)
        {
			var tpCamp = this.GetById(tipoCampanha.Id);

			if (tpCamp == null)
				throw new Exception($"Tipo de campanha não encontrado: {tipoCampanha.Id}");

			this.Map(tipoCampanha, ref tpCamp);
			tpCamp.UpdateDate = DateTime.Now;
            return this._testersContext.SaveChanges();
        }

		private void Map(TipoCampanha tipoCampanha, ref TipoCampanha tpCamp)
		{
			tpCamp.Descricao = tipoCampanha.Descricao;
			tpCamp.CreatedById = tipoCampanha.CreatedById;
			tpCamp.CreatedDate = tipoCampanha.CreatedDate;
			tpCamp.UpdatedById = tipoCampanha.UpdatedById;
			tpCamp.UpdateDate = tipoCampanha.UpdateDate;
		}
	}
}
