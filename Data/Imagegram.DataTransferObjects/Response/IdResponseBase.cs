using System;
using System.Collections.Generic;
using System.Text;

namespace Imagegram.DataTransferObjects
{
	public class IdResponseBase : ResponseBase
	{
		public Guid Id { get; set; }
	}
}
