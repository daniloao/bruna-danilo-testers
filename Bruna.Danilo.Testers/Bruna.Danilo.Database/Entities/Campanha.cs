using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bruna.Danilo.Testers.Database.Entities
{
	[Table("Campanha")]
    public class Campanha
    {
		[Key]
        public int Id { get; set; }

        [StringLength(450)]
		[Required(ErrorMessage = "O campo Chave é obrigatório.")]
		public string Chave { get; set; }

		[Required(ErrorMessage = "O campo Titulo é obrigatório.")]
        public string Titulo { get; set; }
        
        public string Texto { get; set; }

		[Required(ErrorMessage = "O campo Tipo de Campanha é obrigatório.")]
		public int TipoCampanhaId { get; set; }

		[ForeignKey("TipoCampanhaId")]
		public TipoCampanha TipoCampanha { get; set; }

		public int? CidadeId { get; set; }

		[ForeignKey("CidadeId")]
		public Cidade Cidade{ get; set; }

		public int? EstadoId { get; set; }

		[ForeignKey("EstadoId")]
		public Estado Estado { get; set; }
        
		public byte[] Logo { get; set; }

		public string LogoUrl { get; set; }

		[Required(ErrorMessage = "O campo Data de Inicio é obrigatório.")]
		public DateTime DataInicio { get; set; }

		public DateTime? DataFim { get; set; }
        
		public bool IsActive { get; set; }

		[Required(ErrorMessage = "O campo Link Trackeado é obrigatório.")]
		public string LinkTrackeado { get; set; }

		public string Cupom { get; set; }

		[Required(ErrorMessage = "O campo Cliente é obrigatório.")]
		public int ClienteId { get; set; }

		[ForeignKey("ClienteId")]
		public Cliente Cliente { get; set; }

		[Required(ErrorMessage = "O campo Anunciante é obrigatório.")]
		public int AnuncianteId { get; set; }

		[ForeignKey("AnuncianteId")]
		public Anunciante Anunciante { get; set; }
        
        public DateTime CreatedDate { get; set; }
        
        [StringLength(450)]
        public string CreatedById { get; set; }//nvarchar(450) PK

        [ForeignKey("CreatedById")]
        public User CreatedBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        [StringLength(450)]
        public string UpdatedById { get; set; }//nvarchar(450) PK

        [ForeignKey("UpdatedById")]
        public User UpdatedBy { get; set; }
    }
}
