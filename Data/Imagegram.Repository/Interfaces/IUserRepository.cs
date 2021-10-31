using Imagegram.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imagegram.Repository.Interfaces
{
	public interface IUserRepository
	{
		Guid Save(User user);
		User Get(Guid userId);
	}
}
