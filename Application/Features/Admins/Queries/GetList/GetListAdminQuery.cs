using Application.Repositories;
using AutoMapper;
using Core.Paging;
using Core.Requests;
using Core.Responses;
using Domain.Entities;
using MediatR;

namespace Application.Features.Admins.Queries.GetList
{
    public class GetListAdminQuery : IRequest<GetListResponse<GetListAdminResponse>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListAdminQueryHandler : IRequestHandler<GetListAdminQuery, GetListResponse<GetListAdminResponse>>

        {
            private readonly IAdminRepository _adminRepository;
            private readonly IMapper _mapper;

            public GetListAdminQueryHandler(IAdminRepository adminRepository, IMapper mapper)
            {
                _adminRepository = adminRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetListAdminResponse>> Handle(GetListAdminQuery request, CancellationToken cancellationToken)

            {
                IPaginate<Admin> admins = await _adminRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                    );

                var response = _mapper.Map<GetListResponse<GetListAdminResponse>>(admins);

                return response;
            }
        }
    }
}
