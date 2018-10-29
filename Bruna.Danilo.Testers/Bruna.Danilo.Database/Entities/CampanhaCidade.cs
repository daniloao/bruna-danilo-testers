using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bruna.Danilo.Testers.Database.Entities
{
	[Table("CampanhaCidade")]
    public class CampanhaCidade
    {
		[Key]
        [Column(Order = 0)]
        public int CampanhaId { get; set; }

		[ForeignKey("CampanhaId")]
        public Campanha Campanha { get; set; }

		[Key]
        [Column(Order = 1)]
        public int CidadeId { get; set; }

        [ForeignKey("CidadeId")]
        public Cidade Cidade { get; set; }
    }
}
