using Application.Features.OperationClaims.Constants;
using Application.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Entities;

namespace Application.Features.OperationClaims.Rules
{
    public class OperationClaimBusinessRules
    {
        private readonly IOperationClaimRepository _operationClaimRepository;

        public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository)
        {
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task OperationClaimShouldBeExist(int id)
        {
            OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(i => i.Id == id);
            if (operationClaim == null)
            {
                throw new BusinessException(OperationClaimsMessages.OperationClaimNotExists);
            }
        }

        public async Task OperationClaimDeleteControl(int id)
        {
            OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(i => i.Id == id);
            if (operationClaim == null || operationClaim.IsDeleted == true)
            {
                throw new BusinessException(OperationClaimsMessages.OperationClaimNotExists);
            }
        }
    }
}
