using System;
namespace Bruna.Danilo.Testers.Api.Models
{
	public class UserModel : BaseModel
    {
        public UserModel()
        {
        }

		public string UserName { get; set; }
		public string UserPassword { get; set; }
		public string Email { get; set; }
		public string Token { get; set; }

		public UserModel ClearPassword(){
			this.UserPassword = String.Empty;
			return this;
		}
    }
}
