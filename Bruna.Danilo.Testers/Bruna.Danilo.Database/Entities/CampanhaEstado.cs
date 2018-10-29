using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bruna.Danilo.Testers.Database.Entities
{
	[Table("CampanhaEstado")]
    public class CampanhaEstado
	{
		[Key]
		[Column(Order = 0)]
        public int CampanhaId { get; set; }

        [ForeignKey("CampanhaId")]
        public Campanha Campanha { get; set; }
        
		[Key]
        [Column(Order = 1)]
        public int EstadoId { get; set; }

		[ForeignKey("EstadoId")]
        public Estado Estado { get; set; }
    }
}
