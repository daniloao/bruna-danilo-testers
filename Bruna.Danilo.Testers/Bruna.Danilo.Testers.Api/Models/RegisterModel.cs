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

		[Required(ErrorMessage = "Confirm Email is required")]  
		[DataType(DataType.EmailAddress)]
		[Compare("Email", ErrorMessage = "A confirmacao do email esta invalida")]
		public string ConfirmEmail { get; set; }

        [Required]
        public string FullName { get; set; }//nvarchar(max)
        [Required]
        [StringLength(1)]
        public string Sex { get; set; }//nvarchar(1)

		[StringLength(2)]
        public string Estado { get; set; }//nvarchar(2)
        [Required]
        public string City { get; set; }//nvarchar(max)
        [Required]
        public bool AcceptTerms { get; set; }//bit
    }
}
