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

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
        }

		public async Task<User> GetUserByIdAsync(int id)
		{
			User? user = await _userRepository.GetAsync(i => i.Id == id);
			return user;
		}
    }
}
