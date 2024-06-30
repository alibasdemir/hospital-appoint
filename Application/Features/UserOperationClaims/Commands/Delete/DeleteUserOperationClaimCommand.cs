using Application.Features.UserOperationClaims.Constants;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Entities;
using MediatR;
using static Application.Features.UserOperationClaims.Constants.UserOperationClaimsOperationClaims;

namespace Application.Features.UserOperationClaims.Commands.Delete
{
    public class DeleteUserOperationClaimCommand : IRequest<DeleteUserOperationClaimResponse>, ISecuredRequest, ILoggableRequest
    {
        public string[] RequiredRoles => new[] { Admin, UserOperationClaimsOperationClaims.Delete };
        public int Id { get; set; }

        public class DeleteUserOperationClaimCommandHandler : IRequestHandler<DeleteUserOperationClaimCommand, DeleteUserOperationClaimResponse>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IMapper _mapper;

            public DeleteUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
            }

            public async Task<DeleteUserOperationClaimResponse> Handle(DeleteUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                UserOperationClaim? userOperationClaim = await _userOperationClaimRepository.GetAsync(i => i.Id == request.Id);

                if (userOperationClaim == null)
                {
                    throw new NotFoundException(UserOperationClaimsMessages.UserOperationClaimNotExists);
                }

                await _userOperationClaimRepository.DeleteAsync(userOperationClaim);

                DeleteUserOperationClaimResponse response = _mapper.Map<DeleteUserOperationClaimResponse>(userOperationClaim);
                return response;
            }
        }
    }
}
