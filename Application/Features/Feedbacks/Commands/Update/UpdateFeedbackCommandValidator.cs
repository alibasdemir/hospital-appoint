using Domain.Enums;
using FluentValidation;

namespace Application.Features.Feedbacks.Commands.Update
{
	public class UpdateFeedbackCommandValidator : AbstractValidator<UpdateFeedbackCommand>
	{
		public UpdateFeedbackCommandValidator()
		{
			RuleFor(i => i.Title).NotEmpty().WithMessage("Title can not be empty.");
			RuleFor(i => i.Description).NotEmpty().WithMessage("Description can not be empty.");
		}
    }
}
