using Imagegram.DataTransferObjects;
using Imagegram.DataTransferObjects.Request;
using Imagegram.DataTransferObjects.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Services.Interfaces
{
	public interface IPostService
	{
		Task<IdResponseBase> CreatePost(CreatePostRequest request);
		GetPostListResponse GetPostListWithComments(int? before, int? after, int size);
	}
}
