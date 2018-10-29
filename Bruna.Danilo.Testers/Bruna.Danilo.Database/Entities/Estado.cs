using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bruna.Danilo.Testers.Database.Entities
{
	[Table("Estado")]
    public class Estado
    {
        [Key]
		public int Id { get; set; }

        [StringLength(2)]
        [Required]
		public string Sigla { get; set; }

        public string Nome { get; set; }
    }
}
