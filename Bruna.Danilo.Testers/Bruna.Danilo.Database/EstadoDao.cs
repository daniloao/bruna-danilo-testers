using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bruna.Danilo.Testers.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Bruna.Danilo.Testers.Database
{
    public class EstadoDao
    {
		private TestersContext _testersContext;

		public EstadoDao(TestersContext testersContext)
        {
            this._testersContext = testersContext;
        }

		public IList<Estado> GetAll(){
			return this._testersContext.Estados
				       .ToList();
		}
        
		public async Task<int> ClearAllAsync(bool saveChanges = true){
			this._testersContext.Cidades.RemoveRange(this._testersContext.Cidades);
			this._testersContext.Estados.RemoveRange(this._testersContext.Estados);
            if(saveChanges)
			    return await this._testersContext.SaveChangesAsync();
			
			return 1;
		}

		public async Task<int> SaveAsync(Estado estado, bool saveChanges = true){
			this._testersContext.Estados.Add(estado);
			if (saveChanges)
				return await this._testersContext.SaveChangesAsync();

			return 1;
		}

		public async Task<int> SaveRangeAsync(IList<Estado> estados, bool saveChanges = true){         
			foreach(var estado in estados){
				await this.SaveAsync(estado,false);
			}

			if(saveChanges)
			    return await this._testersContext.SaveChangesAsync();

			return 1;
		}
        
		public async Task<int> AtualizaEstadosAsync(IList<Estado> estados){
			int result = 0;
			using (var transaction = this._testersContext.Database.BeginTransaction())
            {
                try
                {
					foreach (var currentEstado in estados)
					{
						var estado = this._testersContext.Estados.Find(currentEstado.Id);
						if (estado == null)
							await this.SaveAsync(currentEstado, false);
					}

					this._testersContext.SaveChanges();
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
