using Domain.Enums;
using FluentValidation;

namespace Application.Features.Feedbacks.Commands.Create
{
	public class CreateFeedbackCommandValidator : AbstractValidator<CreateFeedbackCommand>
	{
		public CreateFeedbackCommandValidator()
		{
			RuleFor(i => i.Title).NotEmpty().WithMessage("Title can not be empty.");
			RuleFor(i => i.Description).NotEmpty().WithMessage("Description can not be empty.");
		}
    }
}
