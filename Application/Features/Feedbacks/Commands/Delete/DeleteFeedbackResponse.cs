namespace Application.Features.Feedbacks.Commands.Delete
{
    public class DeleteFeedbackResponse
    {
        public int Id { get; set; }
        public string Detail { get; set; } = "Deletion Successful!";
    }
}
