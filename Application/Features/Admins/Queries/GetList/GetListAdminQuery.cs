using Application.Features.Users.Queries.GetList;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Admins.Queries.GetList
{
    public class GetListAdminQuery : IRequest<List<GetListAdminResponse>>
    {
        //public int Page { get; set; }
        //public int PageSize { get; set; }

        public class GetListAdminQueryHandler : IRequestHandler<GetListAdminQuery, List<GetListAdminResponse>>
        {
            private readonly IAdminRepository _adminRepository;
            private readonly IMapper _mapper;

            public GetListAdminQueryHandler(IAdminRepository adminRepository, IMapper mapper)
            {
                _adminRepository = adminRepository;
                _mapper = mapper;
            }

            public async Task<List<GetListAdminResponse>> Handle(GetListAdminQuery request, CancellationToken cancellationToken)
            {
                List<Admin> admins = await _adminRepository.GetListAsync();

                List<GetListAdminResponse> response = _mapper.Map<List<GetListAdminResponse>>(admins);
                return response;
            }
        }
    }
}
