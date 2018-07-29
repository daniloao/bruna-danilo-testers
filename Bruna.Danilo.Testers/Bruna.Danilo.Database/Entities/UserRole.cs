using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bruna.Danilo.Testers.Database.Entities
{
	[Table("AspNetUserRoles")]
    public class UserRole
    {
		[Key]
        [StringLength(450)]
		public string UserId { get; set; }//nvarchar(450) PK

		[Key]
        [StringLength(450)]
		public string RoleId { get; set; }//nvarchar(450) PK
        
		[ForeignKey("UserId")]
        public User User { get; set; }

		[ForeignKey("RoleId")]
		public Role Role { get; set; }
    }
}
