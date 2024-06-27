using Application.Repositories;
using Domain.Entities;

namespace Application.Services.DepartmentService
{
    public class DepartmentManager : IDepartmentService
	{
		private readonly IDepartmentRepository _departmentRepository;

		public DepartmentManager(IDepartmentRepository departmentRepository)
		{
			_departmentRepository = departmentRepository;
		}

		public async Task<bool> DepartmentValidationById(int id)
		{
			Department? department = await _departmentRepository.GetAsync(x => x.Id == id);
			if (department == null)
			{
				return false;
			}
			return true;
		}

		public async Task<bool> DepartmentValidationByName(string name)
		{
			Department? department = await _departmentRepository.GetAsync(x => x.Name == name);
			if (department == null)
			{
				return false;
			}
			return true;
		}
	}
}
