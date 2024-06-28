using Core.DataAccess;

namespace Core.Entities
{
    public class UserOperationClaim : Entity<int>
    {
        public int? BaseUserId { get; set; }
        public int? OperationClaimId { get; set; }

        public virtual BaseUser? BaseUser { get; set; }
        public virtual OperationClaim? OperationClaim { get; set; }

        public UserOperationClaim()
        {
        }

        public UserOperationClaim(int id, int? baseUserId, int? operationClaimId)
            : base(id)
        {
            BaseUserId = baseUserId;
            OperationClaimId = operationClaimId;
        }
    }
}
