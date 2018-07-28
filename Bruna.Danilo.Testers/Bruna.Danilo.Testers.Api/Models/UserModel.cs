using System;
using System.ComponentModel.DataAnnotations;

namespace Bruna.Danilo.Testers.Api.Models
{
	public class UserModel 
    {
        public UserModel()
        {
        }

        [Required]
		public string Name { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[Required]
		public string Email { get; set; }
		public string Token { get; set; }

		public UserModel ClearPassword(){
			this.Password = String.Empty;
			return this;
		}
    }
}
