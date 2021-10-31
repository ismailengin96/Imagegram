using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Imagegram.Models.Models
{
	public class Image : GlobalModel
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Guid ImageId { get; set; }
		public Guid PostId { get; set; }
		[MaxLength(100)]
		public string File { get; set; }
		public string MimeType { get; set; }
		public virtual Post Post { get; private set; }
	}
}
