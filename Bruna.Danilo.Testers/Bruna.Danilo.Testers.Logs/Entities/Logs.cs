using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bruna.Danilo.Testers.Logs.Entities
{
	public class Logs
	{
		[Key]
		public int Id {get;set;}

		[Required]
		public int LogTypeId { get; set; }

		[Required]
		public string Message { get; set; }
		public string StackTrace { get; set; }
		public string MoreInfo { get; set; }
        
        [StringLength(450)]
		public string UserId { get; set; }
		[Required]
		public DateTime TimeStamp { get; set; }
        
		public int? ParentLogId { get; set; }

		[ForeignKey("StandardRefId")]
		public Logs ParentLog { get; set; }
    }
}