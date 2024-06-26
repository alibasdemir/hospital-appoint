namespace Application.Features.OperationClaims.Commands.SoftDelete
{
    public class SoftDeleteOperationClaimResponse
    {
        public int Id { get; set; }
        public string Detail { get; set; } = "Deletion Successful!";
    }
}
