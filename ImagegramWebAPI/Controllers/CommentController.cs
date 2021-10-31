using Imagegram.DataTransferObjects;
using Imagegram.DataTransferObjects.Request;
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
	public class CommentController : ControllerBase
	{
		private readonly ICommentService _commentService;

		public CommentController(ICommentService commentService)
		{
			_commentService = commentService;
		}

		[HttpPost("Create")]		
		public IdResponseBase Create(CreateCommentRequest request)
		{
			return _commentService.CreateComment(request);
		}

		[HttpPost("Delete")]		
		public ResponseBase Delete(DeletePostRequest request)
		{
			return _commentService.Delete(request);
		}
	}
}
