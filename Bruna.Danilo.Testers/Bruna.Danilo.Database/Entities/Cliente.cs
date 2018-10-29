using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bruna.Danilo.Testers.Database.Entities
{
	[Table("Cliente")]
    public class Cliente
    {
		[Key]
        public int Id { get; set; }

		[StringLength(20, ErrorMessage = "Campo CNPJ deve ter no máximo 14 digitos.")]
        [Required(ErrorMessage = "O campo CNPJ é obrigatório.")]
		public string Cnpj { get; set; }
        
		[Required(ErrorMessage = "O campo Razao Social é obrigatório.")]
        public string RazaoSocial { get; set; }

		public string NomeFantasia { get; set; }

		[Required(ErrorMessage = "O campo Endereco é obrigatório.")]
		public string Endereco { get; set; }

        public string Telefone { get; set; }

		public string Skype { get; set; }

		public bool IsActive { get; set; }

		[Required(ErrorMessage = "O campo Email é obrigatório.")]
		[DataType(DataType.EmailAddress, ErrorMessage = "Favor preencher com um e-mail válido")]
		public string Email { get; set; }

		[Required(ErrorMessage = "O campo Contado é obrigatório.")]
        public string Contato { get; set; }

		[Required(ErrorMessage = "O campo Cidade é obrigatório.")]
		public int CidadeId { get; set; }
       
		[Required(ErrorMessage = "O campo Cidade é obrigatório.")]
        [ForeignKey("CidadeId")]
        public Cidade Cidade { get; set; }

		[Required(ErrorMessage = "O campo Estado é obrigatório.")]
        public int EstadoId { get; set; }

        [ForeignKey("EstadoId")]
        public Estado Estado { get; set; }
        
		public DateTime CreatedDate { get; set; }
        
        [StringLength(450)]
        public string CreatedById { get; set; }//nvarchar(450) PK

        [ForeignKey("CreatedById")]
        public User CreatedBy { get; set; }

		public DateTime? UpdateDate { get; set; }

        [StringLength(450)]
        public string UpdatedById { get; set; }//nvarchar(450) PK

        [ForeignKey("UpdatedById")]
        public User UpdatedBy { get; set; }

    }
}
