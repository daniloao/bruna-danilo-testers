using System;
using System.Collections.Generic;
using System.Linq;
using Bruna.Danilo.Testers.Database.Entities;
using Bruna.Danilo.Testers.Models;
using Microsoft.EntityFrameworkCore;

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

		public int Add(CampanhaModel campanha)
        {
			using (var transaction = _testersContext.Database.BeginTransaction())
            {
                try
                {
					var cm = new Campanha();

                    this.MapAndSave(cm, campanha);

                    transaction.Commit();
                    return cm.Id;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

		public int Update(CampanhaModel campanha)
        {
			using (var transaction = _testersContext.Database.BeginTransaction())
			{
				try
				{
    				var cm = this.GetById(campanha.Id);

					this.MapAndSave(cm, campanha);

					transaction.Commit();
					return cm.Id;
                }
                catch (Exception ex)
                {
					transaction.Rollback();
					throw ex;
                }
			}
        }

		private void MapAndSave(Campanha campanhaEntity, CampanhaModel campanha)
		{
			this.SaveCampanha(campanhaEntity, campanha);
            this.SaveImagens(campanhaEntity.Id, campanha.Imagens, campanha.UpdatedById);
			if (!campanha.Nacional)
			{
				this.SaveEstados(campanhaEntity.Id, campanha.Estados, campanha.UpdatedById);
				this.SaveCidades(campanhaEntity.Id, campanha.Cidades, campanha.UpdatedById);
			}
		}

		private void SaveCampanha(Campanha campanhaEntity, CampanhaModel campanha)
		{
			if (campanha.Anunciante.Id <= 0)
            {
                campanhaEntity.AnuncianteId = this.InsertNovoAnunciante(campanha.Anunciante, campanha.UpdatedById);
            }
            else
            {
                campanhaEntity.AnuncianteId = campanha.Anunciante.Id;
            }

			campanhaEntity.Chave = campanha.Chave;
            campanhaEntity.Titulo = campanha.Titulo;
            campanhaEntity.Texto = campanha.Texto;
            campanhaEntity.TipoCampanhaId = campanha.TipoCampanhaId;
            campanhaEntity.DataInicio = campanha.DataInicio;
            campanhaEntity.DataFim = campanha.DataFim;
            campanhaEntity.IsActive = true;
            campanhaEntity.LinkTrackeado = campanha.LinkTrackeado;
            campanhaEntity.Cupom = campanha.Cupom;
            campanhaEntity.ClienteId = campanha.ClienteId;
            campanhaEntity.UpdateDate = DateTime.UtcNow;
            campanhaEntity.UpdatedById = campanha.UpdatedById;

            if (campanhaEntity.Id > 0)
            {
                _testersContext.Campanhas.Update(campanhaEntity);
            }
            else
            {
                campanhaEntity.CreatedById = campanha.UpdatedById;
                campanhaEntity.CreatedDate = DateTime.UtcNow;
                _testersContext.Campanhas.Add(campanhaEntity);
            }

            _testersContext.SaveChanges();
		}

		private void SaveCidades(int campanhaId, List<CidadeModel> cidades, string updatedById)
		{
			this.DeleteCidadesExitentes(campanhaId);

			cidades.ForEach(current =>
            {
                _testersContext.CampanhaCidades.Add(new CampanhaCidade()
                {
                    CampanhaId = campanhaId,
                    CidadeId = current.Id
                });
            });
            _testersContext.SaveChanges();
		}

		private void DeleteCidadesExitentes(int campanhaId)
		{
			var cidadesToRemove = _testersContext.CampanhaCidades
                                     .AsQueryable()
                                     .Where(es => es.CampanhaId == campanhaId)
                                     .ToList();

			_testersContext.CampanhaCidades.RemoveRange(cidadesToRemove);
            _testersContext.SaveChanges();
		}

		private void SaveEstados(int campanhaId, List<EstadoModel> estados, string updatedById)
		{
			this.DeleteEstadosExitentes(campanhaId);

			estados.ForEach(current =>
			{
				_testersContext.CampanhaEstados.Add(new CampanhaEstado()
				{
                    CampanhaId = campanhaId,
                    EstadoId = current.Id
				});
			});
			_testersContext.SaveChanges();
		}

		private void DeleteEstadosExitentes(int campanhaId)
		{
			var estadosToRemove = _testersContext.CampanhaEstados
												 .AsQueryable()
												 .Where(es => es.CampanhaId == campanhaId)
			                                     .ToList();

			_testersContext.CampanhaEstados.RemoveRange(estadosToRemove);
			_testersContext.SaveChanges();
		}

		private void SaveImagens(int campanhaId, List<ImagemModel> imagens, string updatedById)
		{
			this.DeleteImagensExistentes(campanhaId);

			imagens.ForEach(current =>
			{
    			if (current.TipoImagemId == (int)TipoImagemEnum.Upload)
    			{
    				this.UploadToAzure(current);
    			}

    			var imagem = new Imagem()
    			{
    				Nome = current.Url.Substring(current.Url.LastIndexOf("/", comparisonType: StringComparison.CurrentCulture)),
    				TipoImagemId = current.TipoImagemId,
    				Url = current.Url,
    				IsActive = true,
    				CreatedDate = DateTime.UtcNow,
    				UpdateDate = DateTime.UtcNow,
    				CreatedById = updatedById,
    				UpdatedById = updatedById,
    				Logo = current.Logo
    			};

    		    _testersContext.Imagens.Add(imagem);
				_testersContext.SaveChanges();

				var campanhaImagem = new CampanhaImagem()
				{
                    CampanhaId = campanhaId,
                    ImagemId = imagem.Id
				};

				_testersContext.CampanhaImagens.Add(campanhaImagem);
				_testersContext.SaveChanges();
;			});
		}

		private void UploadToAzure(ImagemModel current)
		{
			// TODO
			throw new NotImplementedException();
		}

		private void DeleteImagensExistentes(int campanhaId)
		{
			var campanhasImagem = this._testersContext
										  .CampanhaImagens
                                          .Include(imgCmp => imgCmp.Imagem)
										  .AsQueryable()
									      .Where(cmpImg => cmpImg.CampanhaId == campanhaId)
			                              .ToList();

			campanhasImagem.ForEach(current =>
			{
                if(current.Imagem.TipoImagemId == (int)TipoImagemEnum.Upload)
				{
					this.DeleteImagemFromAzure(current.Imagem);
				}
				_testersContext.Imagens.Remove(current.Imagem);
			});

			_testersContext.CampanhaImagens.RemoveRange(campanhasImagem);

			_testersContext.SaveChanges();
		}

		private void DeleteImagemFromAzure(Imagem imagem)
		{
			// TODO
			throw new NotImplementedException();
		}

		private int InsertNovoAnunciante(AnuncianteModel anunciante, string userId)
		{
			var anc = new Anunciante()
			{
				Nome = anunciante.Nome,
				CreatedById = userId,
				CreatedDate = DateTime.UtcNow,
				IsActive = true,
				UpdateDate = DateTime.UtcNow,
				UpdatedById = userId
			};

			this._testersContext.Anunciantes.Add(anc);
			this._testersContext.SaveChanges();
			return anc.Id;
		}

		public int SaveCliente(CampanhaModel model)
        {
            if (model.Id > 0)
                return this.Update(model);
            
            return this.Add(model);
        }
    }
}
