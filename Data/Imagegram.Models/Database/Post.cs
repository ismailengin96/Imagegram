using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Imagegram.Models.Models
{
	public class Post : GlobalModel
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Guid PostId { get; set; }
		[MaxLength(250)]
		public string Body { get; set; }
		public Guid UserId { get; set; }
		public User User { get; private set; }
		public virtual ICollection<Comment> Comments { get; private set; }
		public virtual ICollection<Image> Images { get; private set; }
	}
}
