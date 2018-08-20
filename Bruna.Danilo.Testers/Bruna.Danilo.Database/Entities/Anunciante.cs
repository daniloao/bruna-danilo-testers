using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bruna.Danilo.Testers.Database.Entities
{
	[Table("Anunciante")]
    public class Anunciante
    {
		[Key]
        public int Id { get; set; }

		[Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }
        
        public string Descricao { get; set; }

        public string Observacao { get; set; }

		public bool IsActive { get; set; }
        
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
