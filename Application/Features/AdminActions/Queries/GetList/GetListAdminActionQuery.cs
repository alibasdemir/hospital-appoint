using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AdminActions.Queries.GetList
{
    public class GetListAdminActionQuery : IRequest<List<GetListAdminActionResponse>>
    {
        //public int Page { get; set; }
        //public int PageSize { get; set; }

        public class GetListAdminActionQueryHandler : IRequestHandler<GetListAdminActionQuery, List<GetListAdminActionResponse>>
        {
            private readonly IAdminActionRepository _adminActionRepository;
            private readonly IMapper _mapper;

            public GetListAdminActionQueryHandler(IAdminActionRepository adminActionRepository, IMapper mapper)
            {
                _adminActionRepository = adminActionRepository;
                _mapper = mapper;
            }

            public async Task<List<GetListAdminActionResponse>> Handle(GetListAdminActionQuery request, CancellationToken cancellationToken)
            {
                List<AdminAction> adminActions = await _adminActionRepository.GetListAsync();

                List<GetListAdminActionResponse> response = _mapper.Map<List<GetListAdminActionResponse>>(adminActions);
                return response;
            }
        }
    }
}
