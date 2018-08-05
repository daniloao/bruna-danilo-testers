using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bruna.Danilo.Testers.Database.Entities
{
	[Table("AspNetUsers")]
    public class User
    {
		[Key]
		[StringLength(450)]
		public string Id { get; set; }//nvarchar(450) PK
		[StringLength(256)]
		public string UserName { get; set; }//nvarchar(256) NULL
		[StringLength(256)]
		public string NormalizedUserName { get; set; }//nvarchar(256) NULL
		[StringLength(256)]
		public string Email { get; set; }//nvarchar(256) NULL
		[StringLength(256)]
		public string NormalizedEmail { get; set; }//nvarchar(256) INDEX NULL
		[Required]
		public bool EmailConfirmed { get; set; }//bit
		public string PasswordHash { get; set; }//nvarchar(max) NULL
		public string SecurityStamp { get; set; }//nvarchar(max) NULL
		public string ConcurrencyStamp { get; set; }//nvarchar(max) NULL
		public string PhoneNumber { get; set; }//nvarchar(max) NULL
		[Required]
		public bool PhoneNumberConfirmed { get; set; }//bit
		[Required]
		public bool TwoFactorEnabled { get; set; }//bit
		public DateTimeOffset? LockoutEnd { get; set; }//datetimeoffset NULL
		[Required]
		public bool LockoutEnabled { get; set; }//bit
		[Required]
		public int AccessFailedCount { get; set; }//int

		public string FullName { get; set; }//nvarchar(max)

		[StringLength(1)]
		public string Sex { get; set; }//nvarchar(1)

		public string City { get; set; }//nvarchar(max)

		[StringLength(2)]
        public string Estado { get; set; }//nvarchar(max)

		[Required]
		public bool AcceptTerms { get; set; }//bit
    }
}
