using Application.Features.UserOperationClaims.Constants;
using Application.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Entities;

namespace Application.Features.UserOperationClaims
{
    public class UserOperationClaimBusinessRule
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;

        public UserOperationClaimBusinessRule(IUserOperationClaimRepository userOperationClaimRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
        }
        public async Task UserOperationClaimShouldBeExist(int id)
        {
            UserOperationClaim? userOperationClaim = await _userOperationClaimRepository.GetAsync(i => i.Id == id);
            if (userOperationClaim == null)
            {
                throw new BusinessException(UserOperationClaimsMessages.UserOperationClaimNotExists);
            }
        }

        public async Task UserOperationClaimDeleteControl(int id)
        {
            UserOperationClaim? userOperationClaim = await _userOperationClaimRepository.GetAsync(i => i.Id == id);
            if (userOperationClaim == null || userOperationClaim.IsDeleted == true)
            {
                throw new BusinessException(UserOperationClaimsMessages.UserOperationClaimNotExists);
            }
        }
    }
}
