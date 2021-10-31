using Imagegram.DataTransferObjects;
using Imagegram.DataTransferObjects.Request;
using Imagegram.Models.Models;
using Imagegram.Repository.Interfaces;
using Imagegram.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imagegram.Services.Implementations
{
	public class CommentService : ICommentService
	{
		private readonly ICommentRepository _commentRepository;
		private readonly IUserRepository _userRepository;
		private readonly IPostRepository _postRepository;
		public CommentService(ICommentRepository commentRepository, IUserRepository userRepository, IPostRepository postRepository)
		{
			_commentRepository = commentRepository;
			_userRepository = userRepository;
			_postRepository = postRepository;
		}
		public IdResponseBase CreateComment(CreateCommentRequest request)
		{
			if (request.UserId != Guid.Empty && _userRepository.Get(request.UserId) != null)
			{
				if (request.PostId != Guid.Empty && _postRepository.Get(request.PostId) != null)
				{
					Comment comment = new Comment()
					{
						Body = request.Comment,
						CreatedDatetime = DateTime.Now,
						PostId = request.PostId,
						UserId = request.UserId
					};

					_commentRepository.Save(comment);

					return new IdResponseBase() { Success = true, Id = comment.CommentId };
				}
				else
					return new IdResponseBase() { Success = false, Message = "You must provide a valid PostId!" };
			}
			else
				return new IdResponseBase() { Success = false, Message = "You must provide a valid UserId!" };
		}

		public ResponseBase Delete(DeletePostRequest request)
		{
			if (request.CommentId != Guid.Empty)
			{
				var comment = _commentRepository.Get(request.CommentId);
				if (comment != null)
				{					
					if (comment.UserId == request.UserId)
					{
						_commentRepository.Delete(comment);
						return new ResponseBase() { Success = true };
					}
					else
						return new ResponseBase() { Success = false, Message = "You can't delete someone elses comment!" };
				}
				return new ResponseBase() { Success = false, Message = "We couldn't find any comments with given CommentId" };
			}
			else
				return new ResponseBase() { Success = false, Message = "You must provide a valid CommentId!" };
		}
	}
}
