using System;
using System.Collections.Generic;
using System.Linq;
using Bruna.Danilo.Testers.Database.Entities;
using Bruna.Danilo.Testers.Models;
using Bruna.Danilo.Testers.Database.Extensions;
namespace Bruna.Danilo.Testers.Database
{
    public class ClienteDao
    {
		private TestersContext _testersContext;

		public ClienteDao(TestersContext testersContext)
        {
            this._testersContext = testersContext;
        }

		public IList<Cliente> GetAll()
        {
			return this._testersContext.Clientes.ToList();
        }

		public Cliente GetById(int id)
        {
			return this._testersContext.Clientes.Find(id);
        }

		public int Add(Cliente cliente)
        {
			cliente.CreatedDate = DateTime.Now;
			this._testersContext.Clientes.Add(cliente);
            return this._testersContext.SaveChanges();
        }

		public int Update(Cliente cliente)
        {
			var cl = this.GetById(cliente.Id);

            if (cl == null)
                throw new Exception($"Cliente não encontrado: {cliente.Id}");

			this.Map(cliente, ref cl);
			cl.UpdateDate = DateTime.Now;
            return this._testersContext.SaveChanges();
        }

		private void Map(Cliente cliente, ref Cliente cl)
        {
			cl.Cnpj = cliente.Cnpj;
			cl.RazaoSocial = cliente.RazaoSocial;
			cl.NomeFantasia = cliente.NomeFantasia;
			cl.Endereco = cliente.Endereco;
			cl.Telefone = cliente.Telefone;
			cl.Skype = cliente.Skype;
			cl.Email = cliente.Email;
			cl.CidadeId = cliente.CidadeId;
			cl.EstadoId = cliente.EstadoId;         
			cl.CreatedById = cliente.CreatedById;
			cl.CreatedDate = cliente.CreatedDate;
			cl.UpdatedById = cliente.UpdatedById;
			cl.UpdateDate = cliente.UpdateDate;
			cl.Contato = cliente.Contato;
        }
        
		public int SaveCliente(Cliente model)
		{
			if (model.Id > 0)
				return this.Update(model);

			return this.Add(model);
		}

		public PagedResponseModel<Cliente> PagedFielter(PagedRequestModel<Cliente> model)
		{
			var resultQuery = new List<Cliente>();
			var query = this._testersContext.Clientes
			                .AsQueryable();

			if (model.Model != null)
			{
				if (model.Model.IsActive)
				{
					query = query.Where(current => current.IsActive == true);
				}
				else
				{
					query = query.Where(current => current.IsActive == false);
				}

				if (!String.IsNullOrEmpty(model.Model.Cnpj))
				{
					query = query.Where(current => current.Cnpj == model.Model.Cnpj);
				}

				if (model.Model.CidadeId > 0)
				{
					query = query.Where(current => current.CidadeId == model.Model.CidadeId);
				}

				if (model.Model.EstadoId > 0)
				{
					query = query.Where(current => current.EstadoId == model.Model.EstadoId);
				}
			}
			if(!String.IsNullOrEmpty(model.FiltrarPorTexto)){
				query = query.Where(current => current.RazaoSocial.Contains(model.FiltrarPorTexto.Trim()) ||
									current.NomeFantasia.Contains(model.FiltrarPorTexto.Trim()) ||
				                    current.Skype.Contains(model.FiltrarPorTexto.Trim()) ||
				                    current.Email.Contains(model.FiltrarPorTexto.Trim()) ||
				                    current.Contato.Contains(model.FiltrarPorTexto.Trim()));
			}
            if(model.SortModel != null)
			    query = query.OrderBy(model.SortModel);
			var count = query.Count();
			if (count > (model.PageSize * model.CurrentPage))
			    query = query
			        .Skip(model.PageSize * model.CurrentPage);

			if((count - model.PageSize * model.CurrentPage) > model.PageSize)
				query = query
				        .Take(model.PageSize);

			resultQuery = query.ToList();
			return new PagedResponseModel<Cliente>()
			{
				Columns = this.GetColumns(),
				Models = resultQuery,
				PageCount = (count / model.PageSize) + ((count % model.PageSize) > 0 ? 1 : 0)
			};
		}

		private IEnumerable<PagedColumn> GetColumns()
		{
			IList<PagedColumn> result = new List<PagedColumn>();
			result.Add(new PagedColumn(){
				ColumnHeader = "ID",
				ColumnType = PagedColumn.NUMBER,
				Format= "0",
                PropertyName = "id"
			});
			result.Add(new PagedColumn()
            {
				ColumnHeader = "CNPJ",
                ColumnType = PagedColumn.STRING,
                Format = "",
				PropertyName = "cnpj"
            });
			result.Add(new PagedColumn()
            {
				ColumnHeader = "Razao Social",
                ColumnType = PagedColumn.STRING,
                Format = "",
				PropertyName = "razaoSocial"
            });
			result.Add(new PagedColumn()
            {
				ColumnHeader = "Nome Fantasia",
				ColumnType = PagedColumn.STRING,
                Format = "",
				PropertyName = "nomeFantasia"
			}); 
			result.Add(new PagedColumn()
            {
				ColumnHeader = "Email",
				ColumnType = PagedColumn.STRING,
                Format = "",
				PropertyName = "email"
            });
			result.Add(new PagedColumn()
            {
				ColumnHeader = "Contato",
                ColumnType = PagedColumn.STRING,
                Format = "",
				PropertyName = "contato"
            });

			return result;
		}
	}
}
