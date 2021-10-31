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
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}
		public IdResponseBase Create(CreateUserRequest request)
		{
			User user = new User()
			{
				Username = request.Username,
				CreatedDatetime = DateTime.Now
			};
			var userId = _userRepository.Save(user);

			return new IdResponseBase() { Success = true, Id = userId };
		}
	}
}
