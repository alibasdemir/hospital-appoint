using FluentValidation;

namespace Application.Features.DoctorAvailabilities.Commands.Update
{
	public class UpdateDoctorAvailabilitiesValidator : AbstractValidator<UpdateDoctorAvailabilityCommand>
	{
        public UpdateDoctorAvailabilitiesValidator()
        {
			RuleFor(i => i.StartTime).NotEmpty().WithMessage("StartTime should be selected.");
			RuleFor(i => i.EndTime).NotEmpty().WithMessage("EndTime should be selected.");
			RuleFor(i => i.DoctorId).NotEmpty().WithMessage("DoctorId should be selected.");
		}
    }
}
