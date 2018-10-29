using System;
using System.Collections.Generic;
using System.Linq;
using Bruna.Danilo.Testers.Database.Entities;

namespace Bruna.Danilo.Testers.Database
{
    public class AnuncianteDao
    {
		private TestersContext _testersContext;

		public AnuncianteDao(TestersContext testersContext)
        {
            this._testersContext = testersContext;
        }

		public IList<Anunciante> GetAll(bool bringInactive = false)
        {
			var query = this._testersContext.Anunciantes
                            .AsQueryable();

			if(bringInactive){
				query = query.Where(current => current.IsActive == true);
			}
			return query.ToList();
        }

		public Anunciante GetById(int id)
        {
			return this._testersContext.Anunciantes.Find(id);
        }

		public int Add(Anunciante anunciante)
        {
			anunciante.CreatedDate = DateTime.Now;
			this._testersContext.Anunciantes.Add(anunciante);
            return this._testersContext.SaveChanges();
        }

		public int Update(Anunciante anunciante)
        {
			var an = this.GetById(anunciante.Id);

            if (an == null)
				throw new Exception($"Anunciante não encontrado: {anunciante.Id}");

			this.Map(anunciante, ref an);
            an.UpdateDate = DateTime.Now;
            return this._testersContext.SaveChanges();
        }

		private void Map(Anunciante cliente, ref Anunciante cl)
        {
			cl.Nome = cliente.Nome;
			cl.Descricao = cliente.Descricao;
			cl.Observacao = cliente.Observacao;
            cl.CreatedById = cliente.CreatedById;
            cl.CreatedDate = cliente.CreatedDate;
            cl.UpdatedById = cliente.UpdatedById;
            cl.UpdateDate = cliente.UpdateDate;
        }
    }
}
