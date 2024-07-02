using Application.Features.Departments.Constants;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;
using static Application.Features.Departments.Constants.DepartmentsOperationClaims;

namespace Application.Features.Departments.Commands.Update
{
    public class UpdateDepartmentCommand : IRequest<UpdateDepartmentResponse>, ISecuredRequest, ILoggableRequest
    {
        public string[] RequiredRoles => [Admin, DepartmentsOperationClaims.Update];
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, UpdateDepartmentResponse>
        {
            private readonly IDepartmentRepository _departmentRepository;
            private readonly IMapper _mapper;

            public UpdateDepartmentCommandHandler(IDepartmentRepository departmentRepository, IMapper mapper)
            {
                _departmentRepository = departmentRepository;
                _mapper = mapper;
            }

            public async Task<UpdateDepartmentResponse> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
            {
                Department? department = await _departmentRepository.GetAsync(i => i.Id == request.Id);

                if (department == null || department.IsDeleted == true)
                {
                    throw new NotFoundException(DepartmentsMessages.DepartmentNotExists);
                }
                
                _mapper.Map(request, department);

                await _departmentRepository.UpdateAsync(department);
				UpdateDepartmentResponse response = _mapper.Map<UpdateDepartmentResponse>(department);
                return response;
            }
        }
    }
}
