using Application.Features.Departments.Constants;
using Application.Features.Departments.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;
using static Application.Features.Departments.Constants.DepartmentsOperationClaims;

namespace Application.Features.Departments.Commands.Delete
{
    public class DeleteDepartmentCommand : IRequest<DeleteDepartmentResponse>, ISecuredRequest, ILoggableRequest
    {
        public string[] RequiredRoles => [Admin, DepartmentsOperationClaims.Delete];
        public int Id { get; set; }

        public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, DeleteDepartmentResponse>
        {
            private readonly IDepartmentRepository _departmentRepository;
            private readonly IMapper _mapper;
            private readonly DepartmentBusinessRules _departmentBusinessRules;
            public DeleteDepartmentCommandHandler(IDepartmentRepository departmentRepository, IMapper mapper, DepartmentBusinessRules departmentBusinessRules)
            {
                _departmentRepository = departmentRepository;
                _mapper = mapper;
                _departmentBusinessRules = departmentBusinessRules;
            }

            public async Task<DeleteDepartmentResponse> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
            {
                Department? department = await _departmentRepository.GetAsync(i => i.Id == request.Id);

                await _departmentBusinessRules.DepartmentShouldBeExist(request.Id);

                await _departmentRepository.DeleteAsync(department);
                DeleteDepartmentResponse response = _mapper.Map<DeleteDepartmentResponse>(department);
                return response;
            }
        }
    }
}
