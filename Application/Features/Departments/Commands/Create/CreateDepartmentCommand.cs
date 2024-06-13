using Application.Repositories;
using AutoMapper;
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
            private readonly IMapper _mapper;

            public CreateDepartmentCommandHandler(IDepartmentRepository departmentRepository, IMapper mapper)
            {
                _departmentRepository = departmentRepository;
                _mapper = mapper;
            }

            public async Task<CreateDepartmentResponse> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
            {
                Department department = _mapper.Map<Department>(request);
                
                await _departmentRepository.AddAsync(department);
                CreateDepartmentResponse response = _mapper.Map<CreateDepartmentResponse>(department);
                return response;
            }
        }
    }
}
