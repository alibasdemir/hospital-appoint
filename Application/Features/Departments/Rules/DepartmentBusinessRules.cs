using Application.Features.Departments.Constants;
using Application.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Departments.Rules
{
    public class DepartmentBusinessRules
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentBusinessRules(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task DepartmentShouldBeExist(int id)
        {
            Department? department = await _departmentRepository.GetAsync(i => i.Id == id);
            if (department == null)
            {
                throw new BusinessException(DepartmentsMessages.DepartmentNotExists);
            } 
        }

        public async Task DepartmentDeleteControl(int id)
        {
            Department? department = await _departmentRepository.GetAsync(i => i.Id == id);
            if(department == null || department.IsDeleted == true)
            {
                throw new BusinessException(DepartmentsMessages.DepartmentNotExists);
            }
        }
    }
}
