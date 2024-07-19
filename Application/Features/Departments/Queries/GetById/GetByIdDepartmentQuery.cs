using Application.Features.Departments.Constants;
using Application.Features.Departments.Rules;
using Application.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;

namespace Application.Features.Departments.Queries.GetById
{
    public class GetByIdDepartmentQuery : IRequest<GetByIdDepartmentResponse>
    {
        public int Id { get; set; }

        public class GetByIdDepartmentQueryHandler : IRequestHandler<GetByIdDepartmentQuery, GetByIdDepartmentResponse>
        {
            private readonly IDepartmentRepository _departmentRepository;
            private readonly IMapper _mapper;
            private readonly DepartmentBusinessRules _departmentBusinessRules;

            public GetByIdDepartmentQueryHandler(IDepartmentRepository departmentRepository, IMapper mapper, DepartmentBusinessRules departmentBusinessRules)
            {
                _departmentRepository = departmentRepository;
                _mapper = mapper;
                _departmentBusinessRules = departmentBusinessRules;
            }

            public async Task<GetByIdDepartmentResponse> Handle(GetByIdDepartmentQuery request, CancellationToken cancellationToken)
            {
                Department? department = await _departmentRepository.GetAsync(i => i.Id == request.Id);

                await _departmentBusinessRules.DepartmentDeleteControl(request.Id);

                GetByIdDepartmentResponse response = _mapper.Map<GetByIdDepartmentResponse>(department);
                return response;
            }
        }
    }
}
