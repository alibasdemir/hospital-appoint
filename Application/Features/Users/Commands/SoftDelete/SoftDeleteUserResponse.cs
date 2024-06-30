namespace Application.Features.Users.Commands.SoftDelete
{
    public class SoftDeleteUserResponse
    {
        public int Id { get; set; }
        public string Detail { get; set; } = "Deletion Successful!";
    }
}
