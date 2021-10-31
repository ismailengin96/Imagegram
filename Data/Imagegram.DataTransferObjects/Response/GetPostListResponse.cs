using Imagegram.CustomModels;
using Imagegram.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imagegram.DataTransferObjects.Response
{
	public class GetPostListResponse : ResponseBase
	{
		public IList<PostWithComments> PostList { get; set; }		
	}	
}
