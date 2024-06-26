using Application.Features.UserOperationClaims.Constants;

namespace Application.Features.UserOperationClaims.Commands.Delete
{
    public class DeleteUserOperationClaimResponse
    {
        public int Id { get; set; }
        public string Detail { get; set; } = UserOperationClaimsMessages.UserOperationClaimDeleteMsg;
    }
}
