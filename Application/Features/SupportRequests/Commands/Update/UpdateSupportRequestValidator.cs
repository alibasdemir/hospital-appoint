using FluentValidation;

namespace Application.Features.SupportRequests.Commands.Update
{
    public class UpdateSupportRequestValidator : AbstractValidator<UpdateSupportRequestCommand>
    {
        public UpdateSupportRequestValidator()
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
