using System;
using System.ComponentModel.DataAnnotations;

namespace Bruna.Danilo.Testers.Api.Models
{
	public class RegisterModel : UserModel
    {
		[Required(ErrorMessage = "Confirm Password is required")]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "A confirmacao da senha esta invalida")]
        public string ConfirmPassword { get; set; }
    }
}
