using FluentValidation;

namespace Application.Features.DoctorAvailabilities.Commands.Create
{
	public class CreateDoctorAvailabilityValidator : AbstractValidator<CreateDoctorAvailabilityCommand>
	{
        public CreateDoctorAvailabilityValidator()
        {
			RuleFor(i => i.StartTime).NotEmpty().WithMessage("StartTime should be selected.");
			RuleFor(i => i.EndTime).NotEmpty().WithMessage("EndTime should be selected.");
			RuleFor(i => i.DoctorId).NotEmpty().WithMessage("DoctorId should be selected.");
		}
    }
}
