using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bruna.Danilo.Testers.Models
{
	public class UserModel
    {      
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

        public IList<UserRoleModel> UserRoles { get; set; }

        public virtual UserModel ClearPassword()
        {
            this.Password = String.Empty;
            return this;
        }
    }
}
