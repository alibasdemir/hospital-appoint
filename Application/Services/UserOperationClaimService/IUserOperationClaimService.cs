namespace Application.Services.UserOperationClaimService
{
    public interface IUserOperationClaimService
    {
        Task AssignOperationClaimToUser(int userId, int operationClaimId);
    }
}
