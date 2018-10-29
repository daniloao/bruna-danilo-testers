using System;
using System.Collections.Generic;
using System.Linq;
using Bruna.Danilo.Testers.Database.Entities;

namespace Bruna.Danilo.Testers.Database
{
    public class TipoImagemDao
    {
		private TestersContext _testersContext;

		public TipoImagemDao(TestersContext testersContext)
        {
            this._testersContext = testersContext;
        }

		public IList<TipoImagem> GetAll(bool bringInactive = false)
        {
            var query = this._testersContext.TiposImagem
                .AsQueryable();

            if (bringInactive)
            {
                query = query.Where(current => current.IsActive == true);
            }
            return query.ToList();
        }

    }
}
