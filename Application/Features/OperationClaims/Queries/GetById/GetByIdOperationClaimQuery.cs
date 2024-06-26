using Application.Features.OperationClaims.Constants;
using Application.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Entities;
using MediatR;

namespace Application.Features.OperationClaims.Queries.GetById
{
    public class GetByIdOperationClaimQuery : IRequest<GetByIdOperationClaimResponse>
    {
        public int Id { get; set; }

        public class GetByIdOperationClaimQueryHandler : IRequestHandler<GetByIdOperationClaimQuery, GetByIdOperationClaimResponse>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;

            public GetByIdOperationClaimQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdOperationClaimResponse> Handle(GetByIdOperationClaimQuery request, CancellationToken cancellationToken)
            {
                OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(i => i.Id == request.Id);

                if (operationClaim == null || operationClaim.IsDeleted == true)
                {
                    throw new NotFoundException(OperationClaimsMessages.OperationClaimNotExists);
                }

                GetByIdOperationClaimResponse response = _mapper.Map<GetByIdOperationClaimResponse>(operationClaim);
                return response;
            }
        }
    }
}
