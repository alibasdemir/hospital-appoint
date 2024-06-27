using Application.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.UserService
{
    public class UserManager : IUserService
	{
		private readonly IUserRepository _userRepository;

		public UserManager(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<bool> UserValidationById(int id)
		{
			User? user = await _userRepository.GetAsync(x => x.Id == id);

			if (user == null)
			{
				return false;
			}
			return true;
		}
	}
}
