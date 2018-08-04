using System;
using System.ComponentModel.DataAnnotations;

namespace Bruna.Danilo.Testers.Api.Models
{
    public class EstadoModel
    {
		public int Id { get; set; }
		[StringLength(2, ErrorMessage = "O campo estado está inválido")]
		[Required(ErrorMessage = "Favor preencher o estado")]
		public string Value { get; set; }
		public string Text { get; set; }
    }
}
