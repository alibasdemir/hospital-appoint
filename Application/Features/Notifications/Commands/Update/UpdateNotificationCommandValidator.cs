using Domain.Enums;
using FluentValidation;

namespace Application.Features.Notifications.Commands.Update
{
	public class UpdateNotificationCommandValidator : AbstractValidator<UpdateNotificationCommand>
	{
		public UpdateNotificationCommandValidator()
		{
			RuleFor(i => i.Title).NotEmpty().WithMessage("Title can not be empty.");
			RuleFor(i => i.Message).NotEmpty().WithMessage("Description can not be empty.");
			RuleFor(i => i.NotificationType).NotEmpty().WithMessage("Type should be selected.");
		}
    }
}
