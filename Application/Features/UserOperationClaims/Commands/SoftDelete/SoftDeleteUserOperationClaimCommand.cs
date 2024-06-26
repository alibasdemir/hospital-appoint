using Application.Features.UserOperationClaims.Constants;
using Application.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Entities;
using MediatR;

namespace Application.Features.UserOperationClaims.Commands.SoftDelete
{
    public class SoftDeleteUserOperationClaimCommand : IRequest<SoftDeleteUserOperationClaimResponse>
    {
        public int Id { get; set; }

        public class SoftDeleteUserOperationClaimCommandHandler : IRequestHandler<SoftDeleteUserOperationClaimCommand, SoftDeleteUserOperationClaimResponse>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IMapper _mapper;

            public SoftDeleteUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
            }

            public async Task<SoftDeleteUserOperationClaimResponse> Handle(SoftDeleteUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                UserOperationClaim? userOperationClaim = await _userOperationClaimRepository.GetAsync(i => i.Id == request.Id);

                if (userOperationClaim == null || userOperationClaim.IsDeleted == true) 
                {
                    throw new NotFoundException(UserOperationClaimsMessages.UserOperationClaimNotExists);
                }

                await _userOperationClaimRepository.SoftDeleteAsync(userOperationClaim);

                SoftDeleteUserOperationClaimResponse response = _mapper.Map<SoftDeleteUserOperationClaimResponse>(userOperationClaim);
                return response;
            }
        }
    }
}
