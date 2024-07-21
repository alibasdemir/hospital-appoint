using Application.Features.OperationClaims.Constants;
using Application.Features.OperationClaims.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
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
            private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

            public SoftDeleteOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper, OperationClaimBusinessRules operationClaimBusinessRules)
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
                _operationClaimBusinessRules = operationClaimBusinessRules;
            }

            public async Task<SoftDeleteOperationClaimResponse> Handle(SoftDeleteOperationClaimCommand request, CancellationToken cancellationToken)
            {
                OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(i => i.Id == request.Id);

                await _operationClaimBusinessRules.OperationClaimDeleteControl(request.Id);

                await _operationClaimRepository.SoftDeleteAsync(operationClaim);

                SoftDeleteOperationClaimResponse response = _mapper.Map<SoftDeleteOperationClaimResponse>(operationClaim);
                return response;
            }
        }
    }
}
