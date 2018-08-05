using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bruna.Danilo.Testers.Database.Entities;

namespace Bruna.Danilo.Testers.Database
{
    public class CidadeDao
    {
		private TestersContext _testersContext;

		public CidadeDao(TestersContext testersContext)
        {
            this._testersContext = testersContext;
        }

		public async Task<int> ClearAllAsync(bool saveChanges = true)
        {
            this._testersContext.Cidades.RemoveRange(this._testersContext.Cidades);
            if(saveChanges)
                return await this._testersContext.SaveChangesAsync();

			return 1;
        }

		public async Task<int> SaveAsync(Cidade cidade, bool saveChanges = true)
        {
            this._testersContext.Cidades.Add(cidade);
            if (saveChanges)
                return await this._testersContext.SaveChangesAsync();

            return 1;
        }

		public async Task<int> SaveRangeAsync(IList<Cidade> cidades, bool saveChanges = true)
        {
            foreach (var cidade in cidades)
            {
                await this.SaveAsync(cidade, false);
            }

            if(saveChanges)
                return await this._testersContext.SaveChangesAsync();

			return 1;
        }

		public async Task<int> AtualizaEstadosAsync(IList<Cidade> cidades)
        {
            int result = 0;
            using (var transaction = this._testersContext.Database.BeginTransaction())
            {
                try
                {
                     await this.ClearAllAsync(false);
                    await this.SaveRangeAsync(cidades, false);
					result = await this._testersContext.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
            return result;
        }
    }
}
