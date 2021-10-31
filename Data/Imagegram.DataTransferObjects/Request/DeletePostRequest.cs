using System;
using System.Collections.Generic;
using System.Text;

namespace Imagegram.DataTransferObjects.Request
{
	public class DeletePostRequest : RequestBase
	{
		public Guid CommentId { get; set; }
	}
}
