using Application.Features.OperationClaims.Constants;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Entities;
using MediatR;
using static Application.Features.OperationClaims.Constants.OperationClaimsOperationClaims;

namespace Application.Features.OperationClaims.Commands.SoftDelete
{
    public class SoftDeleteOperationClaimCommand : IRequest<SoftDeleteOperationClaimResponse>, ISecuredRequest, ILoggableRequest
    {
        public string[] RequiredRoles => new[] { Admin, OperationClaimsOperationClaims.Delete };
        public int Id { get; set; }

        public class SoftDeleteOperationClaimCommandHandler : IRequestHandler<SoftDeleteOperationClaimCommand, SoftDeleteOperationClaimResponse>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;

            public SoftDeleteOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
            }

            public async Task<SoftDeleteOperationClaimResponse> Handle(SoftDeleteOperationClaimCommand request, CancellationToken cancellationToken)
            {
                OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(i => i.Id == request.Id);

                if (operationClaim == null || operationClaim.IsDeleted == true)
                {
                    throw new NotFoundException(OperationClaimsMessages.OperationClaimNotExists);
                }

                await _operationClaimRepository.SoftDeleteAsync(operationClaim);

                SoftDeleteOperationClaimResponse response = _mapper.Map<SoftDeleteOperationClaimResponse>(operationClaim);
                return response;
            }
        }
    }
}
