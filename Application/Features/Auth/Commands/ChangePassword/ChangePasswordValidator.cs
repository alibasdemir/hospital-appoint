using FluentValidation;

namespace Application.Features.Auth.Commands.ChangePassword
{
    public class ChangePasswordValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordValidator()
        {
            RuleFor(i => i.NewPassword).NotEmpty().MinimumLength(6);
        }
    }
}
