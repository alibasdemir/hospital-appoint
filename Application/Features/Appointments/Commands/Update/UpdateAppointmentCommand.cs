using Application.Repositories;
using Application.Services.PatientService;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Mailing;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.Appointments.Commands.Update
{
    public class UpdateAppointmentCommand : IRequest<UpdateAppointmentResponse>
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public AppointmentStatus Status { get; set; }

        public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommand, UpdateAppointmentResponse>
        {
            private readonly IAppointmentRepository _appointmentRepository;
            private readonly IMapper _mapper;
            private readonly IMailService _mailService;
            private readonly IPatientService _patientService;

            public UpdateAppointmentCommandHandler(IAppointmentRepository appointmentRepository, IMapper mapper, IMailService mailService)
            {
                _appointmentRepository = appointmentRepository;
                _mapper = mapper;
                _mailService = mailService;
            }

            public async Task<UpdateAppointmentResponse> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
            {
                Appointment? appointment = await _appointmentRepository.GetAsync(i => i.Id == request.Id);

                if (appointment == null)
                {
                    throw new NotFoundException("Appointment not found");
                }

                if (request.Status == AppointmentStatus.Booked && appointment.Status != AppointmentStatus.Available)
                {
                    throw new BusinessException("The appointment slot is not available.");
                }

                _mapper.Map(request, appointment);
                await _appointmentRepository.UpdateAsync(appointment);

                //User user = await _patientService.GetUserAsync(request.PatientId);
                //await _mailService.BookedAppointmentMailAsync(user.Email, appointment.StartTime, user.FirstName, user.LastName);

                UpdateAppointmentResponse response = _mapper.Map<UpdateAppointmentResponse>(appointment);
                return response;
            }
        }
    }
}
