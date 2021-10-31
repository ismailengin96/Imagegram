using Imagegram.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imagegram.CustomModels
{
	public class PostAndCommentCount
	{
		public Post Post { get; set; }
		public int CommentCount { get; set; }
		public IEnumerable<Comment> CommentList { get; set; }
	}
}
