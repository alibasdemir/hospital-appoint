using Application.Features.Departments.Constants;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;
using static Application.Features.Departments.Constants.DepartmentsOperationClaims;

namespace Application.Features.Departments.Commands.SoftDelete
{
    public class SoftDeleteDepartmentCommand : IRequest<SoftDeleteDepartmentResponse>
    {
        public int Id { get; set; }


        public class SoftDeleteDepartmentCommandHandler : IRequestHandler<SoftDeleteDepartmentCommand, SoftDeleteDepartmentResponse>
        {
            private readonly IDepartmentRepository _departmentRepository;
            private readonly IMapper _mapper;

            public SoftDeleteDepartmentCommandHandler(IDepartmentRepository departmentRepository, IMapper mapper)
            {
                _departmentRepository = departmentRepository;
                _mapper = mapper;
            }

            public async Task<SoftDeleteDepartmentResponse> Handle(SoftDeleteDepartmentCommand request, CancellationToken cancellationToken)
            {
                Department? department = await _departmentRepository.GetAsync(i => i.Id == request.Id);

                if (department == null)
                {
                    throw new NotFoundException(DepartmentsMessages.DepartmentNotExists);
                }
                
                await _departmentRepository.SoftDeleteAsync(department);

                SoftDeleteDepartmentResponse response = _mapper.Map<SoftDeleteDepartmentResponse>(department);
                return response;
            }
        }
    }
}
