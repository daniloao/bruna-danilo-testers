using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bruna.Danilo.Testers.Database.Entities
{
	[Table("AspNetRoles")]
    public class Role
    {
		[Key]
        [StringLength(450)]
        public string Id { get; set; }//nvarchar(450) PK
        [StringLength(256)]
        public string Name { get; set; }//nvarchar(256) NULL

        [StringLength(256)]
		public string NormalizedName { get; set; }//nvarchar(256) NULL

		public string ConcurrencyStamp { get; set; }//nvarchar(256) NULL
    }
}
