using Imagegram.Models.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imagegram.DataTransferObjects.Request
{
	public class CreatePostRequest : RequestBase
	{
		public string Body { get; set; }
		public IFormFileCollection ImageList {get; set;}
	}
}
