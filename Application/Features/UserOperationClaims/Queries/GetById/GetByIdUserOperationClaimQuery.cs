using Application.Repositories;
using AutoMapper;
using Core.Entities;
using MediatR;

namespace Application.Features.UserOperationClaims.Queries.GetById
{
    public class GetByIdUserOperationClaimQuery : IRequest<GetByIdUserOperationClaimResponse>
    {
        public int Id { get; set; }
        public class GetByIdUserOperationClaimQueryHandler : IRequestHandler<GetByIdUserOperationClaimQuery, GetByIdUserOperationClaimResponse>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IMapper _mapper;
            private readonly UserOperationClaimBusinessRule _userOperationClaimBusinessRule;

            public GetByIdUserOperationClaimQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper, UserOperationClaimBusinessRule userOperationClaimBusinessRule)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
                _userOperationClaimBusinessRule = userOperationClaimBusinessRule;
            }

            public async Task<GetByIdUserOperationClaimResponse> Handle(GetByIdUserOperationClaimQuery request, CancellationToken cancellationToken)
            {
                UserOperationClaim? userOperationClaim = await _userOperationClaimRepository.GetAsync(i => i.Id == request.Id);

                await _userOperationClaimBusinessRule.UserOperationClaimDeleteControl(request.Id);

                GetByIdUserOperationClaimResponse response = _mapper.Map<GetByIdUserOperationClaimResponse>(userOperationClaim);
                return response;
            }
        }
    }
}

