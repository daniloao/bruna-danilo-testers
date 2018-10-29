using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bruna.Danilo.Testers.Database.Entities
{
	[Table("Imagem")]
    public class Imagem
    {
		[Key]
        public int Id { get; set; }

		[Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }

		[Required(ErrorMessage = "O campo Tipo Imagem é obrigatório.")]
        public int TipoImagemId { get; set; }

		[Required(ErrorMessage = "O campo Tipo Imagem é obrigatório.")]
		[ForeignKey("TipoImagemId")]
		public TipoImagem TipoImagem { get; set; }

		[Required(ErrorMessage = "O campo Url é obrigatório.")]
        public string Url { get; set; }

		public byte[] Logo { get; set; }

		public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        [StringLength(450)]
        public string CreatedById { get; set; }//nvarchar(450) PK

        [ForeignKey("CreatedById")]
        public User CreatedBy { get; set; }

        [StringLength(450)]
        public string UpdatedById { get; set; }//nvarchar(450) PK

        [ForeignKey("UpdatedById")]
        public User UpdatedBy { get; set; }
    }
}
