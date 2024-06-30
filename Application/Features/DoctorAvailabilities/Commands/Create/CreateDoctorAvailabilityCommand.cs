using Application.Features.DoctorAvailabilities.Constants;
using Application.Repositories;
using Application.Services.DoctorService;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;
using static Application.Features.DoctorAvailabilities.Constants.DoctorAvailabilityOperationClaims;
using Application.Features.Doctors.Constants;

namespace Application.Features.DoctorAvailabilities.Commands.Create
{
	public class CreateDoctorAvailabilityCommand : IRequest<CreateDoctorAvailabilityResponse>, ISecuredRequest, ILoggableRequest
	{
		public string[] RequiredRoles => [Admin, Write, Add];
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
				DoctorAvailability? doctorAvailability = _doctorAvailabilityRepository.Get(i => i.StartTime == request.StartTime);

				if (!isDoctorExist)
				{
					throw new NotFoundException(DoctorsMessages.DoctorNotExists);
				}

				if (doctorAvailability is null)
				{
					doctorAvailability = _mapper.Map<DoctorAvailability>(request);
					await _doctorAvailabilityRepository.AddAsync(doctorAvailability);
				}
					CreateDoctorAvailabilityResponse response = _mapper.Map<CreateDoctorAvailabilityResponse>(doctorAvailability);
					return response;
			}
		}
	}
}
