using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.UserService
{
	public interface IUserService
	{
		Task<bool> UserValidationById(int id);
	}
}
