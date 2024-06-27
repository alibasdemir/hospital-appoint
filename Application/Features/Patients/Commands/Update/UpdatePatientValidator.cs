using FluentValidation;

namespace Application.Features.Patients.Commands.Update
{
	public class UpdatePatientAvailabilitiesValidator : AbstractValidator<UpdatePatientCommand>
	{
        public UpdatePatientAvailabilitiesValidator()
        {
			RuleFor(i => i.UserId).NotEmpty().WithMessage("UserId can not be empty.");
			RuleFor(i => i.BloodType).NotEmpty().WithMessage("BloodType can not be empty.");
			RuleFor(i => i.InsuranceType).NotEmpty().WithMessage("InsuranceType can not be empty.");
			RuleFor(i => i.SocialSecurityNumber).NotEmpty().WithMessage("SocialSecurityNumber can not be empty.");
		}
    }
}
