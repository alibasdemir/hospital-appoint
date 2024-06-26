using Application.Features.OperationClaims.Constants;
using Application.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Entities;
using MediatR;

namespace Application.Features.OperationClaims.Commands.Delete
{
    public class DeleteOperationClaimCommand : IRequest<DeleteOperationClaimResponse>
    {
        public int Id { get; set; }

        public class DeleteOperationClaimCommandHandler : IRequestHandler<DeleteOperationClaimCommand, DeleteOperationClaimResponse>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;

            public DeleteOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
            }

            public async Task<DeleteOperationClaimResponse> Handle(DeleteOperationClaimCommand request, CancellationToken cancellationToken)
            {
                OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(i => i.Id == request.Id);

                if (operationClaim == null)
                {
                    throw new NotFoundException(OperationClaimsMessages.OperationClaimNotExists);
                }

                await _operationClaimRepository.DeleteAsync(operationClaim);
                
                DeleteOperationClaimResponse response = _mapper.Map<DeleteOperationClaimResponse>(operationClaim);
                return response;

            }
        }
    }
}
