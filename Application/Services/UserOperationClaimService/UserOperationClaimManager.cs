
using Application.Repositories;
using Core.Entities;

namespace Application.Services.UserOperationClaimService
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;

        public UserOperationClaimManager(IUserOperationClaimRepository userOperationClaimRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
        }

        public async Task AssignOperationClaimToUser(int userId, int operationClaimId)
        {
            var userOperationClaim = new UserOperationClaim
            {
                BaseUserId = userId,
                OperationClaimId = operationClaimId
            };

            await _userOperationClaimRepository.AddAsync(userOperationClaim);
        }
    }
}
