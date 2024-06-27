using FluentValidation;

namespace Application.Features.Appointments.Commands.Create
{
    public class CreateAppointmentValidator : AbstractValidator<CreateAppointmentCommand>
    {
        public CreateAppointmentValidator()
        {
			RuleFor(i => i.PatientId).NotEmpty().WithMessage("PatientId can not be empty.");
			RuleFor(i => i.DoctorAvailabilityId).NotEmpty().WithMessage("DoctorAvailabilityId can not be empty.");
			RuleFor(i => i.Status).NotEmpty().WithMessage("Status can not be empty.");
			RuleFor(i => i.StartTime).NotEmpty().WithMessage("StartTime can not be empty.");
			RuleFor(appointment => appointment.StartTime)
			.NotEmpty().WithMessage("Başlangıç zamanı gereklidir.");
			//.Must(dateTime => BeValidDateTime(dateTime)).WithMessage("Geçerli bir tarih ve saat giriniz."); TO DO
			RuleFor(i => i.EndTime).NotEmpty().WithMessage("EndTime can not be empty.");
		}
		//private bool BeValidDateTime(DateTime? dateTime)
		//{
			
		//	return dateTime.HasValue && dateTime.Value >= DateTime.Now;
		//}
	}
}
