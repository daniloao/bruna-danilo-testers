using System;
using System.ComponentModel.DataAnnotations;

namespace Bruna.Danilo.Testers.Models
{
    public class AnuncianteModel
    {
		public string Nome { get; set; }

		[Required(ErrorMessage = "O campo Anunciante é obrigatório.")]
        public int Id { get; set; }
    }
}
