using FluentValidation;

namespace Application.Features.PatientReports.Commands.Create
{
	public class CreatePatientReportValidator : AbstractValidator<CreatePatientReportCommand>
	{
        public CreatePatientReportValidator()
        {
			RuleFor(i => i.AppointmentId).NotEmpty().WithMessage("AppointmentId should be selected.");
			RuleFor(i => i.Title).NotEmpty().WithMessage("Details can not be empty.");
			RuleFor(i => i.Details).NotEmpty().WithMessage("Details can not be empty.");
		}
    }
}
