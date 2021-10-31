using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Imagegram.Models.Models
{
	public class Comment : GlobalModel
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Guid CommentId { get; set; }		
		public Guid PostId { get; set; }
		public Guid UserId { get; set; }
		[MaxLength(250)]
		public string Body { get; set; }
		public virtual Post Post { get; private set; }
		public virtual User User { get; private set; }
	}
}
