using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bruna.Danilo.Testers.Database.Entities
{
	[Table("CampanhaImagem")]
    public class CampanhaImagem
    {
		[Key]
        [Column(Order = 0)]
        public int CampanhaId { get; set; }

		[ForeignKey("CampanhaId")]
		public Campanha Campanha { get; set; }

		[Key]
		[Column(Order = 1)]
        public int ImagemId { get; set; }

		[ForeignKey("ImagemId")]
        public Imagem Imagem { get; set; }
    }
}
