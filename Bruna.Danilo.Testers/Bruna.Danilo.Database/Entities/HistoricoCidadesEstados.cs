using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bruna.Danilo.Testers.Database.Entities
{
	[Table("HistoricoCidadesEstados")]
    public class HistoricoCidadesEstados
    {
		[Key]
        public int Id { get; set; }  

        [Required]
		public DateTime TimeStamp { get; set; }

		[Required]
		[StringLength(450)]
		public string UserId { get; set; }

		[ForeignKey("UserId")]
		public User User{ get; set; }
    }
}
