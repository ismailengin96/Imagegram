using System;
using System.Collections.Generic;
using System.Text;

namespace Imagegram.DataTransferObjects
{
	public class IdRequestBase : RequestBase
	{
		public Guid Id { get; set; }
	}
}
