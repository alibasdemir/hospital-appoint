using Application.Features.UserOperationClaims.Constants;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Entities;
using MediatR;
using static Application.Features.UserOperationClaims.Constants.UserOperationClaimsOperationClaims;

namespace Application.Features.UserOperationClaims.Commands.Update
{
    public class UpdateUserOperationClaimCommand : IRequest<UpdateUserOperationClaimResponse>, ISecuredRequest, ILoggableRequest
    {
        public string[] RequiredRoles => new[] { Admin, UserOperationClaimsOperationClaims.Update };
        public int Id { get; set; }
        public int BaseUserId { get; set; }
        public int OperationClaimId { get; set; }

        public class UpdateUserOperationClaimCommandHandler : IRequestHandler<UpdateUserOperationClaimCommand, UpdateUserOperationClaimResponse>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IMapper _mapper;

            public UpdateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
            }

            public async Task<UpdateUserOperationClaimResponse> Handle(UpdateUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                UserOperationClaim? userOperationClaim = await _userOperationClaimRepository.GetAsync(i => i.Id == request.Id);

                if (userOperationClaim == null || userOperationClaim.IsDeleted == true) 
                {
                    throw new NotFoundException(UserOperationClaimsMessages.UserOperationClaimNotExists);
                }

                _mapper.Map(request, userOperationClaim);

                await _userOperationClaimRepository.UpdateAsync(userOperationClaim);

                UpdateUserOperationClaimResponse response = _mapper.Map<UpdateUserOperationClaimResponse>(userOperationClaim);
                return response;
            }
        }
    }
}
