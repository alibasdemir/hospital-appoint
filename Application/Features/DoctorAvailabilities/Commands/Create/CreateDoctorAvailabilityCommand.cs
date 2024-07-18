using MediatR;
using Application.Services.DoctorService;
using Application.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using Application.Services.AppointmentService;

namespace Application.Features.DoctorAvailabilities.Commands.Create
{
    public class CreateDoctorAvailabilityCommand : IRequest<CreateDoctorAvailabilityResponse>
    {
        public int DoctorId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public class CreateDoctorAvailabilityCommandHandler : IRequestHandler<CreateDoctorAvailabilityCommand, CreateDoctorAvailabilityResponse>
        {
            private readonly IDoctorAvailabilityRepository _doctorAvailabilityRepository;
            private readonly IAppointmentService _appointmentService;
            private readonly IDoctorService _doctorService;
            private readonly IMapper _mapper;

            public CreateDoctorAvailabilityCommandHandler(
                IDoctorAvailabilityRepository doctorAvailabilityRepository,
                IAppointmentService appointmentService,
                IDoctorService doctorService,
                IMapper mapper)
            {
                _doctorAvailabilityRepository = doctorAvailabilityRepository;
                _appointmentService = appointmentService;
                _doctorService = doctorService;
                _mapper = mapper;
            }

            public async Task<CreateDoctorAvailabilityResponse> Handle(CreateDoctorAvailabilityCommand request, CancellationToken cancellationToken)
            {
                bool isDoctorExist = await _doctorService.DoctorValidationById(request.DoctorId);

                if (!isDoctorExist)
                {
                    throw new NotFoundException("Doctor not found");
                }

                if (request.StartTime.Date != request.EndTime.Date)
                {
                    throw new BusinessException("Doctor availability must start and end on the same day.");
                }

                var existingAvailabilities = await _doctorAvailabilityRepository.GetListAsync(
                    da => da.DoctorId == request.DoctorId && da.StartTime.Date == request.StartTime.Date);

                if (existingAvailabilities.Items.Any())
                {
                    throw new BusinessException("A doctor can have only one availability per day.");
                }

                DoctorAvailability doctorAvailability = _mapper.Map<DoctorAvailability>(request);
                await _doctorAvailabilityRepository.AddAsync(doctorAvailability);

                await _appointmentService.CreateAppointments(doctorAvailability, 15);

                CreateDoctorAvailabilityResponse response = _mapper.Map<CreateDoctorAvailabilityResponse>(doctorAvailability);
                return response;
            }
        }
    }
}