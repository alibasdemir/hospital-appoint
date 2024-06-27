using FluentValidation;

namespace Application.Features.SupportRequests.Commands.Create
{
    public class CreateSupportRequestValidator : AbstractValidator<CreateSupportRequestCommand>
    {
        public CreateSupportRequestValidator()
        {
			RuleFor(i => i.Title).NotEmpty().WithMessage("Title can not be empty.");
			RuleFor(i => i.Email).NotEmpty().WithMessage("Email can not be empty.");
			RuleFor(i => i.PhoneNumber).NotEmpty().WithMessage("PhoneNumber can not be empty.");
			RuleFor(i => i.Content).NotEmpty().WithMessage("Content can not be empty.");
			RuleFor(i => i.FirstName).NotEmpty().WithMessage("FirstName can not be empty.");
			RuleFor(i => i.LastName).NotEmpty().WithMessage("LastName can not be empty.");
		}
    }
}
