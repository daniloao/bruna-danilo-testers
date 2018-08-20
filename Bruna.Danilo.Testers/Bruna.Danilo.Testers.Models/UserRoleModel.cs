using System;
using System.ComponentModel.DataAnnotations;

namespace Bruna.Danilo.Testers.Models
{
    public class UserRoleModel
    {
        [StringLength(450)]
        public string UserId { get; set; }//nvarchar(450) PK
        
        [StringLength(450)]
        public string RoleId { get; set; }//nvarchar(450) PK
    }
}
