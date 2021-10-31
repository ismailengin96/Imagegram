using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Imagegram.Models.Models
{
	public class User : GlobalModel
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Guid UserId { get; set; }
		[MaxLength(20)]
		public string Username { get; set; }
	    public virtual ICollection<Comment> Comments { get; private set; }
		public virtual ICollection<Post> Posts { get; private set; }
	}
}
