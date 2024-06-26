namespace Application.Features.UserOperationClaims.Commands.Create
{
    public class CreateUserOperationClaimResponse
    {
        public int Id { get; set; }
        public int BaseUserId { get; set; }
        public int OperationClaimId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
