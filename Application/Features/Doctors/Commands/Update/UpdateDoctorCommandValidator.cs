using Domain.Enums;
using FluentValidation;

namespace Application.Features.Doctors.Commands.Update
{
	public class UpdateDoctorCommandValidator : AbstractValidator<UpdateDoctorCommand>
	{
		public UpdateDoctorCommandValidator()
		{
			RuleFor(i => i.UserId).NotEmpty().WithMessage("User should be selected.");
			RuleFor(i => i.DepartmentId).NotEmpty().WithMessage("Department should be selected.");
		}
	}
}
