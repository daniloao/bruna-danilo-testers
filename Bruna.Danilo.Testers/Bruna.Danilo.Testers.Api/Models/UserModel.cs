using System;
using System.ComponentModel.DataAnnotations;

namespace Bruna.Danilo.Testers.Api.Models
{
	public class UserModel 
    {
        public UserModel()
        {
        }

		[Required(ErrorMessage = "Favor preencher seu nome de usuário")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Favor preencher com um e-mail válido")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Favor preencher sua senha")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required(ErrorMessage = "Favor preencher seu e-mail")]
		[DataType(DataType.EmailAddress, ErrorMessage = "Favor preencher com um e-mail válido")]
		public string Email { get; set; }

		public string Token { get; set; }

		public virtual UserModel ClearPassword(){
			this.Password = String.Empty;
			return this;
		}
    }
}
