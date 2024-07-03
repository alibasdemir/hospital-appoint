namespace Application.Features.Auth.Commands.ChangePassword
{
    public class ChangePasswordResponse
    {
        public string Email { get; set; }
        public string Detail { get; set; } = "Your password has been changed successfully";
    }
}
