using FluentValidation;

namespace Application.Features.Appointments.Commands.Update
{
    public class UpdateAppointmentValidator : AbstractValidator<UpdateAppointmentCommand>
    {
        public UpdateAppointmentValidator()
        {
			RuleFor(i => i.PatientId).NotEmpty().WithMessage("PatientId can not be empty.");
			RuleFor(i => i.DoctorAvailabilityId).NotEmpty().WithMessage("DoctorAvailabilityId can not be empty.");
			RuleFor(i => i.Status).NotEmpty().WithMessage("Status can not be empty.");
			RuleFor(i => i.StartTime).NotEmpty().WithMessage("StartTime can not be empty.");
			RuleFor(i => i.EndTime).NotEmpty().WithMessage("EndTime can not be empty.");
		}
    }
}
