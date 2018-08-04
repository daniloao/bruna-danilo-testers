using System;
using System.ComponentModel.DataAnnotations;

namespace Bruna.Danilo.Testers.Api.Models
{
    public class RegisterModel : UserModel
    {
        [Required(ErrorMessage = "Favor confirmar sua senha")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "A confirmacao da senha está inválida")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Favor confirmar seu e-mail")]
		[DataType(DataType.EmailAddress, ErrorMessage = "Favor preencher com um e-mail válido")]
        [Compare("Email", ErrorMessage = "A confirmacao do email está\t inválida")]
        public string ConfirmEmail { get; set; }

        [Required(ErrorMessage = "Favor preencher seu nome")]
        public string FullName { get; set; }//nvarchar(max)
        [Required(ErrorMessage = "O campo sexo está inválido")]
        [StringLength(1, ErrorMessage = "O campo sexo está inválido")]
        public string Sex { get; set; }//nvarchar(1)

        [Required(ErrorMessage = "Favor preencher o estado")]
        public EstadoModel Estado { get; set; }//nvarchar(2)
        [Required(ErrorMessage = "Favor preencher a cidade")]
        public string Cidade { get; set; }//nvarchar(max)
        [Required(ErrorMessage = "Favor aceitar os termos e condições")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "Favor aceitar os termos e condições")]
        public bool AcceptTerms { get; set; }//bit
    }
}
