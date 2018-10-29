using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bruna.Danilo.Testers.Models
{
    public class CampanhaModel
    {
        public int Id { get; set; }

        [StringLength(450, ErrorMessage = "Tamanho maxiom de 450 characteres")]
        [Required(ErrorMessage = "O campo Chave é obrigatório.")]
        public string Chave { get; set; }

        [Required(ErrorMessage = "O campo Titulo é obrigatório.")]
        public string Titulo { get; set; }

        public string Texto { get; set; }

        [Required(ErrorMessage = "O campo Tipo de Campanha é obrigatório.")]
        public int TipoCampanhaId { get; set; }
        
        [Required(ErrorMessage = "O campo Data de Inicio é obrigatório.")]
        public DateTime DataInicio { get; set; }

        public DateTime? DataFim { get; set; }

        public bool IsActive { get; set; }

        [Required(ErrorMessage = "O campo Link Trackeado é obrigatório.")]
        public string LinkTrackeado { get; set; }

        public string Cupom { get; set; }

		public bool Nacional { get; set; }

        [Required(ErrorMessage = "O campo Cliente é obrigatório.")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "O campo Anunciante é obrigatório.")]
        public AnuncianteModel Anunciante { get; set; }
        
        public List<ImagemModel> Imagens { get; set; }
        
        public List<EstadoModel> Estados { get; set; }
        
        public List<CidadeModel> Cidades { get; set; }

		public string UpdatedById { get; set; }
	}
}
