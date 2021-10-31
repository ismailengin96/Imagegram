using Imagegram.Models.Models;
using System;
using System.Collections.Generic;

namespace Imagegram.CustomModels
{
	public class PostWithComments
	{
		public Post Post { get; set; }
		public int Index { get; set; }
		public IEnumerable<byte[]> ImageList { get; set; }
		public IEnumerable<Comment> CommentList { get; set; }
	}
}
