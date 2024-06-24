using Domain.Enums;
using FluentValidation;

namespace Application.Features.Doctors.Commands.Create
{
	public class CreateDoctorCommandValidator : AbstractValidator<CreateDoctorCommand>
	{
		public CreateDoctorCommandValidator()
		{
			RuleFor(i => i.UserId).NotEmpty().WithMessage("User should be selected.");
			RuleFor(i => i.DepartmentId).NotEmpty().WithMessage("Department should be selected.");
		}
    }
}
