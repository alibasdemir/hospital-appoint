using Application.Features.OperationClaims.Queries.GetById;
using Application.Features.UserOperationClaims.Constants;
using Application.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
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

            public GetByIdUserOperationClaimQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdUserOperationClaimResponse> Handle(GetByIdUserOperationClaimQuery request, CancellationToken cancellationToken)
            {
                UserOperationClaim? userOperationClaim = await _userOperationClaimRepository.GetAsync(i => i.Id == request.Id);

                if (userOperationClaim == null || userOperationClaim.IsDeleted == true) 
                {
                    throw new NotFoundException(UserOperationClaimsMessages.UserOperationClaimNotExists);
                }

                GetByIdUserOperationClaimResponse response = _mapper.Map<GetByIdUserOperationClaimResponse>(userOperationClaim);
                return response;
            }
        }
    }
}

