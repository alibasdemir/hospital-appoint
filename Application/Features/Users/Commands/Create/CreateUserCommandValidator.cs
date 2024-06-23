using FluentValidation;

namespace Application.Features.Users.Commands.Create
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(i => i.Email).NotEmpty();
            RuleFor(i => i.Email).MinimumLength(1);

            RuleFor(i => i.FirstName).NotEmpty();
            RuleFor(i => i.FirstName).MinimumLength(1);

            RuleFor(i => i.LastName).NotEmpty();
            RuleFor(i => i.LastName).MinimumLength(1);

            RuleFor(i => i.Gender)
                .IsInEnum().WithMessage("Gender must be a valid enum value.");
        }
    }
}
