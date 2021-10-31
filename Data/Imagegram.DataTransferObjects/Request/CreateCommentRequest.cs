using System;
using System.Collections.Generic;
using System.Text;

namespace Imagegram.DataTransferObjects.Request
{
	public class CreateCommentRequest : RequestBase
	{
		public Guid PostId { get; set; }
		public string Comment { get; set; }
	}
}
