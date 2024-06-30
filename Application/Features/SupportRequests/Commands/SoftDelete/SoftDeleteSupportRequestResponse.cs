namespace Application.Features.SupportRequests.Commands.SoftDelete
{
    public class SoftDeleteSupportRequestResponse
	{
        public int Id { get; set; }
        public string Detail { get; set; } = "Deletion Successful!";
    }
}
