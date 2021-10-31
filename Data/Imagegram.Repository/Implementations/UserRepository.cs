using Imagegram.Data;
using Imagegram.Models.Models;
using Imagegram.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imagegram.Repository.Implementations
{
	public class UserRepository : IUserRepository
	{
		private readonly IDataContext _context;

		public UserRepository(IDataContext context)
		{
			_context = context;
		}

		public User Get(Guid userId)
		{
			return _context.Users.Find(userId);
		}

		public Guid Save(User user)
		{
			_context.Users.Add(user);
			_context.SaveChanges();
			return user.UserId;
		}
	}
}
