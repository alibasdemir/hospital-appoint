using Application.Repositories;
using Core.Entities;

namespace Application.Services.OperationClaimService
{
    public class OperationClaimManager : IOperationClaimService
    {
        private readonly IOperationClaimRepository _operationClaimRepository;

        public OperationClaimManager(IOperationClaimRepository operationClaimRepository)
        {
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task<OperationClaim> GetOperationClaimByIdAsync(int operationClaimId)
        {
            return await _operationClaimRepository.GetAsync(i => i.Id == operationClaimId);
        }
    }

}
