using Application.Features.Departments.Constants;
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
            public DeleteDepartmentCommandHandler(IDepartmentRepository departmentRepository, IMapper mapper)
            {
                _departmentRepository = departmentRepository;
                _mapper = mapper;
            }

            public async Task<DeleteDepartmentResponse> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
            {
                Department? department = await _departmentRepository.GetAsync(i => i.Id == request.Id);

                if (department == null)
                {
                    throw new NotFoundException(DepartmentsMessages.DepartmentNotExists);
                }

                await _departmentRepository.DeleteAsync(department);
                DeleteDepartmentResponse response = _mapper.Map<DeleteDepartmentResponse>(department);
                return response;
            }
        }
    }
}
