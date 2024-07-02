using Application.Features.Departments.Constants;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;
using static Application.Features.Departments.Constants.DepartmentsOperationClaims;

namespace Application.Features.Departments.Commands.Create
{
	public class CreateDepartmentCommand : IRequest<CreateDepartmentResponse>, ISecuredRequest, ILoggableRequest
	{
		public string[] RequiredRoles => [Admin, Write, Add];
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
