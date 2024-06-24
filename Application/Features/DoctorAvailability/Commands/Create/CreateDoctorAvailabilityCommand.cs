using Application.Features.Doctors.Commands.Create;
using Application.Features.DoctorSchedules.Commands.Update;
using Application.Repositories;
using Application.Services.DoctorService;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.DoctorSchedules.Commands.Create
{
	public class CreateDoctorAvailabilityCommand : IRequest<CreateDoctorAvailabilityResponse>
	{
		public DateTime AvailableDate { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public int DoctorId { get; set; }

		public class CreateDoctorScheduleCommandHandler : IRequestHandler<CreateDoctorAvailabilityCommand, CreateDoctorAvailabilityResponse>
		{
			private readonly IDoctorAvailabilityRepository _doctorAvailabilityRepository;
			private readonly IMapper _mapper;
			private readonly IDoctorService _doctorService;

			public CreateDoctorScheduleCommandHandler(IDoctorAvailabilityRepository doctorAvailabilityRepository, IMapper mapper, IDoctorService doctorService)
			{
				_doctorAvailabilityRepository = doctorAvailabilityRepository;
				_mapper = mapper;
				_doctorService = doctorService;
			}

			public async Task<CreateDoctorAvailabilityResponse> Handle(CreateDoctorAvailabilityCommand request, CancellationToken cancellationToken)
			{
				bool isDoctorExist = await _doctorService.DoctorValidationById(request.DoctorId);

				if (isDoctorExist)
				{
					DoctorAvailability doctorSchedule = _mapper.Map<DoctorAvailability>(request);
					await _doctorAvailabilityRepository.AddAsync(doctorSchedule);

					CreateDoctorAvailabilityResponse response = _mapper.Map<CreateDoctorAvailabilityResponse>(doctorSchedule);
					return response;
				}
				throw new NotFoundException("Böyle bir doktor yok");
			}
		}
	}
}
