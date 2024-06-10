using Application.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Departments.Commands.Create
{
    public class CreateDepartmentCommand : IRequest<CreateDepartmentResponse>
    {
        public string DepartmentName { get; set; }
        public string DepartmentDescription { get; set; }

        public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, CreateDepartmentResponse>
        {
            private readonly IDepartmentRepository _departmentRepository;

            public CreateDepartmentCommandHandler(IDepartmentRepository departmentRepository)
            {
                _departmentRepository = departmentRepository;
            }

            public async Task<CreateDepartmentResponse> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
            {
                Department department = new()
                {
                    DepartmentName = request.DepartmentName,
                    DepartmentDescription = request.DepartmentDescription,
                };
                await _departmentRepository.AddAsync(department);
                return new CreateDepartmentResponse()
                {
                    DepartmentName = department.DepartmentName,
                    DepartmentDescription = department.DepartmentDescription,

                };
            }
        }
    }
}
