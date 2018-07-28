using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bruna.Danilo.Testers.Logs.Entities
{
    public class LogType
    {
		[Key]
		public int Id { get; set; }
        [Required]
		[StringLength(20)]
		public string Description { get; set; }

		public ICollection<Logs> Logs { get; set; }
    }
}
