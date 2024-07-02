using Domain.Enums;
using FluentValidation;

namespace Application.Features.Notifications.Commands.Create
{
	public class CreateNotificationCommandValidator : AbstractValidator<CreateNotificationCommand>
	{
		public CreateNotificationCommandValidator()
		{
			RuleFor(i => i.Title).NotEmpty().WithMessage("Title can not be empty.");
			RuleFor(i => i.Message).NotEmpty().WithMessage("Description can not be empty.");
			RuleFor(i => i.NotificationType).NotEmpty().WithMessage("Type should be selected.");
		}
    }
}
