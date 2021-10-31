using Imagegram.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imagegram.Repository.Interfaces
{
	public interface ICommentRepository
	{
		Guid Save(Comment comment);
		int Delete(Comment comment);
		Comment Get(Guid commentId);
	}
}
