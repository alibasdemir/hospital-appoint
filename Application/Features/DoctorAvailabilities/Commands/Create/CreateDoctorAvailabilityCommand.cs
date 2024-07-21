using Application.Repositories;
using Application.Services.DoctorService;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using static Application.Features.DoctorAvailabilities.Constants.DoctorAvailabilityOperationClaims;
using Application.Features.DoctorAvailabilities.Rules;

namespace Application.Features.DoctorAvailabilities.Commands.Create
{
	public class CreateDoctorAvailabilityCommand : IRequest<CreateDoctorAvailabilityResponse>, ISecuredRequest, ILoggableRequest
	{
		public string[] RequiredRoles => [Admin, Write, Add];
        public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public int DoctorId { get; set; }

		public class CreateDoctorAvailabilityCommandHandler : IRequestHandler<CreateDoctorAvailabilityCommand, CreateDoctorAvailabilityResponse>
		{
			private readonly IDoctorAvailabilityRepository _doctorAvailabilityRepository;
			private readonly IMapper _mapper;
			private readonly IDoctorService _doctorService;
			private readonly DoctorAvailabilityBusinessRules _doctorAvailabilityBusinessRules;

            public CreateDoctorAvailabilityCommandHandler(IDoctorAvailabilityRepository doctorAvailabilityRepository, IMapper mapper, IDoctorService doctorService, DoctorAvailabilityBusinessRules doctorAvailabilityBusinessRules)
            {
                _doctorAvailabilityRepository = doctorAvailabilityRepository;
                _mapper = mapper;
                _doctorService = doctorService;
                _doctorAvailabilityBusinessRules = doctorAvailabilityBusinessRules;
            }

            public async Task<CreateDoctorAvailabilityResponse> Handle(CreateDoctorAvailabilityCommand request, CancellationToken cancellationToken)
			{
                await _doctorAvailabilityBusinessRules.DoctorShouldBeExist(request.DoctorId);
                await _doctorAvailabilityBusinessRules.ValidateDoctorAvailability(request);

                var doctorAvailability = _mapper.Map<DoctorAvailability>(request);
                await _doctorAvailabilityRepository.AddAsync(doctorAvailability);

                CreateDoctorAvailabilityResponse response = _mapper.Map<CreateDoctorAvailabilityResponse>(doctorAvailability);
                return response;
            }
		}
	}
}
