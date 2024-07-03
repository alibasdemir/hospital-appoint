using Core.Entities;
namespace Application.Services.OperationClaimService
{
    public interface IOperationClaimService
    {
        Task<OperationClaim> GetOperationClaimByIdAsync(int operationClaimId);
    }
}
