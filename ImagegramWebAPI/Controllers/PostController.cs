using Imagegram.DataTransferObjects;
using Imagegram.DataTransferObjects.Request;
using Imagegram.DataTransferObjects.Response;
using Imagegram.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImagegramWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PostController : ControllerBase
	{
		private readonly IPostService _postService;

		public PostController(IPostService postService)
		{
			_postService = postService;
		}

		[HttpPost("Create")]		
		public async Task<IdResponseBase> Create([FromForm]CreatePostRequest request)
		{
			return await _postService.CreatePost(request);
		}

		[HttpGet("GetList/cursor")]		
		public GetPostListResponse GetPostListWithComments(int? before = null, int? after = null, int size = 10)
		{
			return _postService.GetPostListWithComments(before, after, size);
		}

	}
}
