using Application.Repositories;
using AutoMapper;
using Core.Paging;
using Core.Requests;
using Core.Responses;
using Domain.Entities;
using MediatR;

namespace Application.Features.Departments.Queries.GetList
{
    public class GetListDepartmentQuery : IRequest<GetListResponse<GetListDepartmentResponse>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListDepartmentQueryHandler : IRequestHandler<GetListDepartmentQuery, GetListResponse<GetListDepartmentResponse>>
        {
            private readonly IDepartmentRepository _departmentRepository;
            private readonly IMapper _mapper;

            public GetListDepartmentQueryHandler(IDepartmentRepository departmentRepository, IMapper mapper)
            {
                _departmentRepository = departmentRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetListDepartmentResponse>> Handle(GetListDepartmentQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Department> departments = await _departmentRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                );

                var response = _mapper.Map<GetListResponse<GetListDepartmentResponse>>(departments);
                return response;
            }
        }
    }
}
