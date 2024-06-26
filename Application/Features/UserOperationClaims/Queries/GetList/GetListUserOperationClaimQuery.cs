using Application.Repositories;
using AutoMapper;
using Core.Entities;
using Core.Paging;
using Core.Requests;
using Core.Responses;
using MediatR;

namespace Application.Features.UserOperationClaims.Queries.GetList
{
    public class GetListUserOperationClaimQuery : IRequest<GetListResponse<GetListUserOperationClaimResponse>>
    {
        public PageRequest? PageRequest { get; set; }

        public class GetListUserOperationClaimQueryHandler : IRequestHandler<GetListUserOperationClaimQuery, GetListResponse<GetListUserOperationClaimResponse>>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IMapper _mapper;

            public GetListUserOperationClaimQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetListUserOperationClaimResponse>> Handle(GetListUserOperationClaimQuery request, CancellationToken cancellationToken)
            {
                IPaginate<UserOperationClaim> userOperationClaim = await _userOperationClaimRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                );

                GetListResponse<GetListUserOperationClaimResponse> response = _mapper.Map<GetListResponse<GetListUserOperationClaimResponse>>(userOperationClaim);
                return response;
            }
        }
    }
}
