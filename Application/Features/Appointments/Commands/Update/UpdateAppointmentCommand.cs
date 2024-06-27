using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.Appointments.Commands.Update
{
    public class UpdateAppointmentCommand : IRequest<UpdateAppointmentResponse>
    {
		public int PatientId { get; set; }
		public int DoctorAvailabilityId { get; set; }
		public AppointmentStatus Status { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }

		public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommand, UpdateAppointmentResponse>
        {
            private readonly IAppointmentRepository _appointmentRepository;
            private readonly IMapper _mapper;

            public UpdateAppointmentCommandHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
            {
                _appointmentRepository = appointmentRepository;
                _mapper = mapper;
            }

            public async Task<UpdateAppointmentResponse> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
            {
                Appointment appointment = _mapper.Map<Appointment>(request);
                
                await _appointmentRepository.UpdateAsync(appointment);
                UpdateAppointmentResponse response = _mapper.Map<UpdateAppointmentResponse>(appointment);
                return response;
            }
        }
    }
}
