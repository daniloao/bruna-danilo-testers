using System;
using System.ComponentModel.DataAnnotations;

namespace Bruna.Danilo.Testers.Models
{
    public class ImagemModel
    {
		public int Id { get; set; }
        [Required]
		public int TipoImagemId { get; set; }
		public string Url{ get; set; }
		public byte[] Logo { get; set; }
    }
}
