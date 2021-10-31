using Imagegram.CustomModels;
using Imagegram.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imagegram.Repository.Interfaces
{
	public interface IPostRepository
	{
		Guid Save(Post post);
		Post Get(Guid postId);
		IList<PostWithComments> GetPostListWithComments(int? before, int? after, int size);
	}
}
