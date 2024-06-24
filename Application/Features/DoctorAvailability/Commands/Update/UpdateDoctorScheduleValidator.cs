using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.DoctorSchedules.Commands.Update
{
	public class UpdateDoctorAvailabilityValidator : AbstractValidator<UpdateDoctorAvailabilityCommand>
	{
        public UpdateDoctorAvailabilityValidator()
        {
			RuleFor(i => i.AvailableDate).NotEmpty().WithMessage("AvailableDate should be selected.");
			RuleFor(i => i.StartTime).NotEmpty().WithMessage("StartTime should be selected.");
			RuleFor(i => i.EndTime).NotEmpty().WithMessage("EndTime should be selected.");
			RuleFor(i => i.DoctorId).NotEmpty().WithMessage("DoctorId should be selected.");
		}
    }
}
