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
        public string Name { get; set; }
        public string Description { get; set; }

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
                    Name = request.Name,
                    Description = request.Description,
                };
                await _departmentRepository.AddAsync(department);
                return new CreateDepartmentResponse()
                {
                    Name = department.Name,
                    Description = department.Description,

                };
            }
        }
    }
}
