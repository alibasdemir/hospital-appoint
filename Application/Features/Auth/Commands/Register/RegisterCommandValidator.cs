using FluentValidation;

namespace Application.Features.Auth.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(i => i.FirstName).NotEmpty().MinimumLength(2);
            RuleFor(i => i.LastName).NotEmpty().MinimumLength(2);
            RuleFor(i => i.Email).NotEmpty().EmailAddress();
            RuleFor(i => i.Password).NotEmpty().MinimumLength(6);
        }
    }
}
