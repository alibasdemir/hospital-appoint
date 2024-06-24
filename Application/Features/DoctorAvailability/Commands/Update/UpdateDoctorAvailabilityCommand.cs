using Application.Repositories;
using Application.Services.DoctorService;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.DoctorSchedules.Commands.Update
{
	public class UpdateDoctorAvailabilityCommand : IRequest<UpdateDoctorAvailabilityResponse>
	{
		public DateTime AvailableDate { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public int DoctorId { get; set; }

		public class UpdateDoctorScheduleCommandHandler : IRequestHandler<UpdateDoctorScheduleCommand, UpdateDoctorScheduleResponse>
		{
			private readonly IDoctorAvailabilityRepository _doctorAvailabilityRepository;
			private readonly IMapper _mapper;
			private readonly IDoctorService _doctorService;

			public UpdateDoctorScheduleCommandHandler(IDoctorAvailabilityRepository doctorAvailabilityRepository, IMapper mapper, IDoctorService doctorService)
			{
				_doctorAvailabilityRepository = doctorAvailabilityRepository;
				_mapper = mapper;
				_doctorService = doctorService;
			}

			public async Task<UpdateDoctorScheduleResponse> Handle(UpdateDoctorAvailabilityCommand request, CancellationToken cancellationToken)
			{
				bool isDoctorExist = await _doctorService.DoctorValidationById(request.DoctorId);

				if (isDoctorExist)
				{
					DoctorAvailability doctorAvailability = _mapper.Map<DoctorAvailability>(request);
					await _doctorAvailabilityRepository.UpdateAsync(doctorAvailability);

					UpdateDoctorAvailabilityResponse response = _mapper.Map<UpdateDoctorAvailabilityResponse>(doctorAvailability);
					return response;
				}
				throw new NotFoundException("Böyle bir doktor yok");
			}
		}
	}
}
