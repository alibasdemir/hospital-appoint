using Application.Features.UserOperationClaims.Constants;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.Entities;
using MediatR;
using static Application.Features.UserOperationClaims.Constants.UserOperationClaimsOperationClaims;

namespace Application.Features.UserOperationClaims.Commands.SoftDelete
{
    public class SoftDeleteUserOperationClaimCommand : IRequest<SoftDeleteUserOperationClaimResponse>, ISecuredRequest, ILoggableRequest
    {
        public string[] RequiredRoles => new[] { Admin, UserOperationClaimsOperationClaims.Delete };
        public int Id { get; set; }

        public class SoftDeleteUserOperationClaimCommandHandler : IRequestHandler<SoftDeleteUserOperationClaimCommand, SoftDeleteUserOperationClaimResponse>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IMapper _mapper;
            private readonly UserOperationClaimBusinessRule _userOperationClaimBusinessRule;

            public SoftDeleteUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper, UserOperationClaimBusinessRule userOperationClaimBusinessRule)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
                _userOperationClaimBusinessRule = userOperationClaimBusinessRule;
            }

            public async Task<SoftDeleteUserOperationClaimResponse> Handle(SoftDeleteUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                UserOperationClaim? userOperationClaim = await _userOperationClaimRepository.GetAsync(i => i.Id == request.Id);

                await _userOperationClaimBusinessRule.UserOperationClaimDeleteControl(request.Id);

                userOperationClaim.BaseUserId = null;
                await _userOperationClaimRepository.SoftDeleteAsync(userOperationClaim);

                SoftDeleteUserOperationClaimResponse response = _mapper.Map<SoftDeleteUserOperationClaimResponse>(userOperationClaim);
                return response;
            }
        }
    }
}
