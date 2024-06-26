using Application.Features.UserOperationClaims.Constants;

namespace Application.Features.UserOperationClaims.Commands.SoftDelete
{
    public class SoftDeleteUserOperationClaimResponse
    {
        public int Id { get; set; }
        public DateTime DeletedDate { get; set; }
        public string Detail { get; set; } = UserOperationClaimsMessages.UserOperationClaimDeleteMsg;
    }
}
