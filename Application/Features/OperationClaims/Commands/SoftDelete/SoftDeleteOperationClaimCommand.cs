using Application.Features.OperationClaims.Constants;
using Application.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Entities;
using MediatR;

namespace Application.Features.OperationClaims.Commands.SoftDelete
{
    public class SoftDeleteOperationClaimCommand : IRequest<SoftDeleteOperationClaimResponse>
    {
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
