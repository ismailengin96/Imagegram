using Imagegram.Data;
using Imagegram.Models.Models;
using Imagegram.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imagegram.Repository.Implementations
{
	public class CommentRepository : ICommentRepository
	{
		private readonly IDataContext _context;

		public CommentRepository(IDataContext context)
		{
			_context = context;
		}
		public int Delete(Comment comment)
		{
			_context.Comments.Remove(comment);
			return _context.SaveChanges();
		}

		public Comment Get(Guid commentId)
		{
			return _context.Comments.Find(commentId);
		}

		public Guid Save(Comment comment)
		{
			_context.Comments.Add(comment);
			_context.SaveChanges();
			return comment.CommentId;
		}
	}
}
