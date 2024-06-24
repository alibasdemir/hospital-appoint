using Application.Features.Departments.Constants;
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

            public GetByIdDepartmentQueryHandler(IDepartmentRepository departmentRepository, IMapper mapper)
            {
                _departmentRepository = departmentRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdDepartmentResponse> Handle(GetByIdDepartmentQuery request, CancellationToken cancellationToken)
            {
                Department? department = await _departmentRepository.GetAsync(i => i.Id == request.Id);
                if (department == null)
                {
                    throw new NotFoundException(DepartmentsMessages.DepartmentNotExists);
                }

                GetByIdDepartmentResponse response = _mapper.Map<GetByIdDepartmentResponse>(department);
                return response;
            }
        }
    }
}
