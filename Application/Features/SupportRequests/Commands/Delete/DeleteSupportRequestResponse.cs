namespace Application.Features.SupportRequests.Commands.Delete
{
    public class DeleteSupportRequestResponse
	{
        public int Id { get; set; }
        public string Detail { get; set; } = "Deletion Successful!";
    }
}
