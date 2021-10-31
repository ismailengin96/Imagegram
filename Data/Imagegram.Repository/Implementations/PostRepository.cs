using Imagegram.CustomModels;
using Imagegram.Data;
using Imagegram.Models.Models;
using Imagegram.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Imagegram.Repository.Implementations
{
	public class PostRepository : IPostRepository
	{
		private readonly IDataContext _context;

		public PostRepository(IDataContext context)
		{
			_context = context;
		}

		public Post Get(Guid postId)
		{
			return _context.Posts.Find(postId);
		}	

		public IList<PostWithComments> GetPostListWithComments(int? before, int? after, int size)
		{
			var query = _context.Posts.Include(x => x.Comments)
									.OrderByDescending(x => x.Comments.Count())
									.AsEnumerable()
									.Select((x, index) => new PostWithComments
									{
										Post = x,
										CommentList = x.Comments.Take(2),
										Index = index + 1
									});

			if (after.HasValue)
			{
				return query.Where(t => t.Index > after)
							.Take(size)
							.ToList();
			}
			else if (before.HasValue)
			{
				return query.Where(t => t.Index < before)
							.OrderByDescending(t => t.Index)
							.Take(size)
							.ToList();
			}
			else
			{
				return query.Take(size).ToList();
			}
		}

		public Guid Save(Post post)
		{
			_context.Posts.Add(post);
			_context.SaveChanges();
			return post.PostId;
		}
	}
}
