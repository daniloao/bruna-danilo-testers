using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bruna.Danilo.Testers.Database.Entities
{
	[Table("Cidade")]
    public class Cidade
    {
		[Key]
        public int Id { get; set; }
        
		[Required]
        public string EstadoId { get; set; }

		[ForeignKey("EstadoId")]
		public Estado Estado { get; set; }

		[Required]
        public string Nome { get; set; }
    }
}
