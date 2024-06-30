using Application.Features.OperationClaims.Constants;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Entities;
using MediatR;
using static Application.Features.OperationClaims.Constants.OperationClaimsOperationClaims;

namespace Application.Features.OperationClaims.Commands.Update
{
    public class UpdateOperationClaimCommand : IRequest<UpdateOperationClaimResponse>, ISecuredRequest, ILoggableRequest
    {
        public string[] RequiredRoles => new[] { Admin, OperationClaimsOperationClaims.Update };
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommand, UpdateOperationClaimResponse>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;

            public UpdateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
            }

            public async Task<UpdateOperationClaimResponse> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(i => i.Id == request.Id);


                if (operationClaim == null || operationClaim.IsDeleted == true)
                {
                    throw new NotFoundException(OperationClaimsMessages.OperationClaimNotExists);
                }

                _mapper.Map(request, operationClaim);

                await _operationClaimRepository.UpdateAsync(operationClaim);

                UpdateOperationClaimResponse response = _mapper.Map<UpdateOperationClaimResponse>(operationClaim);
                return response;
            }
        }
    }
}
